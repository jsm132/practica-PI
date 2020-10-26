using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Server.KeyManager
{
    class KeyManager
    {
        public static string getHash(string password, string salt)
        {
            SHA256 mysha256 = SHA256.Create();
            string saltedPassword = password + salt;

            byte[] hash = mysha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));

            return byteToString(hash);
        }

        public static string getSalt()
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            return byteToString(salt);
        }

        private static string byteToString(byte[] bytes) 
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
