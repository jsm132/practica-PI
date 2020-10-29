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
    public partial class SecondStepUI : Form
    {
        public SecondStepUI()
        {
            InitializeComponent();
            this.Show();
        }

        private void step_button_Click(object sender, EventArgs e)
        {
            step_error_message_label.Visible = false;
            // mandar código introducido al servidor que lo comprobará
            string stepCode = code_step_textbox.Text;
            // si código correcto, cerrar ventana

            string serverMessage = Login.Login.SecondStep(stepCode);

            if (serverMessage.Equals("El código es correcto"))
            {
                // si correcto 2ndstep correcto, acceder
                Form main = new MainUI();
                this.Hide();
            }
            else
            {
                step_error_message_label.Text = "El código no es correcto";
                step_error_message_label.Visible = true;
            }
        }

        private void step_message_label_Click(object sender, EventArgs e)
        {

        }
    }
}
