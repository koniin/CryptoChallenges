using System;

namespace CryptoChallenges
{
    public class Converter
    {
        public byte[] XorBytes(byte[] x1, byte[] x2) {
            byte[] bytes = new byte[x1.Length];

            for (int i = 0; i < x1.Length; i++)
                bytes[i] = (byte) (x1[i] ^ x2[i]);
            return bytes;
        }

        public byte[] ConvertHexStringToByteArray(string hex) {
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

        public string ConvertByteArrayToHexString(byte[] bytes) {
            if (bytes.Length == 0) {
                throw new ArgumentException("bytes empty");
            }
            return BitConverter.ToString(bytes).Replace("-", string.Empty);
        }

        public byte[] GetByteArrayFilledWithCharacter(char c, int length) {
            byte[] bytes = new byte[length];
            for (int i = 0; i < length; i++) {
                bytes[i] = Convert.ToByte(c);
            }
            return bytes;
        }
    }
}
