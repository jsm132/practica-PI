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
    }
}
