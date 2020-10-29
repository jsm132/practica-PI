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
            this.step_message_label.Location = new System.Drawing.Point(17, 35);
            this.step_message_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.step_message_label.Name = "step_message_label";
            this.step_message_label.Size = new System.Drawing.Size(395, 13);
            this.step_message_label.TabIndex = 0;
            this.step_message_label.Text = "Por favor, introduzca el código que se le ha enviado por medio del bot de telegra" +
    "m";
            this.step_message_label.Click += new System.EventHandler(this.step_message_label_Click);
            // 
            // code_step_textbox
            // 
            this.code_step_textbox.Location = new System.Drawing.Point(135, 76);
            this.code_step_textbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.code_step_textbox.Name = "code_step_textbox";
            this.code_step_textbox.Size = new System.Drawing.Size(162, 20);
            this.code_step_textbox.TabIndex = 1;
            // 
            // step_button
            // 
            this.step_button.Location = new System.Drawing.Point(181, 136);
            this.step_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.step_button.Name = "step_button";
            this.step_button.Size = new System.Drawing.Size(63, 23);
            this.step_button.TabIndex = 2;
            this.step_button.Text = "Enviar";
            this.step_button.UseVisualStyleBackColor = true;
            this.step_button.Click += new System.EventHandler(this.step_button_Click);
            // 
            // step_error_message_label
            // 
            this.step_error_message_label.AutoSize = true;
            this.step_error_message_label.ForeColor = System.Drawing.Color.Red;
            this.step_error_message_label.Location = new System.Drawing.Point(149, 107);
            this.step_error_message_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.step_error_message_label.Name = "step_error_message_label";
            this.step_error_message_label.Size = new System.Drawing.Size(130, 13);
            this.step_error_message_label.TabIndex = 3;
            this.step_error_message_label.Text = "step_error_message_label";
            this.step_error_message_label.Visible = false;
            // 
            // SecondStepUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 184);
            this.Controls.Add(this.step_error_message_label);
            this.Controls.Add(this.step_button);
            this.Controls.Add(this.code_step_textbox);
            this.Controls.Add(this.step_message_label);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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