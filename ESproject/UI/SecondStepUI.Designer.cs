namespace ESproject.UI
{
    partial class SecondStepUI
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
            this.step_message_label = new System.Windows.Forms.Label();
            this.code_step_textbox = new System.Windows.Forms.TextBox();
            this.step_button = new System.Windows.Forms.Button();
            this.step_error_message_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // step_message_label
            // 
            this.step_message_label.AutoSize = true;
            this.step_message_label.Location = new System.Drawing.Point(23, 43);
            this.step_message_label.Name = "step_message_label";
            this.step_message_label.Size = new System.Drawing.Size(471, 17);
            this.step_message_label.TabIndex = 0;
            this.step_message_label.Text = "Por favor, introduzca el código que se ha enviado a su correo electrónico";
            // 
            // code_step_textbox
            // 
            this.code_step_textbox.Location = new System.Drawing.Point(141, 102);
            this.code_step_textbox.Name = "code_step_textbox";
            this.code_step_textbox.Size = new System.Drawing.Size(214, 22);
            this.code_step_textbox.TabIndex = 1;
            // 
            // step_button
            // 
            this.step_button.Location = new System.Drawing.Point(203, 176);
            this.step_button.Name = "step_button";
            this.step_button.Size = new System.Drawing.Size(84, 28);
            this.step_button.TabIndex = 2;
            this.step_button.Text = "Enviar";
            this.step_button.UseVisualStyleBackColor = true;
            this.step_button.Click += new System.EventHandler(this.step_button_Click);
            // 
            // step_error_message_label
            // 
            this.step_error_message_label.AutoSize = true;
            this.step_error_message_label.ForeColor = System.Drawing.Color.Red;
            this.step_error_message_label.Location = new System.Drawing.Point(160, 140);
            this.step_error_message_label.Name = "step_error_message_label";
            this.step_error_message_label.Size = new System.Drawing.Size(177, 17);
            this.step_error_message_label.TabIndex = 3;
            this.step_error_message_label.Text = "step_error_message_label";
            this.step_error_message_label.Visible = false;
            // 
            // SecondStepUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 227);
            this.Controls.Add(this.step_error_message_label);
            this.Controls.Add(this.step_button);
            this.Controls.Add(this.code_step_textbox);
            this.Controls.Add(this.step_message_label);
            this.Name = "SecondStepUI";
            this.Text = "SecondStepUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label step_message_label;
        private System.Windows.Forms.TextBox code_step_textbox;
        private System.Windows.Forms.Button step_button;
        private System.Windows.Forms.Label step_error_message_label;
    }
}