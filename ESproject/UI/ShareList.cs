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
    public partial class ShareList : Form
    {
        public ShareList()
        {
            this.Show();
            InitializeComponent();
            foreach (string backup in User.getBackupList())
            {
                listBox1.Items.Add(backup);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

            string sharing = getSharing();
            string[] shar = sharing.Split(',');

            foreach(string s in shar)
            {
                listBox2.Items.Add(s);
            }
        }

        private string getSharing()
        {
            Messages.ClientMessage message = new Messages.ClientMessage();
            message.action = "requestSharing";
            message.message.Add("user", User.getName());
            message.message.Add("name", listBox1.SelectedItem.ToString());

            string registerMessage = JsonConvert.SerializeObject(message);

            Cliente.RunClient("localhost", "DESKTOP-IKVSN1R");
            string respuestaServidor = Cliente.WriteMessage(registerMessage);
            Cliente.closeConnection();
            return respuestaServidor;
        }
    }
}
