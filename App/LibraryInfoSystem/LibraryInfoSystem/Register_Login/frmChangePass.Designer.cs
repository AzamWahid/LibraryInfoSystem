namespace LibraryInfoSystem.Register_Login
{
    partial class frmChangePass
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
            this.label3 = new System.Windows.Forms.Label();
            this.tbCurrPass = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNewPass = new System.Windows.Forms.TextBox();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbReNewPass = new System.Windows.Forms.TextBox();
            this.tbUEmail = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Current Password :";
            // 
            // tbCurrPass
            // 
            this.tbCurrPass.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.tbCurrPass.Location = new System.Drawing.Point(159, 88);
            this.tbCurrPass.Name = "tbCurrPass";
            this.tbCurrPass.PasswordChar = '●';
            this.tbCurrPass.Size = new System.Drawing.Size(227, 23);
            this.tbCurrPass.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(69, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "New Password :";
            // 
            // tbNewPass
            // 
            this.tbNewPass.Location = new System.Drawing.Point(159, 117);
            this.tbNewPass.Name = "tbNewPass";
            this.tbNewPass.PasswordChar = '●';
            this.tbNewPass.Size = new System.Drawing.Size(227, 23);
            this.tbNewPass.TabIndex = 8;
            // 
            // btnChangePass
            // 
            this.btnChangePass.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnChangePass.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnChangePass.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnChangePass.Location = new System.Drawing.Point(174, 185);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(173, 35);
            this.btnChangePass.TabIndex = 13;
            this.btnChangePass.Text = "Change";
            this.btnChangePass.UseVisualStyleBackColor = false;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(82, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 31);
            this.label1.TabIndex = 16;
            this.label1.Text = "CHANGE PASSWORD";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Re-enter New Password :";
            // 
            // tbReNewPass
            // 
            this.tbReNewPass.Location = new System.Drawing.Point(159, 146);
            this.tbReNewPass.Name = "tbReNewPass";
            this.tbReNewPass.PasswordChar = '●';
            this.tbReNewPass.Size = new System.Drawing.Size(227, 23);
            this.tbReNewPass.TabIndex = 10;
            // 
            // tbUEmail
            // 
            this.tbUEmail.BackColor = System.Drawing.Color.White;
            this.tbUEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbUEmail.Font = new System.Drawing.Font("Calibri", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.tbUEmail.ForeColor = System.Drawing.Color.Purple;
            this.tbUEmail.Location = new System.Drawing.Point(159, 53);
            this.tbUEmail.Name = "tbUEmail";
            this.tbUEmail.Size = new System.Drawing.Size(227, 29);
            this.tbUEmail.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 15);
            this.label4.TabIndex = 33;
            this.label4.Text = "User Email :";
            // 
            // frmChangePass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(452, 229);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbUEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbReNewPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnChangePass);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbNewPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbCurrPass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "frmChangePass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            this.Load += new System.EventHandler(this.frmChangePass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label3;
        private TextBox tbCurrPass;
        private Label label5;
        private TextBox tbNewPass;
        private Button btnChangePass;
        private Label label1;
        private Label label2;
        private TextBox tbReNewPass;
        private Label tbUEmail;
        private Label label4;
    }
}