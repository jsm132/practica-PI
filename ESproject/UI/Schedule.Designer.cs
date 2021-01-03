namespace ESproject.UI
{
    partial class schedule
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
            this.weekSelect_comboBox = new System.Windows.Forms.ComboBox();
            this.daySelect_comboBox = new System.Windows.Forms.ComboBox();
            this.backupType_comboBox = new System.Windows.Forms.ComboBox();
            this.createSchedule_Button = new System.Windows.Forms.Button();
            this.cancelSchedule_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.planName_Label = new System.Windows.Forms.Label();
            this.planName_TextBox = new System.Windows.Forms.TextBox();
            this.hour_comboBox = new System.Windows.Forms.ComboBox();
            this.minute_comboBox = new System.Windows.Forms.ComboBox();
            this.scheduleShow_TextBox = new System.Windows.Forms.TextBox();
            this.addDay_Button = new System.Windows.Forms.Button();
            this.repeatedName_Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // weekSelect_comboBox
            // 
            this.weekSelect_comboBox.FormattingEnabled = true;
            this.weekSelect_comboBox.Items.AddRange(new object[] {
            "Primer",
            "Segundo",
            "Tercer",
            "Cuarto",
            "Último"});
            this.weekSelect_comboBox.Location = new System.Drawing.Point(27, 77);
            this.weekSelect_comboBox.Name = "weekSelect_comboBox";
            this.weekSelect_comboBox.Size = new System.Drawing.Size(121, 21);
            this.weekSelect_comboBox.TabIndex = 0;
            this.weekSelect_comboBox.SelectedIndexChanged += new System.EventHandler(this.weekSelect_comboBox_SelectedIndexChanged);
            // 
            // daySelect_comboBox
            // 
            this.daySelect_comboBox.FormattingEnabled = true;
            this.daySelect_comboBox.Items.AddRange(new object[] {
            "Lunes",
            "Martes",
            "Miércoles",
            "Jueves",
            "Viernes",
            "Sábado",
            "Domingo"});
            this.daySelect_comboBox.Location = new System.Drawing.Point(154, 77);
            this.daySelect_comboBox.Name = "daySelect_comboBox";
            this.daySelect_comboBox.Size = new System.Drawing.Size(121, 21);
            this.daySelect_comboBox.TabIndex = 1;
            this.daySelect_comboBox.SelectedIndexChanged += new System.EventHandler(this.daySelect_comboBox_SelectedIndexChanged);
            // 
            // backupType_comboBox
            // 
            this.backupType_comboBox.FormattingEnabled = true;
            this.backupType_comboBox.Items.AddRange(new object[] {
            "Completo",
            "Incremental"});
            this.backupType_comboBox.Location = new System.Drawing.Point(281, 77);
            this.backupType_comboBox.Name = "backupType_comboBox";
            this.backupType_comboBox.Size = new System.Drawing.Size(121, 21);
            this.backupType_comboBox.TabIndex = 2;
            this.backupType_comboBox.SelectedIndexChanged += new System.EventHandler(this.backupType_comboBox_SelectedIndexChanged);
            // 
            // createSchedule_Button
            // 
            this.createSchedule_Button.Enabled = false;
            this.createSchedule_Button.Location = new System.Drawing.Point(253, 415);
            this.createSchedule_Button.Name = "createSchedule_Button";
            this.createSchedule_Button.Size = new System.Drawing.Size(75, 23);
            this.createSchedule_Button.TabIndex = 7;
            this.createSchedule_Button.Text = "Crear";
            this.createSchedule_Button.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.createSchedule_Button.UseVisualStyleBackColor = true;
            this.createSchedule_Button.Click += new System.EventHandler(this.createSchedule_Button_Click);
            // 
            // cancelSchedule_Button
            // 
            this.cancelSchedule_Button.Location = new System.Drawing.Point(335, 415);
            this.cancelSchedule_Button.Name = "cancelSchedule_Button";
            this.cancelSchedule_Button.Size = new System.Drawing.Size(75, 23);
            this.cancelSchedule_Button.TabIndex = 8;
            this.cancelSchedule_Button.Text = "Cancelar";
            this.cancelSchedule_Button.UseVisualStyleBackColor = true;
            this.cancelSchedule_Button.Click += new System.EventHandler(this.cancelSchedule_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Semana";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Día";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Tipo de copia";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(134, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "hora";
            // 
            // planName_Label
            // 
            this.planName_Label.AutoSize = true;
            this.planName_Label.Location = new System.Drawing.Point(24, 9);
            this.planName_Label.Name = "planName_Label";
            this.planName_Label.Size = new System.Drawing.Size(84, 13);
            this.planName_Label.TabIndex = 13;
            this.planName_Label.Text = "Nombre del plan";
            // 
            // planName_TextBox
            // 
            this.planName_TextBox.Location = new System.Drawing.Point(27, 25);
            this.planName_TextBox.Name = "planName_TextBox";
            this.planName_TextBox.Size = new System.Drawing.Size(126, 20);
            this.planName_TextBox.TabIndex = 14;
            this.planName_TextBox.TextChanged += new System.EventHandler(this.planName_TextBox_TextChanged_1);
            // 
            // hour_comboBox
            // 
            this.hour_comboBox.FormattingEnabled = true;
            this.hour_comboBox.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.hour_comboBox.Location = new System.Drawing.Point(168, 118);
            this.hour_comboBox.Name = "hour_comboBox";
            this.hour_comboBox.Size = new System.Drawing.Size(45, 21);
            this.hour_comboBox.TabIndex = 15;
            this.hour_comboBox.SelectedIndexChanged += new System.EventHandler(this.hour_comboBox_SelectedIndexChanged);
            // 
            // minute_comboBox
            // 
            this.minute_comboBox.FormattingEnabled = true;
            this.minute_comboBox.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.minute_comboBox.Location = new System.Drawing.Point(219, 118);
            this.minute_comboBox.Name = "minute_comboBox";
            this.minute_comboBox.Size = new System.Drawing.Size(45, 21);
            this.minute_comboBox.TabIndex = 16;
            this.minute_comboBox.SelectedIndexChanged += new System.EventHandler(this.minute_comboBox_SelectedIndexChanged);
            // 
            // scheduleShow_TextBox
            // 
            this.scheduleShow_TextBox.Location = new System.Drawing.Point(68, 191);
            this.scheduleShow_TextBox.Multiline = true;
            this.scheduleShow_TextBox.Name = "scheduleShow_TextBox";
            this.scheduleShow_TextBox.ReadOnly = true;
            this.scheduleShow_TextBox.Size = new System.Drawing.Size(291, 189);
            this.scheduleShow_TextBox.TabIndex = 17;
            // 
            // addDay_Button
            // 
            this.addDay_Button.Enabled = false;
            this.addDay_Button.Location = new System.Drawing.Point(159, 162);
            this.addDay_Button.Name = "addDay_Button";
            this.addDay_Button.Size = new System.Drawing.Size(105, 23);
            this.addDay_Button.TabIndex = 18;
            this.addDay_Button.Text = "Añadir día al plan";
            this.addDay_Button.UseVisualStyleBackColor = true;
            this.addDay_Button.Click += new System.EventHandler(this.addDay_Button_Click);
            // 
            // repeatedName_Label
            // 
            this.repeatedName_Label.AutoSize = true;
            this.repeatedName_Label.ForeColor = System.Drawing.Color.Red;
            this.repeatedName_Label.Location = new System.Drawing.Point(134, 391);
            this.repeatedName_Label.Name = "repeatedName_Label";
            this.repeatedName_Label.Size = new System.Drawing.Size(170, 13);
            this.repeatedName_Label.TabIndex = 19;
            this.repeatedName_Label.Text = "Ya existe un plan con este nombre";
            this.repeatedName_Label.Visible = false;
            // 
            // schedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 450);
            this.Controls.Add(this.repeatedName_Label);
            this.Controls.Add(this.addDay_Button);
            this.Controls.Add(this.scheduleShow_TextBox);
            this.Controls.Add(this.minute_comboBox);
            this.Controls.Add(this.hour_comboBox);
            this.Controls.Add(this.planName_TextBox);
            this.Controls.Add(this.planName_Label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelSchedule_Button);
            this.Controls.Add(this.createSchedule_Button);
            this.Controls.Add(this.backupType_comboBox);
            this.Controls.Add(this.daySelect_comboBox);
            this.Controls.Add(this.weekSelect_comboBox);
            this.Name = "schedule";
            this.Text = "schedule";
            this.Load += new System.EventHandler(this.schedule_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox weekSelect_comboBox;
        private System.Windows.Forms.ComboBox daySelect_comboBox;
        private System.Windows.Forms.ComboBox backupType_comboBox;
        private System.Windows.Forms.Button createSchedule_Button;
        private System.Windows.Forms.Button cancelSchedule_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label planName_Label;
        private System.Windows.Forms.TextBox planName_TextBox;
        private System.Windows.Forms.ComboBox hour_comboBox;
        private System.Windows.Forms.ComboBox minute_comboBox;
        private System.Windows.Forms.TextBox scheduleShow_TextBox;
        private System.Windows.Forms.Button addDay_Button;
        private System.Windows.Forms.Label repeatedName_Label;
    }
}