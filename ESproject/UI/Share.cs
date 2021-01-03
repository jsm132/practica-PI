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
    public partial class Share : Form
    {
        public string backupName;

        public Share(string backupName)
        {
            this.Show();
            this.backupName = backupName;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string respuesta = shareBackup(User.getName(), textBox1.Text);
            if(respuesta.Equals("Backup compartido."))
            {
                label2.Visible = true;
                label2.Text = "Compartido con éxito";
            }
            else
            {
                label2.Visible = true;
                label2.Text = "El usuario no existe";
            }
        }

        public string shareBackup(string currentUser, string userShare)
        {
            Messages.ClientMessage message = new Messages.ClientMessage();
            message.action = "shareBackup";
            message.message.Add("currentUser", currentUser);
            message.message.Add("backupName", backupName);
            message.message.Add("userShare", userShare);

            string registerMessage = JsonConvert.SerializeObject(message);

            Cliente.RunClient("localhost", "DESKTOP-IKVSN1R");
            string respuestaServidor = Cliente.WriteMessage(registerMessage);
            Cliente.closeConnection();
            return respuestaServidor;
        }
    }
}
