using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ESproject.UI
{
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();
            this.Show();
            CreateDirectory();
        }

        private void Options_contextMenu_Opening(object sender, CancelEventArgs e)
        {

        }


        private void MainUI_Load(object sender, EventArgs e) {
            /*List<string> files = new List<string>();
            files.Add("backupTest/Yekteniya_1.mp3");
            files.Add("backupTest/sorpresa.mp3");
            files.Add("backupTest/shurprise.mp3");
            ESproject.Work w = new ESproject.Work("ejemplo trabajo", files, "schedulePrueba", "AES");
            w.doWork();*/
            foreach (string backup in User.getBackupList()) {
                backup_list.Items.Add(backup);
            }
            
            User.LoadUserWorks();
            Console.WriteLine("Total de trabajos " + User.getWorks().Count + " Total de planes " + User.getScheduleList().Count);
            User.startChecker();
        }

        

        private void MainUI_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void CreateDirectory()
        {
            string path ="..\\..\\Schedule\\" + User.getName(); //cambiar cuando funcione la clase User

            try
            {
                /*if (Directory.Exists(path))
                {
                    return;
                }*/

                //Directory.CreateDirectory(path);

                using (FileStream fs = File.Create(path + "\\plans.json"))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes("[]");
                    fs.Write(info, 0, info.Length);
                }
                Schedule.Schedule.DownloadFromServer();
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        private void añadirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form schedule = new schedule();
        }

        private void verToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form scheduleList = new ScheduleList();
        }

        private void restoreBackup_button_Click(object sender, EventArgs e) {

            string files = "";

            if (backup_list.SelectedItem != null){

                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        files = fbd.SelectedPath;

                    }
                }
                ESproject.Work.restoreBackup(backup_list.SelectedItem.ToString(), files);
            }
        }

        private void addBackup_button_Click(object sender, EventArgs e) {
            new Work();
        }

        private void refreshBackupList_Click(object sender, EventArgs e) {
            backup_list.Items.Clear();
            foreach (string backup in User.getBackupList()) {
                backup_list.Items.Add(backup);
            }
        }

        private void planificaciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void verTrabajosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form jobList = new JobList();
        }

        private void backup_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            restoreBackup_button.Enabled = true;

            if (backup_list.SelectedItem != null)
            {
                backupName_textbox.Text = backup_list.SelectedItem.ToString().Split('_')[0];
                BackupType_textbox.Text = backup_list.SelectedItem.ToString().Split('_')[1];
                backupDate_textbox.Text = backup_list.SelectedItem.ToString().Split('_')[2];
                algorithm_textbox.Text = backup_list.SelectedItem.ToString().Split('_')[3];
            }
        }

        private void opcionesDeCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form useropt = new UserOptions();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form share = new Share(backup_list.SelectedItem.ToString());
        }

        private void copiasCompartidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form sharelist = new ShareList();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form sharedWithMe = new SharedWithMe();
        }

        private void compartidoConmigoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
