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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            this.Show();
        }

        private void mail_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void check_label_Click(object sender, EventArgs e)
        {

        }

        private void check_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_label_Click(object sender, EventArgs e)
        {

        }

        private void mail_label_Click(object sender, EventArgs e)
        {

        }

        private void password_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void register_button_Click(object sender, EventArgs e)
        {
            // comprobar password y repeat password
            string password = password_textbox.Text;
            string checkpassword = check_textbox.Text;

            // comprobar email es un email
            System.Text.RegularExpressions.Regex regexMail = new System.Text.RegularExpressions
                .Regex(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$");
            string mail = mail_textbox.Text;

            error_message_label.Visible = false;
            user_registered_message_label.Visible = false;

            if(!regexMail.IsMatch(mail))
            {
                error_message_label.Text = "El texto introducido no es un correo electrónico";
                error_message_label.Visible = true;
            }
            else // comprobar que las contraseñas coinciden
            {
                if(String.Compare(password, checkpassword)== 0)
                {
                    // comprobamos que no está registrado el correo
                    string serverMessage = Registro.Registro.Register(mail, password);

                    if(serverMessage.Equals("Usuario ya registrado"))
                    {
                        error_message_label.Text = "Ese correo ya está registrado, introduzca otro, por favor";
                        error_message_label.Visible = true;
                    }
                    else if(serverMessage.Equals("Usuario registrado con éxito")) // el usuario se ha registrado 
                    {
                        user_registered_message_label.Visible = true;
                    }
                    else
                    {
                        error_message_label.Text = "Se ha producido un error durante el registro";
                        error_message_label.Visible = true;
                    }
                }
                else
                {
                    error_message_label.Text = "Las contraseñas introducidas no coinciden";
                    error_message_label.Visible = true;
                }
            }
        }
    }
}
