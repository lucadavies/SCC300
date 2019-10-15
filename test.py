import nltk
with open("text.txt") as f:
    dat = f.read()
tokDat = nltk.word_tokenize(dat)
posWords = []
negWords = []
with open("posWords.txt") as f:
    for l in f:
        posWords.append((f.readline()[:-1]))
with open("negWords.txt") as f:
    for l in f:
        negWords.append((f.readline()[:-1]))
posVal = 0
negVal = 0
sentiment = 0
for w in tokDat:
    for pos in posWords:
        if w == pos:
            posVal += 1
            print(w)
    for neg in negWords:
        if w == neg:
            negVal -= 1
            print(w)
print(tokDat)
sentiment = posVal + negVal
print(posVal)
print(negVal)
print(sentiment)