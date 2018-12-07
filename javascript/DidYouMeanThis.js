const firstCondition = Symbol('firstCondition'),
    similarityRatio = Symbol('similarityRatio');

class DidYouMeanThis {
    constructor(words) {
        this.words = words;
    }
    isThis(word) {
        let rate = 0,
            _word = null;
        for (let w of this.words) {
            let _rate = this[similarityRatio](w, word);
            if (_rate > rate) {
                rate = _rate;
                _word = w;
            }
        }
        return _word || word;
    }
    [firstCondition](correctWord, wrongWord) {
        let rate = wrongWord.length > 4 ? 2 : 1;
        let cr = [], wr = [];
        for (let i = 0; i < correctWord.length - 1; i++)
            cr[i] = correctWord.substring(i, i + 2);

        for (let i = 0; i < wrongWord.length - 1; i++)
            wr[i] = wrongWord.substring(i, i + 2);

        let count = 0, index = 0;

        for (let i = 0; i < cr.length; i++) {
            if ((index = wr.findIndex(m => m == cr[i])) != -1) {
                if (++count == rate)
                    return true;
                wr.splice(index, 1);
            }
        }
        return false;
    }
    [similarityRatio](correctWord, wrongWord) {
        if (!this[firstCondition](correctWord, wrongWord))
            return 0;

        let i = 0,
            sum = 0,
            count = 0,
            _correctWord = correctWord,
            _wrongWord = wrongWord;

        if (correctWord.length > wrongWord.length) {
            _correctWord = correctWord;
            _wrongWord = wrongWord;
        }
        else if (wrongWord.length > correctWord.length) {
            _correctWord = wrongWord;
            _wrongWord = correctWord;
        }
        while (count != _correctWord.length) {
            if (i < _correctWord.length
                && i < _wrongWord.length
                && _wrongWord[i] == _correctWord[i]
                || (i < _wrongWord.length
                    && i - 1 > 0 && _correctWord.length < i - 1
                    && _wrongWord[i] == _correctWord[i - 1])
                || (i + 1 < _correctWord.length
                    && i < _wrongWord.length
                    && _wrongWord[i] == _correctWord[i + 1])) {
                sum++;
            }
            i++;
            count++;
        }
        return 100 * sum / _correctWord.length;
    }
}

