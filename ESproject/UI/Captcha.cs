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
    public partial class Captcha : Form
    {
        string captchaValue;
        public Captcha()
        {
            InitializeComponent();
            this.Show();
            
            captchaValue = generateCaptcha();
            
        }

        private string generateCaptcha()
        {
            var num = 0;
            Random r1 = new Random();
            num = r1.Next(1000, 9999);
            var image = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            var font = new Font("Mistral", 25, FontStyle.Italic, GraphicsUnit.Pixel);
            var graphics = Graphics.FromImage(image);
            graphics.DrawString(num.ToString(), font, Brushes.Red, new Point(0, 0));
            pictureBox1.Image = image;
            return num.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!textBox1.Text.Equals(captchaValue))
            {
                captchaValue = generateCaptcha();
                label2.Visible = true;
            }
            else
            {
                Form login = new login();
                this.Hide();
            }

        }
    }
}
