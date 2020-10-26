namespace ESproject.UI
{
    partial class Work
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.workName = new System.Windows.Forms.TextBox();
            this.schList = new System.Windows.Forms.ComboBox();
            this.aes = new System.Windows.Forms.RadioButton();
            this.tdes = new System.Windows.Forms.RadioButton();
            this.createWork = new System.Windows.Forms.Button();
            this.selectFiles = new System.Windows.Forms.Button();
            this.selectedFiles = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre del trabajo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 64);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Archivos a copiar:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 275);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Planificación:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 300);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Algoritmo de cifrado:";
            // 
            // workName
            // 
            this.workName.Location = new System.Drawing.Point(156, 37);
            this.workName.Margin = new System.Windows.Forms.Padding(2);
            this.workName.Name = "workName";
            this.workName.Size = new System.Drawing.Size(166, 20);
            this.workName.TabIndex = 4;
            // 
            // schList
            // 
            this.schList.FormattingEnabled = true;
            this.schList.Location = new System.Drawing.Point(156, 269);
            this.schList.Margin = new System.Windows.Forms.Padding(2);
            this.schList.Name = "schList";
            this.schList.Size = new System.Drawing.Size(166, 21);
            this.schList.TabIndex = 6;
            // 
            // aes
            // 
            this.aes.AutoSize = true;
            this.aes.Location = new System.Drawing.Point(156, 300);
            this.aes.Margin = new System.Windows.Forms.Padding(2);
            this.aes.Name = "aes";
            this.aes.Size = new System.Drawing.Size(46, 17);
            this.aes.TabIndex = 7;
            this.aes.TabStop = true;
            this.aes.Text = "AES";
            this.aes.UseVisualStyleBackColor = true;
            // 
            // tdes
            // 
            this.tdes.AutoSize = true;
            this.tdes.Location = new System.Drawing.Point(156, 322);
            this.tdes.Margin = new System.Windows.Forms.Padding(2);
            this.tdes.Name = "tdes";
            this.tdes.Size = new System.Drawing.Size(76, 17);
            this.tdes.TabIndex = 8;
            this.tdes.TabStop = true;
            this.tdes.Text = "Triple DES";
            this.tdes.UseVisualStyleBackColor = true;
            // 
            // createWork
            // 
            this.createWork.Location = new System.Drawing.Point(156, 366);
            this.createWork.Margin = new System.Windows.Forms.Padding(2);
            this.createWork.Name = "createWork";
            this.createWork.Size = new System.Drawing.Size(116, 19);
            this.createWork.TabIndex = 9;
            this.createWork.Text = "Crear trabajo";
            this.createWork.UseVisualStyleBackColor = true;
            this.createWork.Click += new System.EventHandler(this.createWork_Click);
            // 
            // selectFiles
            // 
            this.selectFiles.Location = new System.Drawing.Point(328, 232);
            this.selectFiles.Name = "selectFiles";
            this.selectFiles.Size = new System.Drawing.Size(75, 23);
            this.selectFiles.TabIndex = 10;
            this.selectFiles.Text = "Examinar";
            this.selectFiles.UseVisualStyleBackColor = true;
            this.selectFiles.Click += new System.EventHandler(this.selectFiles_Click);
            // 
            // selectedFiles
            // 
            this.selectedFiles.HideSelection = false;
            this.selectedFiles.Location = new System.Drawing.Point(156, 64);
            this.selectedFiles.Name = "selectedFiles";
            this.selectedFiles.Size = new System.Drawing.Size(166, 191);
            this.selectedFiles.TabIndex = 11;
            this.selectedFiles.UseCompatibleStateImageBehavior = false;
            this.selectedFiles.View = System.Windows.Forms.View.List;
            // 
            // Work
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 509);
            this.Controls.Add(this.selectedFiles);
            this.Controls.Add(this.selectFiles);
            this.Controls.Add(this.createWork);
            this.Controls.Add(this.tdes);
            this.Controls.Add(this.aes);
            this.Controls.Add(this.schList);
            this.Controls.Add(this.workName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Work";
            this.Text = "Work";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox workName;
        private System.Windows.Forms.ComboBox schList;
        private System.Windows.Forms.RadioButton aes;
        private System.Windows.Forms.RadioButton tdes;
        private System.Windows.Forms.Button createWork;
        private System.Windows.Forms.Button selectFiles;
        private System.Windows.Forms.ListView selectedFiles;
    }
}