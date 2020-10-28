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
    public partial class UserOptions : Form
    {
        public UserOptions()
        {
            InitializeComponent();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form act2FA = new Activate2FA();
        }
    }
}
