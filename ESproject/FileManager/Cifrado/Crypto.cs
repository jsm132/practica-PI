using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ESproject.Cifrado
{
    public class Crypto {
        SymmetricAlgorithm algorithm;
        public byte[] key;
        public byte[] IV;

        public Crypto(string algorithmString, byte[] key) {
            algorithm = SymmetricAlgorithm.Create(algorithmString);
            this.key = key;
            this.IV = SHA256.Create().ComputeHash(key).Take(key.Length / 2).ToArray();
        }

        public byte[] encryptFile(byte[] file) {
            return cryptoFile(file, algorithm.CreateEncryptor(key, IV));
        }
        public byte[] decryptFile(byte[] file) {
            return cryptoFile(file, algorithm.CreateDecryptor(key, IV));
        }

        private byte[] cryptoFile(byte[] file, ICryptoTransform cryptoOperation) {
            using (MemoryStream msOut = new MemoryStream()) {
                using (CryptoStream encStream = new CryptoStream(msOut, cryptoOperation, CryptoStreamMode.Write)) {
                    encStream.Write(file, 0, file.Length);
                    encStream.FlushFinalBlock();
                    return msOut.ToArray();
                }
            }
        }
    }
}

/*
 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ESproject.Cifrado
{
    class Encrypt {
        SymmetricAlgorithm algorithm;

        public Encrypt(string algorithmString) {
            this.algorithm = SymmetricAlgorithm.Create(algorithmString);
        }

        public byte[] encryptFile(string inName, string outName, byte[] key, byte[] iv) {
            FileStream fin = new FileStream(inName, FileMode.Open, FileAccess.Read);
            FileStream fout = new FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write);
            fout.SetLength(0);
            //Create variables to help with read and write.
            byte[] bin = new byte[100]; //This is intermediate storage for the encryption.
            long rdlen = 0;              //This is the total number of bytes written.
            long totlen = fin.Length;    //This is the total length of the input file.
            int len;                     //This is the number of bytes to be written at a time.

            CryptoStream encStream = new CryptoStream(fout, algorithm.CreateEncryptor(key, iv), CryptoStreamMode.Write);

            Console.WriteLine("Encrypting...");

            //Read from the input file, then encrypt and write to the output file.
            while (rdlen < totlen) {
                len = fin.Read(bin, 0, 100);
                encStream.Write(bin, 0, len);
                rdlen = rdlen + len;
                Console.WriteLine("{0} bytes processed", rdlen);
            }

            encStream.Close();
            fout.Close();
            fin.Close();

            byte[] cif = null;
            return cif;
        }
        public byte[] decryptFile(string inName, string outName, byte[] key, byte[] iv) {
            FileStream fin = new FileStream(inName, FileMode.Open, FileAccess.Read);
            FileStream fout = new FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write);
            fout.SetLength(0);
            //Create variables to help with read and write.
            byte[] bin = new byte[100]; //This is intermediate storage for the encryption.
            long rdlen = 0;              //This is the total number of bytes written.
            long totlen = fin.Length;    //This is the total length of the input file.
            int len;                     //This is the number of bytes to be written at a time.

            CryptoStream encStream = new CryptoStream(fout, algorithm.CreateDecryptor(key, iv), CryptoStreamMode.Write);

            Console.WriteLine("Encrypting...");

            //Read from the input file, then encrypt and write to the output file.
            while (rdlen < totlen) {
                len = fin.Read(bin, 0, 100);
                encStream.Write(bin, 0, len);
                rdlen = rdlen + len;
                Console.WriteLine("{0} bytes processed", rdlen);
            }

            encStream.Close();
            fout.Close();
            fin.Close();

            byte[] cif = null;
            return cif;
        }
    }
}

 */
