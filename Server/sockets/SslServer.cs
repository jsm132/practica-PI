﻿using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Authentication;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using ESproject._2sv;
using System.Diagnostics;
using Server._2FA;
using Server.User;
using System.Security.Cryptography;
using Server.KeyManager;
using Newtonsoft.Json.Serialization;

namespace Server {
    public class SslServer {
        static X509Certificate serverCertificate = null;
        static SslStream sslStream;
        public static void RunServer(string certificate) {
            serverCertificate = new X509Certificate2(certificate, "rextore", X509KeyStorageFlags.MachineKeySet);
            TcpListener listener = new TcpListener(IPAddress.Any, 8080);
            listener.Start();
            while (true) {
                Console.WriteLine("Waiting for a client to connect...");
                TcpClient client = listener.AcceptTcpClient();
                ProcessClient(client);
            }
        }
        static void ProcessClient(TcpClient client) {
            sslStream = new SslStream(client.GetStream(), false);
            try {
                sslStream.AuthenticateAsServer(serverCertificate, clientCertificateRequired: false, SslProtocols.Default ,checkCertificateRevocation: true);
                // Set timeouts for the read and write to 5 seconds.
                //sslStream.ReadTimeout = 5000;
                //sslStream.WriteTimeout = 5000;
                // Read a message from the client.   
                while (true) { //Igual que el código anterior, solo que ahora itera en un bucle para escuchar todos los mensajes que el cliente le manda, hasta que este cierra la sesión
                    Console.WriteLine("Waiting for client message...");
                    string messageData = ReadMessage();
                    Console.WriteLine("Received: {0}", messageData);
                    // procesa el mensaje para obtener la acción 
                    if (messageData.Equals("close")) return;
                    ProcessMessage(messageData);
                }

            } catch (AuthenticationException e) {
                Console.WriteLine("Exception: {0}", e.Message);
                if (e.InnerException != null) {
                    Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
                }
                Console.WriteLine("Authentication failed - closing the connection.");
                sslStream.Close();
                client.Close();
                return;
            } finally {
                sslStream.Close();
                client.Close();
            }
        }
        static void ProcessMessage(string message)
        {
            try {
                Console.WriteLine(message);
                Server.Messages.ServerMessage clientMessage = JsonConvert.DeserializeObject<Server.Messages.ServerMessage>(message);

                switch (clientMessage.action) {
                    case "retrieveSharedBackups":
                        retrieveSharedBackups(clientMessage.message["user"]);
                        break;
                    case "register":
                        Register(clientMessage.message["mail"], clientMessage.message["password"]);
                        break;
                    case "shareBackup":
                        shareBackup(clientMessage.message["currentUser"], clientMessage.message["backupName"], clientMessage.message["userShare"]);
                        break;
                    case "login":
                        Login(clientMessage.message["mail"], clientMessage.message["password"], clientMessage.message["secondFA"], clientMessage.message["telegramUser"]);
                        break;
                    case "activate2FA":
                        Activate2FA(clientMessage.message["mail"], clientMessage.message["telegramUser"]);
                        break;
                    case "check2FAStatus":
                        check2FAStatus(clientMessage.message["mail"]);
                        break;
                    case "backupAdd":
                        backupAdd(clientMessage.message["name"], clientMessage.message["user"], clientMessage.message["key"]);
                        break;
                    case "requestKey":
                        requestKey(clientMessage.message["name"], clientMessage.message["user"]);
                        break;
                    case "requestSharing":
                        requestSharing(clientMessage.message["name"], clientMessage.message["user"]);
                        break;
                    case "getTelegramUsername":
                        getTelegramUsername(clientMessage.message["mail"]);
                        break;
                    case "upload":
                        SaveFile(Int32.Parse(clientMessage.message["fileSize"]), clientMessage.message["fileName"], clientMessage.message["user"]);
                        break;
                    case "download":
                        SendFile(clientMessage.message["fileName"], clientMessage.message["user"], "backups");
                        break;
                    case "schedule":
                        Schedule(clientMessage.message["file"], clientMessage.message["user"]);
                        break;
                    case "downloadSchedule":
                        downloadSchedule(clientMessage.message["user"]);
                        break;
                    case "storeBackupMetadata":
                        StoreMetadata(Int32.Parse(clientMessage.message["fileSize"]), clientMessage.message["fileName"], clientMessage.message["user"]);
                        break;
                    case "storeWork":
                        StoreWork(Int32.Parse(clientMessage.message["fileSize"]), clientMessage.message["fileName"], clientMessage.message["user"]);
                        break;
                    case "downloadWork":
                        SendFile(clientMessage.message["fileName"], clientMessage.message["user"], "works");
                        break;
                    case "downloadBackupList":
                        SendBackupList(clientMessage.message["user"]);
                        break;
                    case "downloadBackupListShared":
                        SendBackupListShared(clientMessage.message["user"]);
                        break;
                    case "downloadWorkList":
                        SendWorkList(clientMessage.message["user"]);
                        break;
                    default:
                        Console.WriteLine("Comando desconocido");
                        break;
                }
            }
            catch(Exception e) {
                Console.WriteLine(e);
            }
        }

