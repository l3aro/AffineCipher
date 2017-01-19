using System;
using System.Collections.Generic;
using System.Text;

namespace AffineCipher
{
    class AffineCipher
    {
        private Dictionary<byte, byte> inverseTable;
        private byte a;
        private byte a1;
        private byte b;

        public AffineCipher()
        {
            // import inverse data table
            inverseTable = new Dictionary<byte, byte>();
            inverseTable.Add(1, 1);
            inverseTable.Add(3, 9);
            inverseTable.Add(5, 21);
            inverseTable.Add(7, 15);
            inverseTable.Add(9, 3);            
            inverseTable.Add(11, 19);
            inverseTable.Add(15, 7);
            inverseTable.Add(19, 11);
            inverseTable.Add(21, 5);
            inverseTable.Add(23, 17);
            inverseTable.Add(25, 25);

            Random rnd = new Random();

            bool isContinueRandom = true;
            
            while(isContinueRandom)
            {
                a = (byte)rnd.Next(1, 25);
                if (inverseTable.ContainsKey(a))
                    isContinueRandom = false;
            }

            a1 = inverseTable[a];

            b = (byte)rnd.Next(1, 26);
        }
        
        public byte[] GetEncryptKey()
        {
            return new byte[] { a, b };
        }            
        
        public byte[] GetDecryptKey()
        {
            return new byte[] { a1, b };
        }

        // Remove characters not in Z26 alphabet
        public string RemoveNonZ26(string raw)
        {
            raw = raw.ToUpper();
            do
            {
                int i = 0;
                for (; i < raw.Length; i++)
                {
                    int ch = (int)raw[i];
                    if (ch < 65 || ch > 90)
                    {
                        raw = raw.Remove(i, 1);
                        break;
                    }
                }
                if (i == raw.Length)
                {
                    break;
                }
            }
            while (true);

            return raw;

        }

        public string Encrypt(string plaintext, byte[] encryptKey)
        {
            plaintext = RemoveNonZ26(plaintext);

            // bind string into an array of bytes
            byte[] toAlphabetNumber = Encoding.ASCII.GetBytes(plaintext);

            for (int index = 0; index < toAlphabetNumber.Length; index++)
            {
                byte token = (byte)(toAlphabetNumber[index] - 65); // minus by 65 to back to Alphabet code context

                token = (byte)((encryptKey[0] * token + encryptKey[1]) % 26);

                token += 65; // plus by 65 to back to ASCII character

                toAlphabetNumber[index] = token;
            }

            // bind array into a string
            string result = Encoding.ASCII.GetString(toAlphabetNumber);

            return result;
        }

        public string Decrypt(string encrypted, byte[] decryptKey)
        {
            encrypted = RemoveNonZ26(encrypted);

            byte[] toAlphabetNumber = Encoding.ASCII.GetBytes(encrypted);

            for (int index = 0; index < toAlphabetNumber.Length; index++)
            {
                int token = (toAlphabetNumber[index] - 65); // minus by 65 to back to Alphabet code context

                token = ((token - decryptKey[1]) * decryptKey[0] % 26);

                if (token < 0)
                {
                    token = 26 + token;
                }

                token += 65; // plus by 65 to back to ASCII character

                toAlphabetNumber[index] = (byte)token;
            }

            string result = Encoding.ASCII.GetString(toAlphabetNumber);

            return result;
        }
    }
}
