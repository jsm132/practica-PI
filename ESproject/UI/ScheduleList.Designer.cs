namespace ESproject.UI
{
    partial class ScheduleList
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
            this.planName_List = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NameInfo_Textbox = new System.Windows.Forms.TextBox();
            this.dayInfo_TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // planName_List
            // 
            this.planName_List.FormattingEnabled = true;
            this.planName_List.Location = new System.Drawing.Point(12, 12);
            this.planName_List.Name = "planName_List";
            this.planName_List.Size = new System.Drawing.Size(222, 420);
            this.planName_List.TabIndex = 0;
            this.planName_List.SelectedIndexChanged += new System.EventHandler(this.planName_List_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(273, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre:";
            // 
            // NameInfo_Textbox
            // 
            this.NameInfo_Textbox.Location = new System.Drawing.Point(366, 12);
            this.NameInfo_Textbox.Name = "NameInfo_Textbox";
            this.NameInfo_Textbox.Size = new System.Drawing.Size(186, 20);
            this.NameInfo_Textbox.TabIndex = 2;
            // 
            // dayInfo_TextBox
            // 
            this.dayInfo_TextBox.Location = new System.Drawing.Point(366, 51);
            this.dayInfo_TextBox.Multiline = true;
            this.dayInfo_TextBox.Name = "dayInfo_TextBox";
            this.dayInfo_TextBox.Size = new System.Drawing.Size(186, 381);
            this.dayInfo_TextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Días:";
            // 
            // ScheduleList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dayInfo_TextBox);
            this.Controls.Add(this.NameInfo_Textbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.planName_List);
            this.Name = "ScheduleList";
            this.Text = "ScheduleList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox planName_List;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameInfo_Textbox;
        private System.Windows.Forms.TextBox dayInfo_TextBox;
        private System.Windows.Forms.Label label2;
    }
}