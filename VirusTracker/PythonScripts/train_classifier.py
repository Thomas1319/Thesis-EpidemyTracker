from nltk.tokenize import line_tokenize
from nltk.tokenize import word_tokenize
from nltk.tokenize import TweetTokenizer
from nltk.stem.wordnet import WordNetLemmatizer
from nltk.corpus import stopwords
from nltk import FreqDist
from nltk import classify
from nltk import NaiveBayesClassifier
from sklearn.naive_bayes import MultinomialNB, BernoulliNB
from sklearn.linear_model import LogisticRegression, SGDClassifier
from nltk.classify.scikitlearn import SklearnClassifier
from nltk.classify import ClassifierI
import random
import nltk
import re, string
from nltk.tag import pos_tag
from statistics import mode
import pickle


tokenizer = TweetTokenizer(strip_handles=True, reduce_len=True)
pos = open('twitter_samples/positive_tweets.json', 'r').read()
neg = open('twitter_samples/negative_tweets.json', 'r').read()

pos_new = open('twitter_samples/pos_trimmed.txt', 'r').read()
neg_new = open('twitter_samples/neg_trimmed.txt', 'r').read()

#text = twitter_samples('tweets.20150430-223406.json')
tokenized_pos = line_tokenize(pos)
tokenized_neg = line_tokenize(neg)

stop_words = stopwords.words('english')

class VoteClassifier(ClassifierI):
    def __init__(self, *classifiers):
        self._classifiers = classifiers

    def classify(self, featureset):
        votes = []
        for c in self._classifiers:
            v = c.classify(featureset)
            votes.append(v)
        return mode(votes)

    def confidence(self, featureset):
        votes = []
        for c in self._classifiers:
            v = c.classify(featureset)
            votes.append(v)

        choice_votes = votes.count(mode(votes))
        conf = choice_votes / len(votes) * 100
        return conf



def trim_files():
    pos_trimmed = open('twitter_samples/pos_trimmed.txt', 'w')
    neg_trimmed = open('twitter_samples/neg_trimmed.txt', 'w')
    for l in tokenized_pos:
        line = tokenizer.tokenize(l)
        aux = ""
        for e in line:
            if e != "user":
                aux += e + " ";
            else:
                break
        aux = aux[66:]
        aux = aux[:-6] + "\n"
        pos_trimmed.write(aux)
    for l in tokenized_neg:
        line = tokenizer.tokenize(l)
        aux = ""
        for e in line:
            if e != "user":
                aux += e + " ";
            else:
                break
        aux = aux[66:]
        aux = aux[:-6]  + "\n"
        neg_trimmed.write(aux)
    pos_trimmed.close()
    neg_trimmed.close()

def all_words(cleaned_list):
    for tokens in cleaned_list:
        for token in tokens:
            yield token

def prepare_data(cleaned_list):
    for tokens in cleaned_list:
        yield dict([token, True] for token in tokens)

def clean_text(tokens, stopwords = ()):
    cleaned = []
    for token, tag in pos_tag(tokens):
        token = re.sub('(\b(http|https):\/\/.*[^ alt]\b)', '', token)  #links removal
        token = re.sub("(@[A-Za-z0-9_]+)", "", token) #mention removal
        token = re.sub("(#[A-Za-z0-9_]+)", "", token) #hashtag removal

        if tag.startswith('NN'):
            pos = 'n'
        elif tag.startswith('VB'):
            pos = 'v'
        else:
            pos = 'a'
        lemmatizer = WordNetLemmatizer()
        token = lemmatizer.lemmatize(token, pos)

        if len(token) > 0 and token not in string.punctuation and token.lower() not in stopwords and re.search("[@_!#$0123456789.`%^&*()<>?/|}{~:]", token.lower()) == None:
            cleaned.append(token.lower())
    return cleaned


