/**
 * @author Dursun Katar
 * @mail   dursun.katar@gmail.com
 * @date   07.04.2018
 */
using System.Collections.Generic;
using System.Linq;

namespace Dursunkatar
{
    public class DidYouMeanThis
    {
        public IEnumerable<string> Words { get; set; }

        public string IsThis(string word)
        {
            int rate = 0;
            string _word = null;
            foreach (var w in Words)
            {
                int _rate = similarityRatio(w, word);
                if (_rate > rate)
                {
                    rate = _rate;
                    _word = w;
                }
            }
            return _word ?? word;
        }
        private bool firstCondition(string correctWord, string wrongWord)
        {
            int rate = wrongWord.Length > 4 ? 2 : 1;

            var cr = new List<string>();
            for (int i = 0; i < correctWord.Length - 1; i++)
                cr.Add(correctWord.Substring(i, 2));

            var wr = new List<string>();
            for (int i = 0; i < wrongWord.Length - 1; i++)
                wr.Add(wrongWord.Substring(i, 2));

            int count = 0;
            int index = 0;
            for (int i = 0; i < cr.Count(); i++)
            {
                if ((index = wr.IndexOf(cr[i])) != -1)
                {
                    if (++count == rate)
                        return true;
                    wr.RemoveAt(index);
                }
            }
            return false;
        }
        private int similarityRatio(string correctWord, string wrongWord)
        {
            if (!firstCondition(correctWord, wrongWord))
                return 0;

            int i = 0;
            int sum = 0;
            int count = 0;
            string _correctWord = correctWord;
            string _wrongWord = wrongWord;

            if (correctWord.Length > wrongWord.Length)
            {
                _correctWord = correctWord;
                _wrongWord = wrongWord;
            }
            else if (wrongWord.Length > correctWord.Length)
            {
                _correctWord = wrongWord;
                _wrongWord = correctWord;
            }
            while (count != _correctWord.Length)
            {
                if (i < _correctWord.Length
                    && i < _wrongWord.Length
                    && _wrongWord[i] == _correctWord[i]
                    || (i < _wrongWord.Length
                    && i - 1 > 0 && _correctWord.Length < i - 1
                    && _wrongWord[i] == _correctWord[i - 1])
                    || (i + 1 < _correctWord.Length
                    && i < _wrongWord.Length
                    && _wrongWord[i] == _correctWord[i + 1]))
                {
                    sum++;
                }
                i++;
                count++;
            }
            return 100 * sum / _correctWord.Length;
        }
    }
}
