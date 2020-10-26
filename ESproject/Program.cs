
using ESproject.Cifrado;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ESproject
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
           // try {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new login());
            //Application.ApplicationExit += CloseTelegramBot;
            /* }
             catch (Exception e) {
                 MessageBox.Show(e.Message, "Error",
                      MessageBoxButtons.OK, MessageBoxIcon.Error);
             }*/
        }

        
    }
}
