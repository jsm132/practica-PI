using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ESproject.Schedule
{
    class Schedule
    {

        public static bool SaveOnJson(Plan plan)
        {
            string pathPlan = "..\\..\\Schedule\\" + User.getName() + "\\plans.json";

            List<Plan> plans = new List<Plan>();

            string jsonFile = System.IO.File.ReadAllText(pathPlan);

            if (jsonFile.Length > 0)
            {
                plans = JsonConvert.DeserializeObject<List<Plan>>(jsonFile);

                foreach (Plan p in plans)
                {
                    if (plan.getScheduleName().Equals(p.getScheduleName()))
                    {
                        return false;
                    }
                }
            }

            plans.Add(plan);

            string planJson = JsonConvert.SerializeObject(plans);

            System.IO.File.WriteAllText(pathPlan, planJson);

            return true;
        }

        public static void SendToServer()
        {
            string pathPlan = "..\\..\\Schedule\\" + User.getName() + "\\plans.json";

            string file = System.IO.File.ReadAllText(pathPlan);
            string user = User.getName();

            Messages.ClientMessage message = new Messages.ClientMessage();
            message.action = "schedule";
            message.message.Add("file", file);
            message.message.Add("user", user);

            string scheduleMessage = JsonConvert.SerializeObject(message);

            Cliente.RunClient("localhost", "DESKTOP-IKVSN1R");
            Console.WriteLine("lo que sea");
            string respuestaServidor = Cliente.WriteMessage(scheduleMessage);
            Console.WriteLine("lo que sea");
            Cliente.closeConnection();
        }

        public static string DownloadFromServer()
        {
            string user = User.getName();

            Messages.ClientMessage message = new Messages.ClientMessage();
            message.action = "downloadSchedule";
            message.message.Add("user", user);

            string scheduleMessage = JsonConvert.SerializeObject(message);

            Cliente.RunClient("localhost", "DESKTOP-IKVSN1R");
            string respuestaServidor = Cliente.WriteMessage(scheduleMessage);
            Cliente.closeConnection();

            if(!respuestaServidor.Equals("No hay planes para este usuario"))
            {
                string pathPlan = "..\\..\\Schedule\\" + User.getName() + "\\plans.json";
                System.IO.File.WriteAllText(pathPlan, respuestaServidor);
            }

            return respuestaServidor;
        }

    }
}
