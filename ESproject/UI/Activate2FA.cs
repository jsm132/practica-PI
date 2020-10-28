using ESproject._2FA;
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
    public partial class Activate2FA : Form
    {
        public Activate2FA()
        {
            InitializeComponent();
            this.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form telegramExplanation = new TelegramUsernameExplanation();
        }

        private void Activate2FA_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.TextLength > 0)
            {
                string serverMessage = SecondFA.Activate2FA(User.getName(), textBox1.Text); //envía al servidor el email del usuario actual y el nombre de su usuario en telegram y activa el 2FA.
                if(serverMessage.Equals("Segundo factor activado"))
                {
                    this.Hide();
                }
            }
            else
            {
                label4.Visible = true;
            }
        }
    }
}
