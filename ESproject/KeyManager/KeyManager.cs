using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace ESproject.KeyManager
{
    class KeyManager
    {
        public static byte[] getHash(string password)
        {
            SHA256 mysha256 = SHA256.Create();

            byte[] hash = mysha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            return hash;
        }

        public static string getLoginKey(byte[] hash)
        {
            byte[] keyLogin = hash.Take(hash.Length / 2).ToArray();

            return byteToString(keyLogin);
        }

        public static byte[] getCipherKey(byte[] hash)
        {
            byte[] keyCipher = hash.Skip(hash.Length / 2).ToArray();
            return keyCipher;
            //return byteToString(keyCipher);
        }

        public static string byteToString(byte[] bytes)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
