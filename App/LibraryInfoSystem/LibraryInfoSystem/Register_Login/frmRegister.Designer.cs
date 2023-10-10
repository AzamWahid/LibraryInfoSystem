namespace LibraryInfoSystem.Register_Login
{
    partial class frmRegister
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
            this.tbUName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUEmail = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMobileNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCnfmPass = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rbtnStudent = new System.Windows.Forms.RadioButton();
            this.btnRegister = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.linkLableLogin = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbUName
            // 
            this.tbUName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbUName.Location = new System.Drawing.Point(163, 20);
            this.tbUName.Name = "tbUName";
            this.tbUName.Size = new System.Drawing.Size(173, 23);
            this.tbUName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Father Name :";
            // 
            // tbFName
            // 
            this.tbFName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbFName.Location = new System.Drawing.Point(163, 49);
            this.tbFName.Name = "tbFName";
            this.tbFName.Size = new System.Drawing.Size(173, 23);
            this.tbFName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "User Email :";
            // 
            // tbUEmail
            // 
            this.tbUEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.tbUEmail.Location = new System.Drawing.Point(163, 78);
            this.tbUEmail.Name = "tbUEmail";
            this.tbUEmail.Size = new System.Drawing.Size(173, 23);
            this.tbUEmail.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(87, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mobile No. :";
            // 
            // tbMobileNo
            // 
            this.tbMobileNo.Location = new System.Drawing.Point(163, 107);
            this.tbMobileNo.Name = "tbMobileNo";
            this.tbMobileNo.Size = new System.Drawing.Size(173, 23);
            this.tbMobileNo.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(96, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "Password :";
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(163, 136);
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '●';
            this.tbPass.Size = new System.Drawing.Size(173, 23);
            this.tbPass.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Confirm Password :";
            // 
            // tbCnfmPass
            // 
            this.tbCnfmPass.Location = new System.Drawing.Point(163, 165);
            this.tbCnfmPass.Name = "tbCnfmPass";
            this.tbCnfmPass.PasswordChar = '●';
            this.tbCnfmPass.Size = new System.Drawing.Size(173, 23);
            this.tbCnfmPass.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.rbtnStudent);
            this.groupBox1.Location = new System.Drawing.Point(63, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 51);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Type";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(151, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(63, 19);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Faculty";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rbtnStudent
            // 
            this.rbtnStudent.AutoSize = true;
            this.rbtnStudent.Location = new System.Drawing.Point(73, 22);
            this.rbtnStudent.Name = "rbtnStudent";
            this.rbtnStudent.Size = new System.Drawing.Size(66, 19);
            this.rbtnStudent.TabIndex = 0;
            this.rbtnStudent.TabStop = true;
            this.rbtnStudent.Text = "Student";
            this.rbtnStudent.UseVisualStyleBackColor = true;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnRegister.Location = new System.Drawing.Point(47, 257);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(342, 35);
            this.btnRegister.TabIndex = 13;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(122, 365);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Already have an account?";
            // 
            // linkLableLogin
            // 
            this.linkLableLogin.AutoSize = true;
            this.linkLableLogin.Location = new System.Drawing.Point(263, 364);
            this.linkLableLogin.Name = "linkLableLogin";
            this.linkLableLogin.Size = new System.Drawing.Size(66, 15);
            this.linkLableLogin.TabIndex = 15;
            this.linkLableLogin.TabStop = true;
            this.linkLableLogin.Text = "Login here!";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Stencil", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label8.Location = new System.Drawing.Point(30, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(417, 22);
            this.label8.TabIndex = 16;
            this.label8.Text = "Welcome To Library Information System";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRegister);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbCnfmPass);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbPass);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbMobileNo);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbUEmail);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbFName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbUName);
            this.groupBox2.Location = new System.Drawing.Point(26, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 309);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Registration";
            // 
            // frmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(480, 400);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.linkLableLogin);
            this.Controls.Add(this.label7);
            this.Name = "frmRegister";
            this.Text = "Register";
            this.Load += new System.EventHandler(this.frmRegister_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox tbUName;
        private Label label1;
        private Label label2;
        private TextBox tbFName;
        private Label label3;
        private TextBox tbUEmail;
        private Label label4;
        private TextBox tbMobileNo;
        private Label label5;
        private TextBox tbPass;
        private Label label6;
        private TextBox tbCnfmPass;
        private GroupBox groupBox1;
        private RadioButton radioButton1;
        private RadioButton rbtnStudent;
        private Button btnRegister;
        private Label label7;
        private LinkLabel linkLableLogin;
        private Label label8;
        private GroupBox groupBox2;
    }
}