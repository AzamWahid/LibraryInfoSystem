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
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrowReturnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imposeFineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.userToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(792, 24);
            this.menuStrip2.TabIndex = 3;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookManagementToolStripMenuItem,
            this.imposeFineToolStripMenuItem});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // bookManagementToolStripMenuItem
            // 
            this.bookManagementToolStripMenuItem.Name = "bookManagementToolStripMenuItem";
            this.bookManagementToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bookManagementToolStripMenuItem.Text = "Book Management";
            this.bookManagementToolStripMenuItem.Click += new System.EventHandler(this.bookManagementToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.borrowToolStripMenuItem,
            this.borrowReturnToolStripMenuItem});
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.userToolStripMenuItem.Text = "User";
            // 
            // borrowToolStripMenuItem
            // 
            this.borrowToolStripMenuItem.Name = "borrowToolStripMenuItem";
            this.borrowToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.borrowToolStripMenuItem.Text = "Borrow Book";
            this.borrowToolStripMenuItem.Click += new System.EventHandler(this.borrowToolStripMenuItem_Click);
            // 
            // borrowReturnToolStripMenuItem
            // 
            this.borrowReturnToolStripMenuItem.Name = "borrowReturnToolStripMenuItem";
            this.borrowReturnToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.borrowReturnToolStripMenuItem.Text = "Borrow Return";
            this.borrowReturnToolStripMenuItem.Click += new System.EventHandler(this.borrowReturnToolStripMenuItem_Click);
            // 
            // imposeFineToolStripMenuItem
            // 
            this.imposeFineToolStripMenuItem.Name = "imposeFineToolStripMenuItem";
            this.imposeFineToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.imposeFineToolStripMenuItem.Text = "Impose Fine";
            this.imposeFineToolStripMenuItem.Click += new System.EventHandler(this.imposeFineToolStripMenuItem_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 422);
            this.Controls.Add(this.menuStrip2);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "frmMenu";
            this.Text = "Library Information System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem asdasToolStripMenuItem;
        private ToolStripMenuItem asdasdToolStripMenuItem;
        private Button button1;
        private Button button2;
        private Button btnBookManagement;
        private Button btnUserManagement;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem adminToolStripMenuItem;
        private ToolStripMenuItem bookManagementToolStripMenuItem;
        private ToolStripMenuItem userToolStripMenuItem;
        private ToolStripMenuItem borrowToolStripMenuItem;
        private ToolStripMenuItem borrowReturnToolStripMenuItem;
        private ToolStripMenuItem imposeFineToolStripMenuItem;
    }
}