        //Funciones del servidor
        static void SendBackupList(string user) {
            string path = "backups/" + user + "/";
            System.IO.Directory.CreateDirectory(path);
            WriteMessage(JsonConvert.SerializeObject(Directory.GetFiles(path)));
        }

        static void SendBackupListShared(string user)
        {

            string pathKeys = "Database/" + user + "/keys.json";
            List<key> keys = new List<key>();
            string jsonFile = System.IO.File.ReadAllText(pathKeys);
            keys = JsonConvert.DeserializeObject<List<key>>(jsonFile);
            List<string> sharing = new List<string>();
            foreach (key k in keys)
            {
                if(k.sharedWith.Count > 0)
                {
                    sharing.Add(k.backup);
                }
            }

            WriteMessage(String.Join(", ", sharing.ToArray()));
        }

        static void retrieveSharedBackups(string user) //comprueba en cada carpeta de usuario, si contiene algú backup que comparta con el usuario que llama a este método
        {
            List<string> shares = new List<string>();

            string pathUsers = "Database\\users.json";
            string jsonFile = System.IO.File.ReadAllText(pathUsers);
            List<User.User> users = new List<User.User>();
            users = JsonConvert.DeserializeObject<List<User.User>>(jsonFile);

            foreach (User.User checkUser in users)
            {
                string pathKeys = "Database/" + checkUser.mail + "/keys.json";
                string jsonFileKeys = System.IO.File.ReadAllText(pathKeys);
                List<key> keys = new List<key>();
                keys = JsonConvert.DeserializeObject<List<key>>(jsonFileKeys);

                foreach (key k in keys)
                {
                    if(k != null){
                        List<string> sharings = k.sharedWith;
                        if (sharings.Count > 0)
                        {
                            foreach (string s in sharings)
                            {

                                if (s.Equals(user))
                                {
                                    shares.Add(checkUser.mail + "/" + k.backup);
                                }
                            }
                        }
                    }
                }
            }
            WriteMessage(String.Join(",", shares.ToArray()));
        }

        static void shareBackup(string currentUser, string backupName, string userShare)
        {
            bool registered = false;
            string pathKeys = "Database/" + currentUser + "/keys.json";
            string pathUsers = "Database\\users.json";

            string jsonFile = System.IO.File.ReadAllText(pathUsers);
            string jsonFileKeys = System.IO.File.ReadAllText(pathKeys);

            List<User.User> users = new List<User.User>();
            List<key> keys = new List<key>();
            users = JsonConvert.DeserializeObject<List<User.User>>(jsonFile);
            keys = JsonConvert.DeserializeObject<List<key>>(jsonFileKeys);

            foreach (User.User user in users)
            {
                if (user.mail.Equals(userShare))
                    registered = true;
            }

            if(registered == true)
            {
                foreach(key k in keys)
                {
                    if(k.backup == backupName)
                    {
                       k.sharedWith.Add(userShare);
                    }
                }

                string keyJson = JsonConvert.SerializeObject(keys);
                File.WriteAllText(pathKeys, keyJson);

                WriteMessage("Backup compartido.");
            }
            else
            {
                WriteMessage("El usuario especificado para compartir no existe.");
            }

            
        }

        static void backupAdd(string name, string user, string key)
        {
            string pathKeys = "Database/" + user + "/keys.json";
            List<key> keys = new List<key>();
            string jsonFile = System.IO.File.ReadAllText(pathKeys);
            keys = JsonConvert.DeserializeObject<List<key>>(jsonFile);
            

            key clave = new key(name, key, new List<string>());
            

            keys.Add(clave);

            string keyJson = JsonConvert.SerializeObject(keys);

            System.IO.File.WriteAllText(pathKeys, keyJson);

            WriteMessage("key añadida");
        }

