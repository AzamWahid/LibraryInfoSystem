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
            this.imposeFineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrowReturnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finePaymentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrowBooksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imposeFineMemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imposeFineDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userReportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myBorrowBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myFineDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.userToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.userReportsToolStripMenuItem});
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
            this.bookManagementToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.bookManagementToolStripMenuItem.Text = "Book Management";
            this.bookManagementToolStripMenuItem.Click += new System.EventHandler(this.bookManagementToolStripMenuItem_Click);
            // 
            // imposeFineToolStripMenuItem
            // 
            this.imposeFineToolStripMenuItem.Name = "imposeFineToolStripMenuItem";
            this.imposeFineToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.imposeFineToolStripMenuItem.Text = "Impose Fine";
            this.imposeFineToolStripMenuItem.Click += new System.EventHandler(this.imposeFineToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.borrowToolStripMenuItem,
            this.borrowReturnToolStripMenuItem,
            this.finePaymentToolStripMenuItem});
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
            // finePaymentToolStripMenuItem
            // 
            this.finePaymentToolStripMenuItem.Name = "finePaymentToolStripMenuItem";
            this.finePaymentToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.finePaymentToolStripMenuItem.Text = "Fine Payment";
            this.finePaymentToolStripMenuItem.Click += new System.EventHandler(this.finePaymentToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookDetailsToolStripMenuItem,
            this.borrowBooksToolStripMenuItem,
            this.imposeFineMemberToolStripMenuItem,
            this.imposeFineDetailsToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.reportsToolStripMenuItem.Text = "Admin Reports";
            // 
            // bookDetailsToolStripMenuItem
            // 
            this.bookDetailsToolStripMenuItem.Name = "bookDetailsToolStripMenuItem";
            this.bookDetailsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.bookDetailsToolStripMenuItem.Text = "Book Details";
            this.bookDetailsToolStripMenuItem.Click += new System.EventHandler(this.bookDetailsToolStripMenuItem_Click);
            // 
            // borrowBooksToolStripMenuItem
            // 
            this.borrowBooksToolStripMenuItem.Name = "borrowBooksToolStripMenuItem";
            this.borrowBooksToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.borrowBooksToolStripMenuItem.Text = "Borrow Books";
            this.borrowBooksToolStripMenuItem.Click += new System.EventHandler(this.borrowBooksToolStripMenuItem_Click);
            // 
            // imposeFineMemberToolStripMenuItem
            // 
            this.imposeFineMemberToolStripMenuItem.Name = "imposeFineMemberToolStripMenuItem";
            this.imposeFineMemberToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.imposeFineMemberToolStripMenuItem.Text = "Impose Fine Member";
            this.imposeFineMemberToolStripMenuItem.Click += new System.EventHandler(this.imposeFineMemberToolStripMenuItem_Click);
            // 
            // imposeFineDetailsToolStripMenuItem
            // 
            this.imposeFineDetailsToolStripMenuItem.Name = "imposeFineDetailsToolStripMenuItem";
            this.imposeFineDetailsToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.imposeFineDetailsToolStripMenuItem.Text = "Impose Fine Details";
            this.imposeFineDetailsToolStripMenuItem.Click += new System.EventHandler(this.imposeFineDetailsToolStripMenuItem_Click);
            // 
            // userReportsToolStripMenuItem
            // 
            this.userReportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.myBorrowBookToolStripMenuItem,
            this.myFineDetailsToolStripMenuItem});
            this.userReportsToolStripMenuItem.Name = "userReportsToolStripMenuItem";
            this.userReportsToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.userReportsToolStripMenuItem.Text = "User Reports";
            // 
            // myBorrowBookToolStripMenuItem
            // 
            this.myBorrowBookToolStripMenuItem.Name = "myBorrowBookToolStripMenuItem";
            this.myBorrowBookToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.myBorrowBookToolStripMenuItem.Text = "My Borrow Book";
            this.myBorrowBookToolStripMenuItem.Click += new System.EventHandler(this.myBorrowBookToolStripMenuItem_Click);
            // 
            // myFineDetailsToolStripMenuItem
            // 
            this.myFineDetailsToolStripMenuItem.Name = "myFineDetailsToolStripMenuItem";
            this.myFineDetailsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.myFineDetailsToolStripMenuItem.Text = "My Fine Details";
            this.myFineDetailsToolStripMenuItem.Click += new System.EventHandler(this.myFineDetailsToolStripMenuItem_Click);
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
            this.Load += new System.EventHandler(this.frmMenu_Load);
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
        private ToolStripMenuItem finePaymentToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem reportsToolStripMenuItem;
        private ToolStripMenuItem bookDetailsToolStripMenuItem;
        private ToolStripMenuItem borrowBooksToolStripMenuItem;
        private ToolStripMenuItem imposeFineMemberToolStripMenuItem;
        private ToolStripMenuItem imposeFineDetailsToolStripMenuItem;
        private ToolStripMenuItem userReportsToolStripMenuItem;
        private ToolStripMenuItem myBorrowBookToolStripMenuItem;
        private ToolStripMenuItem myFineDetailsToolStripMenuItem;
    }
}