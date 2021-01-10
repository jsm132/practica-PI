using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ESproject {
    public class Compress {

        private List<Tuple<string, string>> metadata;
        public Compress() {
            metadata = new List<Tuple<string, string>>();
        }
        public byte[] compressFiles(List<String> allFiles) {
            byte[] compressedFile = new byte[0];
            foreach (String filePath in allFiles) {
                byte[] newFile = File.ReadAllBytes(filePath);
                addMetadata(filePath, newFile.Length.ToString());
                int startWritting = compressedFile.Length;
                Array.Resize(ref compressedFile, compressedFile.Length + newFile.Length);
                Buffer.BlockCopy(newFile, 0, compressedFile, startWritting, newFile.Length);
            }
            return compressedFile;
        }
        public string getMetadata() {
            StringBuilder sb = new StringBuilder();
            foreach (Tuple<string, string> t in metadata) {
                sb.Append(t.Item1);
                sb.Append("|");
                sb.Append(t.Item2);
                sb.Append("\n");
            }
            return sb.ToString();
        }
        private void addMetadata(string fileName, string fileSize) {
            metadata.Add(new Tuple<string, string>(fileName, fileSize));
        }

        //a partir de un array de bytes, y una lista con los nombres y tamaño (ordenados) restaura un backup
        public static void restoreFiles(byte[] backup, List<Tuple<string, string>> meta, string paths) {
            int offset = 0;
            foreach(Tuple<string, string> t in meta) {
                string filePath = t.Item1;
                //Console.WriteLine(t.Item2);
                int fileSize = int.Parse(t.Item2);
                byte[] file = new byte[fileSize];
                Buffer.BlockCopy(backup, offset, file, 0, fileSize);
                //ASEGURARNOS DE QUE SOBREESRIBE ARCHIVOS -> IMPORTANTE PARA CUANDO ESTEMOS RESTAURANDO UNA COPIA INCREMENTAL
                File.WriteAllBytes(paths + "/" + Path.GetFileNameWithoutExtension(filePath) + ".bkp" + Path.GetExtension(filePath), file);
                offset += fileSize;
            }
        }

        public static void restoreFilesShared(byte[] backup, List<Tuple<string, string>> meta, string user, string path)
        {
            int offset = 0;
            foreach (Tuple<string, string> t in meta)
            {
                string filePath = t.Item1;
                Console.WriteLine(filePath);
                //Console.WriteLine(t.Item2);
                int fileSize = int.Parse(t.Item2);
                byte[] file = new byte[fileSize];
                Buffer.BlockCopy(backup, offset, file, 0, fileSize);
                //ASEGURARNOS DE QUE SOBREESRIBE ARCHIVOS -> IMPORTANTE PARA CUANDO ESTEMOS RESTAURANDO UNA COPIA INCREMENTAL
                File.WriteAllBytes(path + "/" + Path.GetFileNameWithoutExtension(filePath) + ".bkp" + Path.GetExtension(filePath), file);
                offset += fileSize;
            }
        }
    }

}
