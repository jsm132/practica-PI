namespace ESproject.UI
{
    partial class Register
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            this.password_label = new System.Windows.Forms.Label();
            this.mail_label = new System.Windows.Forms.Label();
            this.password_textbox = new System.Windows.Forms.TextBox();
            this.mail_textbox = new System.Windows.Forms.TextBox();
            this.check_label = new System.Windows.Forms.Label();
            this.check_textbox = new System.Windows.Forms.TextBox();
            this.register_button = new System.Windows.Forms.Button();
            this.error_message_label = new System.Windows.Forms.Label();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.user_registered_message_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Location = new System.Drawing.Point(72, 172);
            this.password_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(81, 17);
            this.password_label.TabIndex = 7;
            this.password_label.Text = "Contraseña";
            this.password_label.Click += new System.EventHandler(this.password_label_Click);
            // 
            // mail_label
            // 
            this.mail_label.AutoSize = true;
            this.mail_label.Location = new System.Drawing.Point(53, 129);
            this.mail_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mail_label.Name = "mail_label";
            this.mail_label.Size = new System.Drawing.Size(124, 17);
            this.mail_label.TabIndex = 6;
            this.mail_label.Text = "Correo electrónico";
            this.mail_label.Click += new System.EventHandler(this.mail_label_Click);
            // 
            // password_textbox
            // 
            this.password_textbox.Location = new System.Drawing.Point(200, 172);
            this.password_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.password_textbox.Name = "password_textbox";
            this.password_textbox.Size = new System.Drawing.Size(132, 22);
            this.password_textbox.TabIndex = 5;
            this.password_textbox.UseSystemPasswordChar = true;
            this.password_textbox.TextChanged += new System.EventHandler(this.password_textbox_TextChanged);
            // 
            // mail_textbox
            // 
            this.mail_textbox.Location = new System.Drawing.Point(200, 129);
            this.mail_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.mail_textbox.Name = "mail_textbox";
            this.mail_textbox.Size = new System.Drawing.Size(132, 22);
            this.mail_textbox.TabIndex = 4;
            this.mail_textbox.TextChanged += new System.EventHandler(this.mail_textbox_TextChanged);
            // 
            // check_label
            // 
            this.check_label.AutoSize = true;
            this.check_label.Location = new System.Drawing.Point(33, 221);
            this.check_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.check_label.Name = "check_label";
            this.check_label.Size = new System.Drawing.Size(144, 17);
            this.check_label.TabIndex = 9;
            this.check_label.Text = "Confirmar contraseña";
            this.check_label.Click += new System.EventHandler(this.check_label_Click);
            // 
            // check_textbox
            // 
            this.check_textbox.Location = new System.Drawing.Point(200, 216);
            this.check_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.check_textbox.Name = "check_textbox";
            this.check_textbox.Size = new System.Drawing.Size(132, 22);
            this.check_textbox.TabIndex = 8;
            this.check_textbox.UseSystemPasswordChar = true;
            this.check_textbox.TextChanged += new System.EventHandler(this.check_textbox_TextChanged);
            // 
            // register_button
            // 
            this.register_button.Location = new System.Drawing.Point(147, 366);
            this.register_button.Margin = new System.Windows.Forms.Padding(4);
            this.register_button.Name = "register_button";
            this.register_button.Size = new System.Drawing.Size(113, 36);
            this.register_button.TabIndex = 10;
            this.register_button.Text = "Registrarse";
            this.register_button.UseVisualStyleBackColor = true;
            this.register_button.Click += new System.EventHandler(this.register_button_Click);
            // 
            // error_message_label
            // 
            this.error_message_label.AutoSize = true;
            this.error_message_label.ForeColor = System.Drawing.Color.Red;
            this.error_message_label.Location = new System.Drawing.Point(33, 313);
            this.error_message_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.error_message_label.Name = "error_message_label";
            this.error_message_label.Size = new System.Drawing.Size(116, 17);
            this.error_message_label.TabIndex = 11;
            this.error_message_label.Text = "Mensaje de error";
            this.error_message_label.Visible = false;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // user_registered_message_label
            // 
            this.user_registered_message_label.AutoSize = true;
            this.user_registered_message_label.Location = new System.Drawing.Point(113, 279);
            this.user_registered_message_label.Name = "user_registered_message_label";
            this.user_registered_message_label.Size = new System.Drawing.Size(185, 17);
            this.user_registered_message_label.TabIndex = 12;
            this.user_registered_message_label.Text = "Usuario registrado con éxito";
            this.user_registered_message_label.Visible = false;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 441);
            this.Controls.Add(this.user_registered_message_label);
            this.Controls.Add(this.error_message_label);
            this.Controls.Add(this.register_button);
            this.Controls.Add(this.check_label);
            this.Controls.Add(this.check_textbox);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.mail_label);
            this.Controls.Add(this.password_textbox);
            this.Controls.Add(this.mail_textbox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Register";
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Label mail_label;
        private System.Windows.Forms.TextBox password_textbox;
        private System.Windows.Forms.TextBox mail_textbox;
        private System.Windows.Forms.Label check_label;
        private System.Windows.Forms.TextBox check_textbox;
        private System.Windows.Forms.Button register_button;
        private System.Windows.Forms.Label error_message_label;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.Label user_registered_message_label;
    }
}