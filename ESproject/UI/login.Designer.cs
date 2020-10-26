namespace ESproject
{
    partial class login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.user_textbox = new System.Windows.Forms.TextBox();
            this.password_textbox = new System.Windows.Forms.TextBox();
            this.user_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.login_button = new System.Windows.Forms.Button();
            this.register_button = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.error_message_label = new System.Windows.Forms.Label();
            this.loadingLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // user_textbox
            // 
            this.user_textbox.Location = new System.Drawing.Point(104, 215);
            this.user_textbox.Name = "user_textbox";
            this.user_textbox.Size = new System.Drawing.Size(100, 20);
            this.user_textbox.TabIndex = 0;
            // 
            // password_textbox
            // 
            this.password_textbox.Location = new System.Drawing.Point(104, 268);
            this.password_textbox.Name = "password_textbox";
            this.password_textbox.Size = new System.Drawing.Size(100, 20);
            this.password_textbox.TabIndex = 1;
            this.password_textbox.UseSystemPasswordChar = true;
            // 
            // user_label
            // 
            this.user_label.AutoSize = true;
            this.user_label.Location = new System.Drawing.Point(40, 218);
            this.user_label.Name = "user_label";
            this.user_label.Size = new System.Drawing.Size(43, 13);
            this.user_label.TabIndex = 2;
            this.user_label.Text = "Usuario";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.Location = new System.Drawing.Point(40, 271);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(61, 13);
            this.password_label.TabIndex = 3;
            this.password_label.Text = "Contraseña";
            // 
            // login_button
            // 
            this.login_button.Location = new System.Drawing.Point(101, 334);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(103, 37);
            this.login_button.TabIndex = 4;
            this.login_button.Text = "Entrar";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // register_button
            // 
            this.register_button.Location = new System.Drawing.Point(101, 377);
            this.register_button.Name = "register_button";
            this.register_button.Size = new System.Drawing.Size(103, 39);
            this.register_button.TabIndex = 5;
            this.register_button.Text = "Registrarse";
            this.register_button.UseVisualStyleBackColor = true;
            this.register_button.Click += new System.EventHandler(this.register_button_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(55, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(223, 164);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // error_message_label
            // 
            this.error_message_label.AutoSize = true;
            this.error_message_label.ForeColor = System.Drawing.Color.Red;
            this.error_message_label.Location = new System.Drawing.Point(98, 305);
            this.error_message_label.Name = "error_message_label";
            this.error_message_label.Size = new System.Drawing.Size(86, 13);
            this.error_message_label.TabIndex = 7;
            this.error_message_label.Text = "Mensaje de error";
            this.error_message_label.Visible = false;
            // 
            // loadingLabel
            // 
            this.loadingLabel.AutoSize = true;
            this.loadingLabel.Location = new System.Drawing.Point(52, 429);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(247, 13);
            this.loadingLabel.TabIndex = 8;
            this.loadingLabel.Text = "Descargando datos del usuario. Espere por favor...";
            this.loadingLabel.Visible = false;
            // 
            // login
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(330, 451);
            this.Controls.Add(this.loadingLabel);
            this.Controls.Add(this.error_message_label);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.register_button);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.user_label);
            this.Controls.Add(this.password_textbox);
            this.Controls.Add(this.user_textbox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "login";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox user_textbox;
        private System.Windows.Forms.TextBox password_textbox;
        private System.Windows.Forms.Label user_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.Button register_button;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label error_message_label;
        private System.Windows.Forms.Label loadingLabel;
    }
}

