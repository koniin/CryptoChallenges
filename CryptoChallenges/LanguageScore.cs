using System.Collections.Generic;

namespace CryptoChallenges
{
    public class LanguageScore
    {
        private readonly Dictionary<char, double> englishLetterFreq = new Dictionary<char, double> { { 'E', 12.70 }, { 'T', 9.06 }, { 'A', 8.17 }, { 'O', 7.51 }, { 'I', 6.97 }, { 'N', 6.75 }, { 'S', 6.33 }, { 'H', 6.09 }, { 'R', 5.99 }, { 'D', 4.25 }, { 'L', 4.03 }, { 'C', 2.78 }, { 'U', 2.76 }, { 'M', 2.41 }, { 'W', 2.36 }, { 'F', 2.23 }, { 'G', 2.02 }, { 'Y', 1.97 }, { 'P', 1.93 }, { 'B', 1.29 }, { 'V', 0.98 }, { 'K', 0.77 }, { 'J', 0.15 }, { 'X', 0.15 }, { 'Q', 0.10 }, { 'Z', 0.07 } };

        public int SimpleScoreStringForEnglish(string input) {
            double score = 0;
            foreach (char c in input.ToUpper()) {
                if (c == ' ' || c == '\0')
                    continue;
                if (englishLetterFreq.ContainsKey(c))
                    score += englishLetterFreq[c];
                else
                    score -= 10;
            }
            return (int)score;
        }

        /*
         * 
            Letter	Relative frequency in the English language
              a	8.167%	
                b	1.492%	
                c	2.782%	
                d	4.253%	
              e	13.0001%	
                f	2.228%	
                g	2.015%	
              h	6.094%	
              i	6.966%	
                j	0.153%	
                k	0.772%	
                l	4.025%	
                m	2.406%	
              n	6.749%	
              o	7.507%	
                p	1.929%	
                q	0.095%	
                r	5.987%	
              s	6.327%	
              t	9.056%	
                u	2.758%	
                v	0.978%	
                w	2.360%	
                x	0.150%	
                y	1.974%	
                z	0.074%	
             */
        /*
        public  int ScoreStringForEnglish(string input)
        {
            string lowered = input.ToLower();
            return //lowered.Count(c => c == 'a') +
                //lowered.Count(c => c == 'e') +
                //lowered.Count(c => c == 'h') +
                //lowered.Count(c => c == 'i') +
                //lowered.Count(c => c == 'n') + 
                lowered.Count(c => c == ' ') +
                   lowered.Count(c => c == 'o');
            //lowered.Count(c => c == 's') +
            //lowered.Count(c => c == 't');
        }
        */
    }
}
