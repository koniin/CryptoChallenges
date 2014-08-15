using System;
using System.Linq;

namespace CryptoChallenges
{
    public static class Converter
    {
        public static byte[] XorBytes(byte[] x1, byte[] x2) {
            byte[] bytes = new byte[x1.Length];

            for (int i = 0; i < x1.Length; i++)
                bytes[i] = (byte) (x1[i] ^ x2[i]);
            return bytes;
        }

        public static byte[] ConvertHexStringToByteArray(string hex) {
            if (hex.Length%2 != 0) {
                throw new ArgumentException(string.Format("The binary key cannot have an odd number of digits: {0}", hex));
            }

            int charCount = hex.Length;
            byte[] bytes = new byte[charCount/2];
            for (int i = 0; i < charCount; i += 2) {
                bytes[i/2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

        public static string ConvertByteArrayToHexString(byte[] bytes) {
            if (bytes.Length == 0) {
                throw new ArgumentException("bytes empty");
            }
            return BitConverter.ToString(bytes).Replace("-", string.Empty);
        }

        public static byte[] GetByteArrayFilledWithCharacter(char c, int length)
        {
            byte[] bytes = new byte[length];
            for (int i = 0; i < length; i++) {
                bytes[i] = Convert.ToByte(c);
            }
            return bytes;
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
        public static int ScoreStringForEnglish(string input)
        {
            string lowered = input.ToLower();
            return //lowered.Count(c => c == 'a') +
                //lowered.Count(c => c == 'e') +
                //lowered.Count(c => c == 'h') +
                //lowered.Count(c => c == 'i') +
                //lowered.Count(c => c == 'n') + 
                   lowered.Count(c => c == 'o');
            //lowered.Count(c => c == 's') +
            //lowered.Count(c => c == 't');
        }
    }
}
