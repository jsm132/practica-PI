using ESproject.Schedule;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ESproject.UI
{
    public partial class ScheduleList : Form
    {
        public ScheduleList()
        {
            InitializeComponent();
            this.Show();
            ShowScheduleNames();
        }

        private void ShowScheduleNames()
        {
            foreach (String s in User.getScheduleList()) {
                planName_List.Items.Add(s);
            }
            /*   string pathPlan = "..\\..\\Schedule\\" + User.getName() + "\\plans.json";

               List<Plan> plans = new List<Plan>();

               string jsonFile = System.IO.File.ReadAllText(pathPlan);

               if (jsonFile.Length > 0)
               {
                   plans = JsonConvert.DeserializeObject<List<Plan>>(jsonFile);

                   foreach (Plan p in plans)
                   {
                       planName_List.Items.Add(p.getScheduleName());
                   }
               }*/
        }

        private void ShowScheduleInfo()
        {
            string pathPlan = "..\\..\\Schedule\\" + User.getName() + "\\plans.json";

            List<Plan> plans = new List<Plan>();

            string jsonFile = System.IO.File.ReadAllText(pathPlan);

            if (jsonFile.Length > 0)
            {
                
                plans = JsonConvert.DeserializeObject<List<Plan>>(jsonFile);
                dayInfo_TextBox.Text = "";
                foreach (Plan p in plans)
                {
                    if (p.getScheduleName().Equals(planName_List.SelectedItem))
                    {
                        NameInfo_Textbox.Text = p.getScheduleName();
                        foreach (Schedule.Day d in p.days)
                        {
                            dayInfo_TextBox.Text += d.week + " " + d.weekDay + " " + d.hour + ":" + d.minute + " " + d.backupType + "\r\n";
                        }
                    }
                }
            }
        }

        private void planName_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowScheduleInfo();
        }
    }
}
