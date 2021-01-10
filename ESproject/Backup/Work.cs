using ESproject.Backup;
using ESproject.Cifrado;
using ESproject.Schedule;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

//La clase debe estar en el proceso infinito
namespace ESproject {
    public class Work {
        [JsonProperty] List<Archivo> files;
        [JsonProperty] string sch;
        [JsonProperty] string alg;
        [JsonProperty] string name;
        public Work() {

        }

        public string getName()
        {
            return this.name;
        }

        public string getSchedule()
        {
            return this.sch;
        }

        public string getAlgorithm()
        {
            return this.alg;
        }

        public List<Archivo> getFiles()
        {
            return this.files;
        }

        public Work(string name, List<Archivo> files, string sch, string alg) {
            this.name = name.Replace(" ", "-");
            this.files = files;
            this.sch = sch;
            this.alg = alg;
            User.addWork(this);
            this.saveOnServer();
        }

        public Work(string name) {
            string jsonStr = Encoding.UTF8.GetString(FileManager.DownloadFile(name, null, false, "downloadWork"));
            this.files = Newtonsoft.Json.JsonConvert.DeserializeObject<Work>(jsonStr).files;
            this.sch = Newtonsoft.Json.JsonConvert.DeserializeObject<Work>(jsonStr).sch;
            this.alg = Newtonsoft.Json.JsonConvert.DeserializeObject<Work>(jsonStr).alg;
            this.name = Newtonsoft.Json.JsonConvert.DeserializeObject<Work>(jsonStr).name;
            User.addWork(this);
        }

        public static List<string> getWorkListFromServer() {
            string jsonStr = Encoding.UTF8.GetString(FileManager.DownloadFile(".json", null, false, "downloadWorkList"));
            return JsonConvert.DeserializeObject<List<string>>(jsonStr);
        }
       
        public void saveOnServer() {
            Console.WriteLine(name + sch + alg);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(this);
            Work w = JsonConvert.DeserializeObject<Work>(json);
            //string path = "works/" + User.getName() + "/";
            //File.WriteAllText(path + this.name + ".json", json
            FileManager.UploadFile(Encoding.UTF8.GetBytes(json), this.name + ".json", null,"storeWork", false);
        }

        public bool checkPlan(string sch) {
            //3- se comprueban todas las copias para ver cuales tienen esos planes asociados 
            return this.sch.Equals(sch);
        }

        public List<string> getFileNames()
        {
            List<string> names = new List<string>();
            for(int i = 0; i < files.Count; i++)
            {
                names.Add(files[i].archivo["name"]);
            }

            return names;
        }

        public void doWork(string backupType) {
            //4- se comprimen los archivos en uno solo, se cifran, se ponen los metadatos en el nombre y se sube al servidor
            Compress cpr = new Compress();
             byte[] backupFile = null;
            //incremental
            if(backupType == "Incremental")
            {
                //obtener el json del backup completo base
                List<string> backupNames = User.getBackupList();
                List<string> formatedNames = new List<string>();
                
                for (int i = 0; i< backupNames.Count; i++)
                {
                    formatedNames.Add(backupNames[i].Split('_')[0]);
                }

                if (!formatedNames.Contains(this.name))
                {
                    backupFile = cpr.compressFiles(getFileNames());
                    backupType = "Completo";
                }
                else
                {
                    List<String> filesIncr = new List<String>();
                    for (int i = backupNames.Count - 1; i >= 0; i--)
                    {
                        string nombre = backupNames[i].Split('_')[0];
                        string tipo = backupNames[i].Split('_')[1];
                        if (this.name.Equals(nombre) && tipo.Equals("Completo"))
                        {
                            List<string> fileNames = getFileNames();
                            for (int j = 0; j < fileNames.Count; j++)
                            {
                                for (int z = 0; z < files.Count; z++)
                                {
                                    if (files[z].archivo["name"].Equals(fileNames[j]))
                                    {
                                        string hash = System.IO.File.ReadAllText(fileNames[j]);
                                        byte[] hashByte = KeyManager.KeyManager.getHash(hash);
                                        hash = KeyManager.KeyManager.byteToString(hashByte);
                                        if (!files[z].archivo["hash"].Equals(hash))
                                        {
                                            filesIncr.Add(files[z].archivo["name"]);
                                            files[z].archivo["hash"] = hash;

                                        }
                                    }
                                }
                            }

                            Work w = new Work(this.name, this.files, this.sch, this.alg);

                            break;
                        }
                    }

                    if (filesIncr.Count>0)
                    {
                        backupFile = cpr.compressFiles(filesIncr);
                    }
                }
            }

            if (backupType == "Completo")
                backupFile = cpr.compressFiles(getFileNames()); 
                

            if(backupFile != null)
            {
                //AÑADIR AL NOMBRE DE ARCHIVO, EL TIPO DE COPIA (INC, FULL), el día y hora en la que se realizó y el algoritmo de cifrado utilizado
                string fileName = this.name + "_" + backupType + "_" + DateTime.Now.ToString("dd-MM-yy-HH-mm-ss") + "_" + this.alg;
                addBackupForKey(fileName, User.getName());
                //ciframos utilizando el algoritmo elegido por el usuario y una clave aleatoria y única
                Crypto cipher = new Crypto(alg, Encoding.Default.GetBytes(requestKey(fileName, User.getName()))); 
                
                //suboArchivo
                FileManager.UploadFile(backupFile, fileName, cipher);
                FileManager.UploadFile(Encoding.ASCII.GetBytes(cpr.getMetadata()), fileName + ".meta", cipher, "storeBackupMetadata");
            }
            
        }

