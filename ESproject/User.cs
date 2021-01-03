using ESproject.Backup;
using ESproject.Schedule;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace ESproject {
    public class User {
        static string Name; //tomar valor al hacer login
        static List<Work> works; //cargar todos los trabajos asociados => descargando json del servidor y convirtiéndolo a lista
        //static byte[] CipherKey; //toma valor al hacer login
        static Thread checkerThread;
  
        static User() {
            works = new List<Work>();
        }

        public static List<string> getBackupList() {
            Cliente.RunClient("localhost", "DESKTOP-IKVSN1R");
            Messages.ClientMessage message = new ESproject.Messages.ClientMessage {
                action = "downloadBackupList"
            };
            message.message.Add("user", getName());
            string uploadMsg = JsonConvert.SerializeObject(message);
            string uploadStr = Cliente.WriteMessage(uploadMsg);
            Cliente.closeConnection();
            return JsonConvert.DeserializeObject<List<string>>(uploadStr)
                .Select(x => Path.GetFileName(x)).ToList();
        }

        public static List<string> getWorkList() {
            Cliente.RunClient("localhost", "DESKTOP-IKVSN1R");
            Messages.ClientMessage message = new ESproject.Messages.ClientMessage {
                action = "downloadWorkList"
            };
            message.message.Add("user", getName());
            string uploadMsg = JsonConvert.SerializeObject(message);
            string uploadStr = Cliente.WriteMessage(uploadMsg);
            Cliente.closeConnection();
            return JsonConvert.DeserializeObject<List<string>>(uploadStr)
                .Select(x => Path.GetFileName(x)).ToList();
        }

        public static List<Plan> getSchedules() {
            string pathPlan = "..\\..\\Schedule\\" + getName() + "\\plans.json";
            string folderPath = "..\\..\\Schedule\\" + getName();
            if (!Directory.Exists(folderPath)) {
                Directory.CreateDirectory(folderPath);
            }
            if (!File.Exists(pathPlan)) {
                using (File.Create(pathPlan));
            }
            string jsonFile = System.IO.File.ReadAllText(pathPlan);
            if (jsonFile.Length == 0) {
                return new List<Plan>();
            }
            return JsonConvert.DeserializeObject<List<Plan>>(jsonFile);
        }
        public static List<string> getScheduleList() {
            List<Plan> scheduleList = getSchedules();

            if (scheduleList != null && scheduleList.Count > 0) {
                return scheduleList.Select(p => p.getScheduleName()).ToList();
            } else {
                return new List<string>();
            }
        }
        public static void LoadUserWorks() {
             foreach (string s in getWorkList()) {
                 new Work(s);
             }
          //  Console.WriteLine(getWorkList().Count);
        }

        public static string getName() {
            return Name;
        }
        /*public static void setCipherKey(byte[] key) {
            CipherKey = key;
        }*/
        public static void setName(string name) {
            Name = name;
        }

        /*public static byte[] getCipherKey() {
            return CipherKey;
        }*/

        public static List<Work> getWorks() {
            return works;
        }

        public static void startChecker() {
            checkerThread = new Thread(checker.Run);
            checkerThread.Start();
        }

        public static void addWork(Work w) {
            works.Add(w);
        }

        public static void killThread()
        {
            checkerThread.Abort();
        }
    }
}
