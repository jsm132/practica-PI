using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;

namespace ESproject.UI
{
    public partial class SharedWithMe : Form
    {
        public SharedWithMe()
        {
            this.Show();
            InitializeComponent();
            printSharedBackups();
        }

        private void SharedWithMe_Load(object sender, EventArgs e)
        {

        }

        private string retrieveSharedBackups()
        {
            Messages.ClientMessage message = new Messages.ClientMessage();
            message.action = "retrieveSharedBackups";
            message.message.Add("user", User.getName());
            string registerMessage = JsonConvert.SerializeObject(message);

            Cliente.RunClient("localhost", "DESKTOP-IKVSN1R");
            string respuestaServidor = Cliente.WriteMessage(registerMessage);
            Cliente.closeConnection();
            return respuestaServidor;
        }

        private void printSharedBackups()
        {
            string result = retrieveSharedBackups();

            string[] shar = result.Split(',');

            foreach (string s in shar)
            {
                listBox1.Items.Add(s);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            if (listBox1.SelectedItem != null)
            {
                string[] path = listBox1.SelectedItem.ToString().Split('/');

                string files = "";

                if (listBox1.SelectedItem != null)
                {

                    using (var fbd = new FolderBrowserDialog())
                    {
                        DialogResult result = fbd.ShowDialog();

                        if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                        {
                            files = fbd.SelectedPath;

                        }
                    }
                }

                ESproject.Work.restoreBackupShared(path[1], path[0], files);
            }
            label2.Visible = true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