        static void requestKey(string name, string user)
        {
            string pathKeys = "Database/" + user + "/keys.json";
            List<key> keys = new List<key>();
            string jsonFile = System.IO.File.ReadAllText(pathKeys);
            keys = JsonConvert.DeserializeObject<List<key>>(jsonFile);
            string value = "";
            foreach (key k in keys)
            {
                if(name == k.backup)
                {
                    value = k.value;
                }
            }

            WriteMessage(value);
        }

        static void requestSharing(string name, string user)
        {
            string pathKeys = "Database/" + user + "/keys.json";
            List<key> keys = new List<key>();
            string jsonFile = System.IO.File.ReadAllText(pathKeys);
            keys = JsonConvert.DeserializeObject<List<key>>(jsonFile);
            List<string> sharing = new List<string>();
            foreach (key k in keys)
            {
                if (name == k.backup)
                {
                    sharing = k.sharedWith;
                }
            }

            WriteMessage(String.Join(", ", sharing.ToArray()));
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
        static void SendWorkList(string user) {
            string path = "works/" + user + "/";
            System.IO.Directory.CreateDirectory(path);
            WriteMessage(JsonConvert.SerializeObject(Directory.GetFiles(path)));
        }
        static void StoreWork(int fileSize, string fileName, string user) {
            WriteMessage("Starting Download...");
            byte[] file = ReceiveFile(fileSize);
            string path = "works/" + user + "/";
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            File.WriteAllBytes(path + fileName, file);
            WriteMessage("Download Completed");
        }
        static void StoreMetadata(int fileSize, string fileName, string user) {
            WriteMessage("Starting Download...");
            byte[] file = ReceiveFile(fileSize);
            string path = "backups/" + user + "/meta/";
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            File.WriteAllBytes(path + fileName, file);
            WriteMessage("Download Completed");
        }
        static void SendFile(string fileName, string user, string path) {
            byte[] file = File.ReadAllBytes(path + "/" + user + "/" + fileName);
            WriteMessage(file.Length.ToString());
            WriteBytes(file);
        }

        static void SaveFile(int fileSize, string fileName, string user) {
            WriteMessage("Starting Download...");
            byte[] file = ReceiveFile(fileSize);
            string path = "backups/"+user+"/";
            if (!Directory.Exists(path)) {
                Directory.CreateDirectory(path);
            }
            File.WriteAllBytes(path + fileName, file);
            WriteMessage("Download Completed");
        }

        static void downloadSchedule(string user)
        {
            string path = "Database\\" + user + "\\plans.json";

            if (File.Exists(path))
            {
                string serverMessage = File.ReadAllText(path);
                WriteMessage(serverMessage);
            }
            else
            {
                WriteMessage("No hay planes para este usuario");
            }
        }

        static void Schedule(string jsonFile, string user)
        {
            string path = "Database\\" + user;

            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                    using (FileStream fs = File.Create(path + "\\plans.json"))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes("[]");
                        
                        fs.Write(info, 0, info.Length);
                    }
                }

