using ESproject.Backup;
using ESproject.Cifrado;
using ESproject.Schedule;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                backupFile = cpr.compressFiles(getFileNames()); //dejar esta línea si se quiere probar
                

            if(backupFile != null)
            {
                Crypto cipher = new Crypto(alg, User.getCipherKey());
                //AÑADIR AL NOMBRE DE ARCHIVO, EL TIPO DE COPIA (INC, FULL)
                string fileName = this.name + "_" + backupType + "_" + DateTime.Now.ToString("dd-MM-yy-HH-mm-ss") + "_" + this.alg;
                //suboArchivo
                FileManager.UploadFile(backupFile, fileName, cipher);
                FileManager.UploadFile(Encoding.ASCII.GetBytes(cpr.getMetadata()), fileName + ".meta", cipher, "storeBackupMetadata");
            }
            
        }

         static public void restoreBackup(string backupName) {
            string alg = backupName.Split('_')[backupName.Split('_').Length-1];
            List<Tuple<string, string>> metaList = new List<Tuple<string, string>>();
            Crypto cipher = new Crypto(alg, User.getCipherKey());
            byte[] file = FileManager.DownloadFile(backupName, cipher);
            string meta = Encoding.UTF8.GetString(FileManager.DownloadFile("meta/" + backupName + ".meta", cipher));
            
            string[] parts = meta.Split('\n');
            parts = parts.Take(parts.Count() - 1).ToArray();
            foreach (string s in parts) {
                string[] sub = s.Split('|');
                metaList.Add(new Tuple<string, string>(sub[0], sub[1]));
            }
            Compress.restoreFiles(file, metaList);
        }
    }
}
