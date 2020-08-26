import pickle
import re, string
from statistics import mode
class predict_text:
    def __init__(self):
        file_classifier = open("final_classifier.pickle", "rb")
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
    custom = "i had suffered with harpez and pneumonia. I am not http://google.com feeling very good and my wife and now i started to feel worse, my head hurts and i vomit everyday. I don think that i will survive. but i had taken zovirax intravenous depomedrol,tricot xylocaine and finally seftum 500 mg. the eruptions and irritable skin in groin and arm pits. my face looked i was older than my age. one day out of a miracle i had formulated my own drug which has saved me. the drug is powdered ammoxycilin 500mg, seftum500mg, althrocin 500 mg, cifran 500mgin right proportions. but then i died i applied to my groin, face, armpits. also like homeopathy i tried taking one milligram of this mixture rubbed on epiglottis. many diseases of the world. no side effects."
    cleaned = predicter.clean_text(custom, stopwords=stop_words)
    input = dict([token, True] for token in cleaned)
    print(predicter.get_prediction(input))
    print(predicter.get_confidence(input))
    #print("My classifier accuracy: ", (nltk.classify.accuracy(classifier, test_data)) * 100)
if __name__ == '__main__':
    main()