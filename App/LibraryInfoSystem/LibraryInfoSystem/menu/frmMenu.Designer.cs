namespace LibraryInfoSystem.menu
{
    partial class frmMenu
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
            btnBookManagement = new Button();
            btnUserManagement = new Button();
            SuspendLayout();
            // 
            // btnBookManagement
            // 
            btnBookManagement.BackColor = Color.LightGoldenrodYellow;
            btnBookManagement.FlatStyle = FlatStyle.Flat;
            btnBookManagement.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnBookManagement.Image = Properties.Resources.book21;
            btnBookManagement.ImageAlign = ContentAlignment.MiddleLeft;
            btnBookManagement.Location = new Point(27, 132);
            btnBookManagement.Name = "btnBookManagement";
            btnBookManagement.Size = new Size(240, 95);
            btnBookManagement.TabIndex = 1;
            btnBookManagement.Text = "          Book Management";
            btnBookManagement.UseVisualStyleBackColor = false;
            btnBookManagement.Click += btnBookManagement_Click;
            // 
            // btnUserManagement
            // 
            btnUserManagement.BackColor = Color.Wheat;
            btnUserManagement.FlatStyle = FlatStyle.Flat;
            btnUserManagement.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnUserManagement.Image = Properties.Resources.user1;
            btnUserManagement.ImageAlign = ContentAlignment.MiddleLeft;
            btnUserManagement.Location = new Point(27, 22);
            btnUserManagement.Name = "btnUserManagement";
            btnUserManagement.Size = new Size(240, 95);
            btnUserManagement.TabIndex = 0;
            btnUserManagement.Text = "          User Management";
            btnUserManagement.UseVisualStyleBackColor = false;
            btnUserManagement.Click += btnUserManagement_Click;
            // 
            // frmMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 422);
            Controls.Add(btnBookManagement);
            Controls.Add(btnUserManagement);
            IsMdiContainer = true;
            Name = "frmMenu";
            Text = "frmMenu";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem asdasToolStripMenuItem;
        private ToolStripMenuItem asdasdToolStripMenuItem;
        private Button button1;
        private Button button2;
        private Button btnBookManagement;
        private Button btnUserManagement;
    }
}