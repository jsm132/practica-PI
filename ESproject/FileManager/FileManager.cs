using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using ESproject.Cifrado;
using Newtonsoft.Json;

namespace ESproject {
    class FileManager {
        //Crypto crypto;//queda por ver como se va a implmentar concretamente
        public static string UploadFile(string fileName) {
            //Cargo archivo
            byte[] file = File.ReadAllBytes(fileName);
            Console.WriteLine("Tamaño del archivo: " + file.Length.ToString());
            //preparo json
            Messages.ClientMessage message = new ESproject.Messages.ClientMessage {
                action = "upload"
            };
            message.message.Add("fileSize", file.Length.ToString());
            message.message.Add("fileName", fileName);
            string uploadMsg = JsonConvert.SerializeObject(message);
            //abro comunicación
            Cliente.RunClient("localhost", "DESKTOP-IKVSN1R");
            string uploadStr = Cliente.WriteMessage(uploadMsg);
            Console.WriteLine(uploadStr);
            uploadStr = Cliente.WriteBytes(file);
            Cliente.closeConnection();
            return uploadStr;
        }
        public static string UploadFile(byte[] file, string fileName, Crypto cipher, string action="upload", bool crypto=true) {
            Console.WriteLine("Tamaño del archivo: " + file.Length.ToString());
            //preparo json
            Messages.ClientMessage message = new Messages.ClientMessage {
                action = action
            };
            message.message.Add("fileSize", file.Length.ToString());
            message.message.Add("fileName", fileName);
            message.message.Add("user", User.getName());
            string uploadMsg = JsonConvert.SerializeObject(message);
            //abro comunicación
            Cliente.RunClient("localhost", "DESKTOP-IKVSN1R");
            string uploadStr = Cliente.WriteMessage(uploadMsg);
            Console.WriteLine(uploadStr);
            if (crypto) {
                file = cipher.encryptFile(file);
            }
            uploadStr = Cliente.WriteBytes(file);
            Cliente.closeConnection();
            return uploadStr;
        }

        public static byte[] DownloadFile(string fileName, Crypto cipher, bool crypto = true, string action="download") {
            //preparo json
            Messages.ClientMessage message = new Messages.ClientMessage { action = action };
            message.message.Add("fileName", fileName);
            message.message.Add("user", User.getName());
            string downloadMsg = JsonConvert.SerializeObject(message);
            //abro comunicación
            Cliente.RunClient("localhost", "DESKTOP-IKVSN1R");
            string numBytes = Cliente.WriteMessage(downloadMsg);
            byte[] fileBytes = Cliente.ReadBytes(int.Parse(numBytes));
            Cliente.closeConnection();
            //File.WriteAllBytes(fileName, fileBytes);
            Console.WriteLine(fileBytes.Length + " bytes downloaded");
            if (crypto) {
                fileBytes = cipher.decryptFile(fileBytes);
            }
            return fileBytes;
        }

        public static byte[] DownloadFileShared(string user, string fileName, Crypto cipher, bool crypto = true, string action = "download")
        {
            //preparo json
            Messages.ClientMessage message = new Messages.ClientMessage { action = action };
            message.message.Add("fileName", fileName);
            message.message.Add("user", user);
            string downloadMsg = JsonConvert.SerializeObject(message);
            //abro comunicación
            Cliente.RunClient("localhost", "DESKTOP-IKVSN1R");
            string numBytes = Cliente.WriteMessage(downloadMsg);
            byte[] fileBytes = Cliente.ReadBytes(int.Parse(numBytes));
            Cliente.closeConnection();
            //File.WriteAllBytes(fileName, fileBytes);
            Console.WriteLine(fileBytes.Length + " bytes downloaded");
            if (crypto)
            {
                fileBytes = cipher.decryptFile(fileBytes);
            }
            return fileBytes;
        }
    }
}
