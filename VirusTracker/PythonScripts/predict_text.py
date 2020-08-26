import pickle
import nltk
from nltk import classify, word_tokenize
import re, string
from nltk.tag import pos_tag
from nltk.stem.wordnet import WordNetLemmatizer
from nltk.corpus import stopwords
from nltk.classify import ClassifierI
from statistics import mode
import sys


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


class predict_text:
    def __init__(self):
        file_classifier = open("D:\\VSprojects\\VisualStudioProj\\Thesis\\VirusTracker\\PythonScripts\\final_classifier.pickle", "rb")
        self.classifier = pickle.load(file_classifier)
        file_classifier.close()

    def clean_text(self, input, stopwords=()):
        tokens = word_tokenize(input)
        offset = 0
        for i, t in enumerate(tokens): # concatenate the hyperlinks because they where split by word_tokenize in order
            i -= offset                 # to remove them later via regex
            if t == ':' and i > 0:
                if "http" in tokens[i - 1]:
                    left = tokens[:i - 1]
                    right = tokens[i + 2:]
                    joined = [tokens[i - 1] + tokens[i] + tokens[i + 1]]
                    tokens = left + joined + right
                    offset += 2
        cleaned = []
        for token, tag in pos_tag(tokens):
            token = re.sub('(\b(http|https):\/\/.*[^ alt]\b)', '', token)  # links removal
            token = re.sub("(@[A-Za-z0-9_]+)", "", token)  # mention removal
            token = re.sub("(#[A-Za-z0-9_]+)", "", token)  # hashtag removal

            if tag.startswith('NN'):
                pos = 'n'
            elif tag.startswith('VB'):
                pos = 'v'
            else:
                pos = 'a'
            lemmatizer = WordNetLemmatizer()
            token = lemmatizer.lemmatize(token, pos)

            if len(token) > 0 and token not in string.punctuation and token.lower() not in stopwords and re.search(
                    "[@_!#$0123456789.`%^&*()<>?/|}{~:]", token.lower()) == None:
                cleaned.append(token.lower())
        return cleaned


    def get_prediction(self, input):
        return self.classifier.classify(input)

    def get_confidence(self, input):
        return self.classifier.confidence(input)

def main():
    #file_classifier = open("final_classifier.pickle", "rb")
    #file_data = open("test_data.pickle", "rb")
    #test_data = pickle.load(file_data)
    #classifier = pickle.load(file_classifier)
    #file_classifier.close()
    #file_data.close()
    predicter = predict_text()
    custom = sys.argv[1]
    cleaned = predicter.clean_text(custom, stopwords=stop_words)
    input = dict([token, True] for token in cleaned)
    print(predicter.get_prediction(input))
    print(predicter.get_confidence(input))
   # print(custom)
    #print("My classifier accuracy: ", (nltk.classify.accuracy(classifier, test_data)) * 100)
if __name__ == '__main__':
    main()