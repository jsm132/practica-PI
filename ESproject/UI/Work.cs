using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ESproject.Backup;

namespace ESproject.UI {
    public partial class Work : Form {

        OpenFileDialog openFileDialog1;
        public Work() {
            InitializeComponent();
            InitializeOpenFileDialog();
            this.Show();
            schList.Items.AddRange(User.getScheduleList().ToArray());
        }
        private void InitializeOpenFileDialog() {
            openFileDialog1 = new OpenFileDialog();
            // Set the file dialog to filter for graphics files.
            openFileDialog1.Filter =
                "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" +
                "All files (*.*)|*.*";

            //  Allow the user to select multiple images.
            openFileDialog1.Multiselect = true;
            openFileDialog1.Title = "My Image Browser";
        }

        private void createWork_Click(object sender, EventArgs e) {
            string name = workName.Text;
            List<string> files = selectedFiles.Items.Cast<ListViewItem>().Select(item => item.Text).ToList();
            List<Archivo> archivos = new List<Archivo>();
            for(int i = 0; i < files.Count; i++)
            {

                string hash = System.IO.File.ReadAllText(files[i]);
                byte[] hashByte = KeyManager.KeyManager.getHash(hash);
                hash = KeyManager.KeyManager.byteToString(hashByte);
                Archivo ar = new Archivo();
                ar.archivo.Add("name", files[i]);
                ar.archivo.Add("hash", hash);
                archivos.Add(ar);
            }

            string plan = schList.SelectedItem.ToString();
            string alg = aes.Checked ? "AES" : "TripleDES";
            ESproject.Work newWork = new ESproject.Work(name, archivos, plan, alg);
            this.Close();
        }

        private void recursiveFolders()
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);

                    foreach (String file in files)
                    {
                        // Create a PictureBox.
                        try
                        {
                            selectedFiles.Items.Add(file);
                        }
                        catch (SecurityException ex)
                        {
                            // The user lacks appropriate permissions to read files, discover paths, etc.
                            MessageBox.Show("Security error. Please contact your administrator for details.\n\n" +
                                "Error message: " + ex.Message + "\n\n" +
                                "Details (send to Support):\n\n" + ex.StackTrace
                            );
                        }
                        catch (Exception ex)
                        {
                            // Could not load the image - probably related to Windows file system permissions.
                            MessageBox.Show("Cannot display the image: " + file.Substring(file.LastIndexOf('\\'))
                                + ". You may not have permission to read the file, or " +
                                "it may be corrupt.\n\nReported error: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void selectFiles_Click(object sender, EventArgs e) {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath, "*", SearchOption.AllDirectories);

                    foreach (String file in files)
                    {
                        // Create a PictureBox.
                        try
                        {
                            selectedFiles.Items.Add(file);
                        }
                        catch (SecurityException ex)
                        {
                            // The user lacks appropriate permissions to read files, discover paths, etc.
                            MessageBox.Show("Security error. Please contact your administrator for details.\n\n" +
                                "Error message: " + ex.Message + "\n\n" +
                                "Details (send to Support):\n\n" + ex.StackTrace
                            );
                        }
                        catch (Exception ex)
                        {
                            // Could not load the image - probably related to Windows file system permissions.
                            MessageBox.Show("Cannot display the image: " + file.Substring(file.LastIndexOf('\\'))
                                + ". You may not have permission to read the file, or " +
                                "it may be corrupt.\n\nReported error: " + ex.Message);
                        }
                    }
                }
            }
        }
    }
}
