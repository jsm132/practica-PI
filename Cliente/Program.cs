using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using ESproject;
using ESproject.Cifrado;
using ESproject.Schedule;

namespace ClientePruebas
{
    class Program
    {
        public static int Main() {
            Console.WriteLine(DateTime.Now.ToString("dddd", new CultureInfo("es-ES")));
            Console.WriteLine(DateTime.Now.ToString("mmmm", new CultureInfo("es-ES")));
            Console.WriteLine(DateTime.Now.ToString("HHHH", new CultureInfo("es-ES")));
            Console.WriteLine(Day.getNumberOfDayInMonth());
            //Prueba sockets
            /*  string serverCertificateName = "DESKTOP-IKVSN1R";
              string machineAddress = "localhost";

              Cliente.Cliente.RunClient(machineAddress, serverCertificateName);*/
            /*
          try {
              FileManager fm = new FileManager();
              string file = "Yekteniya_1.mp3";//Console.ReadLine();
              //Console.WriteLine(fm.DownloadFile(file));
             // Console.WriteLine(fm.UploadFile(file, new Crypto("AES", ));
              Console.ReadKey();
          }catch(Exception e) {
              Console.WriteLine(e);
              Console.ReadKey();
          }*/
            /*
              //Prueba compresión archivos
              List<String> archivos = new List<string>();
              archivos.Add("sorpresa.mp3");
              archivos.Add("Yekteniya_1.mp3");
              Console.WriteLine(Compress.compressFiles(archivos).Length);
              */
            /*
          try {
              User.setName("p@p");
              User.setCipherKey(new byte[] { 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20 });
              List<string> files = new List<string>();
              files.Add("backupTest/Yekteniya_1.mp3");
              files.Add("backupTest/sorpresa.mp3");
              files.Add("backupTest/shurprise.mp3");
              Work w = new Work("ejemplo trabajo", files, "schedulePrueba", "AES");
              w.doWork();

              //w.restoreWork();
              //w.saveOnServer();
              //Work w2 = new Work("ejemplo-trabajo");
              //w2.doWork();
              //Work.restoreBackup("ejemplo-trabajo_04-04-20-20-16-46_AES");
              var backupList = User.getBackupList();
              foreach (string s in backupList) {
                  Console.WriteLine(s);
              }
          }
          catch (Exception e) {
              Console.WriteLine(e.ToString());
          }*/
            /*
            //Prueba cifrado
            //Utilizo como clave una cualquiera de 128 bits
            var key = new byte[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            //Inicializo el objeto para funcionar con AES, la otra opción sería pasarle la cadena "TripleDES"
            Crypto enc = new Crypto("AES", key, key);
            //enc = new Crypto("TripleDES", key, key);
           
            //Cifro y descifro el contenido del archivo para comprobar que finalmente queda intacto.
            byte[] plano = enc.decryptFile(enc.encryptFile(File.ReadAllBytes("plano.txt")));
            //Cifro el contenido del archivo
            byte[] cifrado = enc.encryptFile(File.ReadAllBytes("plano.txt"));
            //Imprimo en hex el contenido original
            Console.WriteLine(ByteArrayToString(File.ReadAllBytes("plano.txt")));
            //Imprimo en hex el contenido cifrado y descifrado
            Console.WriteLine(ByteArrayToString(plano));
            //Imprimo el contenido cifrado
            Console.WriteLine(ByteArrayToString(cifrado));
            */
            return 0;
        }
    }
}
