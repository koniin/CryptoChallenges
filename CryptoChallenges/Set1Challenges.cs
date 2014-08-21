using System;
using System.IO;
using System.Text;

namespace CryptoChallenges
{
    public class Set1Challenges
    {
        private readonly Converter converter = new Converter();
        private readonly LanguageScore languageScore = new LanguageScore();
        
        public void Challenge1()
        {
            string hex = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d";
            string result = "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t";
            byte[] bytes = converter.ConvertHexStringToByteArray(hex);
            Writer.WriteResult(result, Convert.ToBase64String(bytes));
        }

        // Write a function that takes two equal-length buffers and produces their XOR combination.
        public void Challenge2()
        {
            string xor1 = "1c0111001f010100061a024b53535009181c";
            string xor2 = "686974207468652062756c6c277320657965";
            string result = "746865206b696420646f6e277420706c6179";

            string calcResult = converter.ConvertByteArrayToHexString(converter.XorBytes(converter.ConvertHexStringToByteArray(xor1), converter.ConvertHexStringToByteArray(xor2)));
            Writer.WriteResult(result, calcResult);
        }

        public void Challenge3()
        {
            // find the key decrypt the message (xor'd against one character)
            string input = "1b37373331363f78151b7f2b783431333d78397828372d363c78373e783a393b3736";

            byte[] bytes = converter.ConvertHexStringToByteArray(input);

            var highestScored = GetHighestScored(bytes);

            Console.WriteLine(highestScored);
        }

        private string GetHighestScored(byte[] bytes) {
            // 65 - 90 upper case
            // 97 - 122 lower case
            string highestScored = string.Empty, current = string.Empty;
            char xorCharacterHighestScored = ' ';
            int highScore = 0, score = 0;
            for (int i = 65; i <= 122; i++) {
                current = Encoding.ASCII.GetString(converter.XorBytes(converter.GetByteArrayFilledWithCharacter((char)i, bytes.Length), bytes));
                score = languageScore.ScoreStringForEnglish(current);
                if (score > highScore) {
                    highestScored = current;
                    highScore = score;
                    xorCharacterHighestScored = (char) i;
                }
            }
            Console.WriteLine(xorCharacterHighestScored);
            return highestScored;
        }

        /*
         * One of the 60-character strings in this file has been encrypted by single-character XOR.
           Find it.
           (Your code from #3 should help.)
         */
        public void Challenge4() {
            string[] data = File.ReadAllLines(".\\4.txt");

            foreach (string input in data) {
                byte[] bytes = converter.ConvertHexStringToByteArray(input);
                var highestScored = GetHighestScored(bytes);
                if(highestScored != string.Empty) 
                    Console.WriteLine(highestScored);
            }
        }
    }
}