def main():
    # trim_files()
    pos_lines = line_tokenize(pos_new)
    neg_lines = line_tokenize(neg_new)
    pos_cleaned = []
    neg_cleaned = []

    for l in pos_lines:
        tokens = word_tokenize(l)
        offset = 0
        for i, t in enumerate(tokens):
            i -= offset
            if t == ':' and i > 0:
                if "http" in tokens[i-1]:
                    left = tokens[:i-1]
                    right = tokens[i+2:]
                    joined = [tokens[i-1] + tokens[i] + tokens[i+1]]
                    tokens = left + joined + right
                    offset += 2
        #print(tokens)
        pos_cleaned.append(clean_text(tokens, stop_words))
    for l in neg_lines:
        tokens = word_tokenize(l)
        offset = 0
        for i, t in enumerate(tokens):
            i -= offset
            if t == ':' and i > 0:
                if "http" in tokens[i - 1]:
                    left = tokens[:i - 1]
                    right = tokens[i + 2:]
                    joined = [tokens[i - 1] + tokens[i] + tokens[i + 1]]
                    tokens = left + joined + right
                    offset += 2
        neg_cleaned.append(clean_text(tokens, stop_words))

    # print(pos_lines[6])
    # print(word_tokenize(pos_lines[6]))
    # print(pos_cleaned[6])

    freq_pos = FreqDist(all_words(pos_cleaned))
    freq_neg = FreqDist(all_words(neg_cleaned))

    # print(freq_pos.most_common(10))
    # print(freq_neg.most_common(10))

    pos_model = prepare_data(pos_cleaned)
    neg_model = prepare_data(neg_cleaned)

    pos_dataset = [(word_dict, "Positive") for word_dict in pos_model]
    neg_dataset = [(word_dict, "Negative") for word_dict in neg_model]

    dataset = pos_dataset + neg_dataset
    random.shuffle(dataset)

    train_data = dataset[:9000]
    test_data = dataset[9000:18000]

    NBclassifier = NaiveBayesClassifier.train(train_data)
    print(NBclassifier.show_most_informative_features(10))

    print("Accuracy NB: ", classify.accuracy(NBclassifier, test_data) * 100)

    MNBclassifier = SklearnClassifier(MultinomialNB())
    MNBclassifier.train(train_data)
    print("Accuracy MNB: ", classify.accuracy(MNBclassifier, test_data) * 100)


    BNBclassifier = SklearnClassifier(BernoulliNB())
    BNBclassifier.train(train_data)
    print("Bernoulli Naive Bayes algo accuracy: ", (nltk.classify.accuracy(BNBclassifier, test_data)) * 100)

    LRclassifier = SklearnClassifier(LogisticRegression())
    LRclassifier.train(train_data)
    print("LogisticRegression algo accuracy: ",
          (nltk.classify.accuracy(LRclassifier, test_data)) * 100)

    SGDclassifier = SklearnClassifier(SGDClassifier())
    SGDclassifier.train(train_data)
    print(" SGDClassifier algo accuracy: ", (nltk.classify.accuracy(SGDclassifier, test_data)) * 100)

    voted_classifier = VoteClassifier(NBclassifier,
                                      MNBclassifier,
                                      BNBclassifier,
                                      LRclassifier,
                                      SGDclassifier,
                                      )
    print("Voted classifier algo accuracy: ", (nltk.classify.accuracy(voted_classifier, test_data)) * 100)
    # custom = "i had suffered with harpez and pneumonia. I am not feeling very good and my wife and now i started to feel worse, my head hurts and i vomit everyday. I don think that i will survive. but i had taken zovirax intravenous depomedrol,tricot xylocaine and finally seftum 500 mg. the eruptions and irritable skin in groin and arm pits. my face looked i was older than my age. one day out of a miracle i had formulated my own drug which has saved me. the drug is powdered ammoxycilin 500mg, seftum500mg, althrocin 500 mg, cifran 500mgin right proportions. but then i died i applied to my groin, face, armpits. also like homeopathy i tried taking one milligram of this mixture rubbed on epiglottis. many diseases of the world. no side effects."
    # input = dict([token, True] for token in clean_text(word_tokenize(custom)))
    # print(voted_classifier.classify(input))
    # print(voted_classifier.confidence(input))

    save_test_data = open("test_data.pickle", "wb")
    save_classifier = open("final_classifier.pickle", "wb")
    pickle.dump(voted_classifier, save_classifier)
    pickle.dump(test_data, save_test_data)
    save_test_data.close()
    save_classifier.close()

if __name__ == '__main__':
    main()