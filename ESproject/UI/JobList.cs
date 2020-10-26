using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ESproject.UI
{
    public partial class JobList : Form
    {
        public JobList()
        {     
            InitializeComponent();
            this.Show();
            foreach (String s in User.getWorkList())
            {
                workList_listBox.Items.Add(s.Replace(".json",""));
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowWorks();
        }

        private void ShowWorks()
        {
            List<ESproject.Work> works = User.getWorks();

            if (works.Count > 0)
            {
                fileInfo_textbox.Text = "";
                foreach (ESproject.Work p in works)
                {
                    string workName = p.getName().Replace(".json", "");
                    if (workName.Equals(workList_listBox.SelectedItem))
                    {
                        name_textbox.Text = workName;
                        schedule_textbox.Text = p.getSchedule();
                        algorithm_textbox.Text = p.getAlgorithm();
                        foreach (string file in p.getFileNames())
                        {
                            fileInfo_textbox.Text += file +"\r\n";
                        }
                    }
                }
            }
        }
    }
}
