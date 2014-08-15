using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoChallenges
{
    class Program
    {
        static void Main(string[] args) {
            Challenge1();
            Challenge2();
            Challenge3();

            Console.ReadLine();
        }

        private static void Challenge1() {
            string hex = "49276d206b696c6c696e6720796f757220627261696e206c696b65206120706f69736f6e6f7573206d757368726f6f6d";
            string result = "SSdtIGtpbGxpbmcgeW91ciBicmFpbiBsaWtlIGEgcG9pc29ub3VzIG11c2hyb29t";
            byte[] bytes = Converter.ConvertHexStringToByteArray(hex);
            Writer.WriteResult(result, Convert.ToBase64String(bytes));
        }

        private static void Challenge2() {
            string xor1 = "1c0111001f010100061a024b53535009181c";
            string xor2 = "686974207468652062756c6c277320657965";
            string result = "746865206b696420646f6e277420706c6179";

            string calcResult = Converter.ConvertByteArrayToHexString(Converter.XorBytes(Converter.ConvertHexStringToByteArray(xor1), Converter.ConvertHexStringToByteArray(xor2)));
            Writer.WriteResult(result, calcResult);
        }

        private static void Challenge3() {
            // find the key decrypt the message (xor'd against one character)
            string input = "1b37373331363f78151b7f2b783431333d78397828372d363c78373e783a393b3736";

            byte[] bytes = Converter.ConvertHexStringToByteArray(input);
            
            // 65 - 90 upper case
            // 97 - 122 lower case
            string highestScored = string.Empty, current = string.Empty;
            int highScore = 0, score = 0;
            for (int i = 65; i <= 122; i++) {
                current = Encoding.ASCII.GetString(Converter.XorBytes(Converter.GetByteArrayFilledWithCharacter((char) i, bytes.Length), bytes));
                score = Converter.ScoreStringForEnglish(current);
                if (score > highScore) {
                    highestScored = current;
                    highScore = score;
                }
            }

            Console.WriteLine(highestScored);
        }
    }
}