        public static string addBackupForKey(string name, string user)
        {
            Messages.ClientMessage message = new Messages.ClientMessage();
            message.action = "backupAdd";
            message.message.Add("name", name);
            message.message.Add("user", user);

            //generamos la clave que utilizaremos para descifrar el backup
            var rnd = new RNGCryptoServiceProvider();
            var b = new byte[16];
            rnd.GetNonZeroBytes(b);

            Crypto crp = new Crypto("Aes", b);
            message.message.Add("key", byteToString(crp.key));

            string registerMessage = JsonConvert.SerializeObject(message);

            Cliente.RunClient("localhost", "DESKTOP-IKVSN1R");
            string respuestaServidor = Cliente.WriteMessage(registerMessage);
            Cliente.closeConnection();
            return respuestaServidor;
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
        public static string requestKey(string name, string user)
        {
            Messages.ClientMessage message = new Messages.ClientMessage();
            message.action = "requestKey";
            message.message.Add("name", name);
            message.message.Add("user", user);

            string registerMessage = JsonConvert.SerializeObject(message);

            Cliente.RunClient("localhost", "DESKTOP-IKVSN1R");
            string respuestaServidor = Cliente.WriteMessage(registerMessage);
            Cliente.closeConnection();
            return respuestaServidor;
        }

        static public void restoreBackup(string backupName, string paths) {
            string alg = backupName.Split('_')[backupName.Split('_').Length-1];
            List<Tuple<string, string>> metaList = new List<Tuple<string, string>>();
            Crypto cipher = new Crypto(alg, Encoding.Default.GetBytes(requestKey(backupName, User.getName())));

            byte[] file = FileManager.DownloadFile(backupName, cipher);
            string meta = Encoding.UTF8.GetString(FileManager.DownloadFile("meta/" + backupName + ".meta", cipher));
            
            string[] parts = meta.Split('\n');
            parts = parts.Take(parts.Count() - 1).ToArray();
            foreach (string s in parts) {
                string[] sub = s.Split('|');
                metaList.Add(new Tuple<string, string>(sub[0], sub[1]));
            }
            Compress.restoreFiles(file, metaList, paths);
        }

        static public void restoreBackupShared(string backupName, string user, string path)
        {
            string alg = backupName.Split('_')[backupName.Split('_').Length - 1];
            List<Tuple<string, string>> metaList = new List<Tuple<string, string>>();
            Crypto cipher = new Crypto(alg, Encoding.Default.GetBytes(requestKey(backupName, user)));

            byte[] file = FileManager.DownloadFileShared(user, backupName, cipher);
            string meta = Encoding.UTF8.GetString(FileManager.DownloadFileShared(user, "meta/" + backupName + ".meta", cipher));

            string[] parts = meta.Split('\n');
            parts = parts.Take(parts.Count() - 1).ToArray();
            foreach (string s in parts)
            {
                string[] sub = s.Split('|');
                metaList.Add(new Tuple<string, string>(sub[0], sub[1]));
            }

            Compress.restoreFilesShared(file, metaList, user, path);
        }
    }
}
