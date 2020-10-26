namespace ESproject.UI
{
    partial class JobList
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
            this.workList_listBox = new System.Windows.Forms.ListBox();
            this.name_textbox = new System.Windows.Forms.TextBox();
            this.schedule_textbox = new System.Windows.Forms.TextBox();
            this.algorithm_textbox = new System.Windows.Forms.TextBox();
            this.fileInfo_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // workList_listBox
            // 
            this.workList_listBox.FormattingEnabled = true;
            this.workList_listBox.Location = new System.Drawing.Point(12, 25);
            this.workList_listBox.Name = "workList_listBox";
            this.workList_listBox.Size = new System.Drawing.Size(187, 446);
            this.workList_listBox.TabIndex = 0;
            this.workList_listBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // name_textbox
            // 
            this.name_textbox.Location = new System.Drawing.Point(342, 26);
            this.name_textbox.Name = "name_textbox";
            this.name_textbox.Size = new System.Drawing.Size(178, 20);
            this.name_textbox.TabIndex = 1;
            // 
            // schedule_textbox
            // 
            this.schedule_textbox.Location = new System.Drawing.Point(342, 52);
            this.schedule_textbox.Name = "schedule_textbox";
            this.schedule_textbox.Size = new System.Drawing.Size(178, 20);
            this.schedule_textbox.TabIndex = 2;
            // 
            // algorithm_textbox
            // 
            this.algorithm_textbox.Location = new System.Drawing.Point(342, 78);
            this.algorithm_textbox.Name = "algorithm_textbox";
            this.algorithm_textbox.Size = new System.Drawing.Size(178, 20);
            this.algorithm_textbox.TabIndex = 3;
            // 
            // fileInfo_textbox
            // 
            this.fileInfo_textbox.Location = new System.Drawing.Point(342, 111);
            this.fileInfo_textbox.Multiline = true;
            this.fileInfo_textbox.Name = "fileInfo_textbox";
            this.fileInfo_textbox.Size = new System.Drawing.Size(178, 360);
            this.fileInfo_textbox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nombre";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Algoritmo de cifrado";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Planificiación";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(236, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Archivos";
            // 
            // JobList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 497);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileInfo_textbox);
            this.Controls.Add(this.algorithm_textbox);
            this.Controls.Add(this.schedule_textbox);
            this.Controls.Add(this.name_textbox);
            this.Controls.Add(this.workList_listBox);
            this.Name = "JobList";
            this.Text = "JobList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox workList_listBox;
        private System.Windows.Forms.TextBox name_textbox;
        private System.Windows.Forms.TextBox schedule_textbox;
        private System.Windows.Forms.TextBox algorithm_textbox;
        private System.Windows.Forms.TextBox fileInfo_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}