                System.IO.File.WriteAllText(path + "\\plans.json", jsonFile);
                WriteMessage("Transferencia correcta");
            }
            catch (Exception e)
            {
                WriteMessage("Transferencia incorrecta");
            }
        }

        static void Register(string mail, string password) 
        {
            // comprobar si el mail está registrado            
            string pathUser = "Database\\users.json";
            string pathSalt = "Database\\salts.json";
            string pathKeys = "Database\\" + mail;
            string serverMessage;
            bool registered = false;
            List<User.User> users = new List<User.User>();
            List<User.Salt> salts = new List<User.Salt>();

            string jsonFile = System.IO.File.ReadAllText(pathUser);
            string jsonSalt = System.IO.File.ReadAllText(pathSalt);

            if (!Directory.Exists(pathKeys))
            {
                Directory.CreateDirectory(pathKeys);
                using (FileStream fs = File.Create(pathKeys + "\\keys.json"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("[]");
                    fs.Write(info, 0, info.Length);
                }
            }

            if (jsonFile.Length > 0 && jsonSalt.Length > 0)
            {
                users = JsonConvert.DeserializeObject<List<User.User>>(jsonFile);
                salts = JsonConvert.DeserializeObject<List<User.Salt>>(jsonSalt);

                foreach (User.User user in users)
                {
                    if (user.mail.Equals(mail))
                        registered = true;
                }
            } 
            else 
            {
                File.WriteAllText(pathUser, "[]");
                File.WriteAllText(pathSalt, "[]");
            }

            if(registered)
            {
                serverMessage = "Usuario ya registrado";
            }
            else // guardamos el usuario con sus datos
            {
                // obtenemos la sal y la concatenamos al password para hacer el hash
                string salt = KeyManager.KeyManager.getSalt();
                password = KeyManager.KeyManager.getHash(password, salt);

                User.Salt userSalt = new User.Salt(mail, salt);
                User.User user = new User.User(mail, password, "NO", "");

                users.Add(user);
                salts.Add(userSalt);

                string userJson = JsonConvert.SerializeObject(users);
                string saltJson = JsonConvert.SerializeObject(salts);

                System.IO.File.WriteAllText(pathUser, userJson);
                System.IO.File.WriteAllText(pathSalt, saltJson);

                serverMessage = "Usuario registrado con éxito";
            }
 
            WriteMessage(serverMessage);
        }

        static void Activate2FA(string mail, string telegramUser)
        {
            bool userFound = false;
            User.User UserToModify = null;
            User.User modifiedUser = null;
            string serverMessage = "";
            string pathUser = "Database\\users.json";
            List<User.User> users = new List<User.User>();
            string jsonFile = System.IO.File.ReadAllText(pathUser);

            if(jsonFile.Length > 0)
            {
                users = JsonConvert.DeserializeObject<List<User.User>>(jsonFile);

                foreach (User.User user in users)
                {
                    if (user.mail.Equals(mail))
                    {
                        userFound = true;
                        UserToModify = user;
                        modifiedUser = new User.User(user.mail, user.password, "YES", telegramUser);
                        serverMessage = "Segundo factor activado";
                    }
                }

                if(userFound == true)
                {
                    users.Remove(UserToModify);
                    users.Add(modifiedUser);
                    string userJson = JsonConvert.SerializeObject(users);
                    System.IO.File.WriteAllText(pathUser, userJson);
                }
                else
                {
                    serverMessage = "Error inesperado, el usuario actual no existe.";
                }
            }
            else
            {
                serverMessage = "Error, no existe ningún usuario en la base de datos";
            }

            WriteMessage(serverMessage);
        }

        static void check2FAStatus(string mail)
        {
            string serverMessage = "";
            string pathUser = "Database\\users.json";
            List<User.User> users = new List<User.User>();
            string jsonFile = System.IO.File.ReadAllText(pathUser);

            if (jsonFile.Length > 0)
            {
                users = JsonConvert.DeserializeObject<List<User.User>>(jsonFile);

                foreach (User.User user in users)
                {
                    if (user.mail.Equals(mail))
                    {
                        if (user.activated2FA.Equals("YES"))
                        {

                            serverMessage = "El segundo factor de autenticación está activado para este usuario.";
                        }
                        else
                        {
                            serverMessage = "El segundo factor de autenticación NO está activado para este usuario.";
                        }
                    }
                }
            }
            else
            {
                serverMessage = "Error, no existe ningún usuario en la base de datos";
            }

            WriteMessage(serverMessage);
        }

        static void getTelegramUsername(string mail)
        {
            string serverMessage = "";
            string pathUser = "Database\\users.json";
            List<User.User> users = new List<User.User>();
            string jsonFile = System.IO.File.ReadAllText(pathUser);

            if (jsonFile.Length > 0)
            {
                users = JsonConvert.DeserializeObject<List<User.User>>(jsonFile);

                foreach (User.User user in users)
                {
                    if (user.mail.Equals(mail))
                    {
                        serverMessage = user.telegramUser;

                    }
                }
            }
            else
            {
                serverMessage = "Error, no existe ningún usuario en la base de datos";
            }

            WriteMessage(serverMessage);
        }

        static void Login(string mail, string password, string secondFA, string telegramUser)
        {         
            string pathUser = "Database\\users.json";
            string pathSalt = "Database\\salts.json";
            bool registered = false;
            string serverMessage, userPassword = "", userMail = "", sal = "";
            List<User.User> users = new List<User.User>();
            List<User.Salt> salts = new List<User.Salt>();

            string jsonFile = System.IO.File.ReadAllText(pathUser);
            string jsonSalt = System.IO.File.ReadAllText(pathSalt);

            if (jsonFile.Length > 0 && jsonSalt.Length > 0)
            {
                users = JsonConvert.DeserializeObject<List<User.User>>(jsonFile);
                salts = JsonConvert.DeserializeObject<List<User.Salt>>(jsonSalt);

                foreach (User.User user in users)
                {
                    if (user.mail.Equals(mail))
                    {
                        registered = true;
                        userMail = user.mail;
                        userPassword = user.password;
                    }
                }
                foreach (User.Salt salt in salts)
                {
                    if(salt.mail.Equals(mail))
                    {
                        sal = salt.salt;
                    }
                }
            }
            // hacemos el hash del password+sal y comprobamos si coincide
            password = KeyManager.KeyManager.getHash(password, sal);

            if (userMail.Equals(mail) && userPassword.Equals(password) && registered)
            {

                serverMessage = "Login correcto";
                
                WriteMessage(serverMessage);

                if (secondFA.Equals("YES"))
                {
                    TelegramBot bot = new TelegramBot();
                    SecondStep ss = new SecondStep();
                    bot.init(ss.getCode(), telegramUser);
                    while (true)
                    {
                        
                        string codeStep = ReadMessage();
                        Server.Messages.ServerMessage clientMessage = JsonConvert.DeserializeObject<Server.Messages.ServerMessage>(codeStep);

                        if (ss.checkCode(clientMessage.message["code"]))
                        {
                            WriteMessage("El código es correcto");
                            break;
                        }
                        else
                            WriteMessage("El código es incorrecto");
                    }
                    bot.botStop();
                }
                
            }
            else // el login ha fallado
            {
                serverMessage = "El usuario o la contraseña no son correctos";
                WriteMessage(serverMessage);
            }         
        }

        //Funciones de sockets y auxiliares para la comunicación
        static byte[] ReceiveFile(int fileSize) {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            byte[] buffer = new byte[32768];
            byte[] fileData = new byte[0];
            int bytes;
            do {
                Console.WriteLine("fileData size: " + fileData.Length);
                bytes = sslStream.Read(buffer, 0, buffer.Length);
                //fileData = appendByteArray(fileData, buffer);
                int startWritting = fileData.Length;
                Array.Resize(ref fileData, fileData.Length + bytes);
                Console.WriteLine("tamaño fileData {0}, bytes a copiar {1}", fileData.Length, bytes);
                Buffer.BlockCopy(buffer, 0, fileData, startWritting, bytes);
                Console.WriteLine("Leo {0} bytes más", bytes);
                Console.WriteLine("He leído {0} bytes de {1}", fileData.Length, fileSize);
            } while (fileData.Length < fileSize);
            sw.Stop();
            Console.WriteLine("{0} bytes descargados en {1} segundos, velocidad de descarga = {2} MB/s",
                fileData.Length, sw.Elapsed, (fileData.Length / 1000d) / sw.ElapsedMilliseconds);
            return fileData;
        }
        static string ReadMessage() {
            // Read the  message sent by the client.
            byte[] buffer = new byte[2048];
            StringBuilder messageData = new StringBuilder();
            int bytes;
            do {
                // Read the client's test message.
                bytes = sslStream.Read(buffer, 0, buffer.Length);

                // Use Decoder class to convert from bytes to UTF8
                // in case a character spans two buffers.
                Decoder decoder = Encoding.UTF8.GetDecoder();
                char[] chars = new char[decoder.GetCharCount(buffer, 0, bytes)];
                decoder.GetChars(buffer, 0, bytes, chars, 0);
                messageData.Append(chars);
                // Check for EOF or an empty message.
                if (messageData.ToString().IndexOf("<EOF>") != -1) {
                    break;
                }
            } while (bytes != 0);

            if (messageData.Length > 0)
                return messageData.ToString(0, messageData.Length - 5);

            return messageData.ToString();
        }
        static void WriteMessage(string message) {
            // Encode a test message into a byte array.
            // Signal the end of the message using the "<EOF>".
            byte[] messsageSocket = Encoding.UTF8.GetBytes(message + "<EOF>");
            // Send hello message to the server. 
            sslStream.Write(messsageSocket);
            //Console.WriteLine("Escribo: " + message);
            sslStream.Flush();
        }
        public static void WriteBytes(byte[] file) {
            byte[] messsageSocket = file;
            // Send message to the server. 
            sslStream.Write(messsageSocket);
            sslStream.Flush();
        }
    }
}