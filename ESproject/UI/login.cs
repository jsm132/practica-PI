using ESproject.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESproject.Login;
using System.Threading;
using ESproject._2FA;

namespace ESproject
{
    public partial class login : Form
    {
        int intentosLogin;
        public login()
        {
            InitializeComponent();
            this.Show();
            intentosLogin = 0;
        }


        private void register_button_Click(object sender, EventArgs e)
        {
            Form register = new Register();
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            string secondFA = "NO";
            string telegramUser = "";
            string mail = user_textbox.Text;
            string password = password_textbox.Text;

            error_message_label.Visible = false;

            if (SecondFA.checkIf2FAIsActivated(mail).Equals("El segundo factor de autenticación está activado para este usuario."))
            {
                secondFA = "YES";
                telegramUser = SecondFA.getTelegramUsername(mail);
            }

            string serverMessage = Login.Login.LoginClient(mail, password, secondFA, telegramUser);
            
            if (serverMessage.Equals("El usuario o la contraseña no son correctos"))
            {
                error_message_label.Text = serverMessage;
                error_message_label.Visible = true;
                if (intentosLogin >= 2)
                {
                    Form captcha = new Captcha();
                    this.Hide();
                }
                intentosLogin++;
                //loadingLabel.Visible = false;
                //Cliente.closeConnection();//si no se pone, se congela la comunicación
            }
            else if (serverMessage.Equals("Login correcto"))
            {
                intentosLogin = 0;
                // abrir ventana de 2ndstep para meter el código
                if (secondFA.Equals("YES"))
                {
                    Form second = new SecondStepUI();
                }
                else
                {
                    Form main = new MainUI();
                }
                
                
                loadingLabel.Visible = true;
                AutoClosingMessageBox.Show("Inicio de sesión con éxito", "Inicio de sesión", 1);
                //MessageBox.Show("Cargando datos del usuario. Espere por favor...");
                this.Hide();
                
            } 
        }
    }
    public class AutoClosingMessageBox {
        System.Threading.Timer _timeoutTimer;
        string _caption;
        AutoClosingMessageBox(string text, string caption, int timeout) {
            _caption = caption;
            _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                null, timeout, System.Threading.Timeout.Infinite);
            using (_timeoutTimer)
                MessageBox.Show(text, caption);
        }
        public static void Show(string text, string caption, int timeout) {
            new AutoClosingMessageBox(text, caption, timeout);
        }
        void OnTimerElapsed(object state) {
            IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
            if (mbWnd != IntPtr.Zero)
                SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            _timeoutTimer.Dispose();
        }
        const int WM_CLOSE = 0x0010;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
    }
}


