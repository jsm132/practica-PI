namespace ESproject.UI
{
    partial class MainUI
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
            this.backupName_label = new System.Windows.Forms.Label();
            this.backup_label = new System.Windows.Forms.Label();
            this.backupDate_label = new System.Windows.Forms.Label();
            this.backupSync_label = new System.Windows.Forms.Label();
            this.backupName_textbox = new System.Windows.Forms.TextBox();
            this.BackupType_textbox = new System.Windows.Forms.TextBox();
            this.backupDate_textbox = new System.Windows.Forms.TextBox();
            this.addBackup_button = new System.Windows.Forms.Button();
            this.restoreBackup_button = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planificaciónToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.añadirToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.verTrabajosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshBackupList = new System.Windows.Forms.Button();
            this.backup_list = new System.Windows.Forms.ListBox();
            this.algorithm_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.opcionesDeCuentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backupName_label
            // 
            this.backupName_label.AutoSize = true;
            this.backupName_label.Location = new System.Drawing.Point(254, 80);
            this.backupName_label.Name = "backupName_label";
            this.backupName_label.Size = new System.Drawing.Size(50, 13);
            this.backupName_label.TabIndex = 1;
            this.backupName_label.Text = "Nombre: ";
            // 
            // backup_label
            // 
            this.backup_label.AutoSize = true;
            this.backup_label.Location = new System.Drawing.Point(13, 61);
            this.backup_label.Name = "backup_label";
            this.backup_label.Size = new System.Drawing.Size(142, 13);
            this.backup_label.TabIndex = 2;
            this.backup_label.Text = "Lista de copias de seguridad";
            // 
            // backupDate_label
            // 
            this.backupDate_label.AutoSize = true;
            this.backupDate_label.Location = new System.Drawing.Point(254, 121);
            this.backupDate_label.Name = "backupDate_label";
            this.backupDate_label.Size = new System.Drawing.Size(43, 13);
            this.backupDate_label.TabIndex = 3;
            this.backupDate_label.Text = "Fecha: ";
            // 
            // backupSync_label
            // 
            this.backupSync_label.AutoSize = true;
            this.backupSync_label.Location = new System.Drawing.Point(254, 163);
            this.backupSync_label.Name = "backupSync_label";
            this.backupSync_label.Size = new System.Drawing.Size(78, 13);
            this.backupSync_label.TabIndex = 4;
            this.backupSync_label.Text = "Tipo de copia: ";
            // 
            // backupName_textbox
            // 
            this.backupName_textbox.Location = new System.Drawing.Point(404, 77);
            this.backupName_textbox.Name = "backupName_textbox";
            this.backupName_textbox.ReadOnly = true;
            this.backupName_textbox.Size = new System.Drawing.Size(100, 20);
            this.backupName_textbox.TabIndex = 5;
            // 
            // BackupType_textbox
            // 
            this.BackupType_textbox.Location = new System.Drawing.Point(404, 160);
            this.BackupType_textbox.Name = "BackupType_textbox";
            this.BackupType_textbox.ReadOnly = true;
            this.BackupType_textbox.Size = new System.Drawing.Size(100, 20);
            this.BackupType_textbox.TabIndex = 6;
            // 
            // backupDate_textbox
            // 
            this.backupDate_textbox.Location = new System.Drawing.Point(404, 118);
            this.backupDate_textbox.Name = "backupDate_textbox";
            this.backupDate_textbox.ReadOnly = true;
            this.backupDate_textbox.Size = new System.Drawing.Size(100, 20);
            this.backupDate_textbox.TabIndex = 7;
            // 
            // addBackup_button
            // 
            this.addBackup_button.Location = new System.Drawing.Point(324, 415);
            this.addBackup_button.Name = "addBackup_button";
            this.addBackup_button.Size = new System.Drawing.Size(113, 23);
            this.addBackup_button.TabIndex = 8;
            this.addBackup_button.Text = "Nuevo trabajo";
            this.addBackup_button.UseVisualStyleBackColor = true;
            this.addBackup_button.Click += new System.EventHandler(this.addBackup_button_Click);
            // 
            // restoreBackup_button
            // 
            this.restoreBackup_button.Location = new System.Drawing.Point(324, 239);
            this.restoreBackup_button.Name = "restoreBackup_button";
            this.restoreBackup_button.Size = new System.Drawing.Size(113, 23);
            this.restoreBackup_button.TabIndex = 9;
            this.restoreBackup_button.Text = "Restaurar ";
            this.restoreBackup_button.UseVisualStyleBackColor = true;
            this.restoreBackup_button.Click += new System.EventHandler(this.restoreBackup_button_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(523, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.planificaciónToolStripMenuItem1,
            this.verTrabajosToolStripMenuItem,
            this.opcionesDeCuentaToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // planificaciónToolStripMenuItem1
            // 
            this.planificaciónToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verToolStripMenuItem1,
            this.añadirToolStripMenuItem1});
            this.planificaciónToolStripMenuItem1.Name = "planificaciónToolStripMenuItem1";
            this.planificaciónToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.planificaciónToolStripMenuItem1.Text = "Planificación";
            this.planificaciónToolStripMenuItem1.Click += new System.EventHandler(this.planificaciónToolStripMenuItem1_Click);
            // 
            // verToolStripMenuItem1
            // 
            this.verToolStripMenuItem1.Name = "verToolStripMenuItem1";
            this.verToolStripMenuItem1.Size = new System.Drawing.Size(109, 22);
            this.verToolStripMenuItem1.Text = "Ver";
            this.verToolStripMenuItem1.Click += new System.EventHandler(this.verToolStripMenuItem1_Click);
            // 
            // añadirToolStripMenuItem1
            // 
            this.añadirToolStripMenuItem1.Name = "añadirToolStripMenuItem1";
            this.añadirToolStripMenuItem1.Size = new System.Drawing.Size(109, 22);
            this.añadirToolStripMenuItem1.Text = "Añadir";
            this.añadirToolStripMenuItem1.Click += new System.EventHandler(this.añadirToolStripMenuItem1_Click);
            // 
            // verTrabajosToolStripMenuItem
            // 
            this.verTrabajosToolStripMenuItem.Name = "verTrabajosToolStripMenuItem";
            this.verTrabajosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.verTrabajosToolStripMenuItem.Text = "Ver trabajos";
            this.verTrabajosToolStripMenuItem.Click += new System.EventHandler(this.verTrabajosToolStripMenuItem_Click);
            // 
            // refreshBackupList
            // 
            this.refreshBackupList.Location = new System.Drawing.Point(16, 416);
            this.refreshBackupList.Name = "refreshBackupList";
            this.refreshBackupList.Size = new System.Drawing.Size(75, 23);
            this.refreshBackupList.TabIndex = 11;
            this.refreshBackupList.Text = "Actualizar";
            this.refreshBackupList.UseVisualStyleBackColor = true;
            this.refreshBackupList.Click += new System.EventHandler(this.refreshBackupList_Click);
            // 
            // backup_list
            // 
            this.backup_list.FormattingEnabled = true;
            this.backup_list.Location = new System.Drawing.Point(13, 80);
            this.backup_list.Name = "backup_list";
            this.backup_list.Size = new System.Drawing.Size(204, 316);
            this.backup_list.TabIndex = 12;
            this.backup_list.SelectedIndexChanged += new System.EventHandler(this.backup_list_SelectedIndexChanged);
            // 
            // algorithm_textbox
            // 
            this.algorithm_textbox.Location = new System.Drawing.Point(404, 200);
            this.algorithm_textbox.Name = "algorithm_textbox";
            this.algorithm_textbox.ReadOnly = true;
            this.algorithm_textbox.Size = new System.Drawing.Size(100, 20);
            this.algorithm_textbox.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(254, 203);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Algoritmo de cifrado: ";
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(296, 318);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(35, 13);
            this.infoLabel.TabIndex = 15;
            this.infoLabel.Text = "label2";
            this.infoLabel.Visible = false;
            // 
            // opcionesDeCuentaToolStripMenuItem
            // 
            this.opcionesDeCuentaToolStripMenuItem.Name = "opcionesDeCuentaToolStripMenuItem";
            this.opcionesDeCuentaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.opcionesDeCuentaToolStripMenuItem.Text = "Opciones de cuenta";
            this.opcionesDeCuentaToolStripMenuItem.Click += new System.EventHandler(this.opcionesDeCuentaToolStripMenuItem_Click);
            // 
            // MainUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 450);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.algorithm_textbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.backup_list);
            this.Controls.Add(this.refreshBackupList);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.restoreBackup_button);
            this.Controls.Add(this.addBackup_button);
            this.Controls.Add(this.backupDate_textbox);
            this.Controls.Add(this.BackupType_textbox);
            this.Controls.Add(this.backupName_textbox);
            this.Controls.Add(this.backupSync_label);
            this.Controls.Add(this.backupDate_label);
            this.Controls.Add(this.backup_label);
            this.Controls.Add(this.backupName_label);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainUI";
            this.Text = "MainUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainUI_FormClosing);
            this.Load += new System.EventHandler(this.MainUI_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label backupName_label;
        private System.Windows.Forms.Label backup_label;
        private System.Windows.Forms.Label backupDate_label;
        private System.Windows.Forms.Label backupSync_label;
        private System.Windows.Forms.TextBox backupName_textbox;
        private System.Windows.Forms.TextBox BackupType_textbox;
        private System.Windows.Forms.TextBox backupDate_textbox;
        private System.Windows.Forms.Button addBackup_button;
        private System.Windows.Forms.Button restoreBackup_button;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planificaciónToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem añadirToolStripMenuItem1;
        private System.Windows.Forms.Button refreshBackupList;
        private System.Windows.Forms.ToolStripMenuItem verTrabajosToolStripMenuItem;
        private System.Windows.Forms.ListBox backup_list;
        private System.Windows.Forms.TextBox algorithm_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.ToolStripMenuItem opcionesDeCuentaToolStripMenuItem;
    }
}