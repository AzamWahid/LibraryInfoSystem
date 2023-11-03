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
            menuStrip2 = new MenuStrip();
            managementToolStripMenuItem = new ToolStripMenuItem();
            changePasswordToolStripMenuItem = new ToolStripMenuItem();
            adminToolStripMenuItem = new ToolStripMenuItem();
            bookManagementToolStripMenuItem = new ToolStripMenuItem();
            imposeFineToolStripMenuItem = new ToolStripMenuItem();
            userToolStripMenuItem = new ToolStripMenuItem();
            borrowToolStripMenuItem = new ToolStripMenuItem();
            borrowReturnToolStripMenuItem = new ToolStripMenuItem();
            finePaymentToolStripMenuItem = new ToolStripMenuItem();
            reportsToolStripMenuItem = new ToolStripMenuItem();
            bookDetailsToolStripMenuItem = new ToolStripMenuItem();
            borrowBooksToolStripMenuItem = new ToolStripMenuItem();
            imposeFineMemberToolStripMenuItem = new ToolStripMenuItem();
            imposeFineDetailsToolStripMenuItem = new ToolStripMenuItem();
            userReportsToolStripMenuItem = new ToolStripMenuItem();
            myBorrowBookToolStripMenuItem = new ToolStripMenuItem();
            myFineDetailsToolStripMenuItem = new ToolStripMenuItem();
            menuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip2
            // 
            menuStrip2.Items.AddRange(new ToolStripItem[] { managementToolStripMenuItem, adminToolStripMenuItem, userToolStripMenuItem, reportsToolStripMenuItem, userReportsToolStripMenuItem });
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(792, 24);
            menuStrip2.TabIndex = 3;
            menuStrip2.Text = "menuStrip2";
            // 
            // managementToolStripMenuItem
            // 
            managementToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { changePasswordToolStripMenuItem });
            managementToolStripMenuItem.Name = "managementToolStripMenuItem";
            managementToolStripMenuItem.Size = new Size(90, 20);
            managementToolStripMenuItem.Text = "Management";
            // 
            // changePasswordToolStripMenuItem
            // 
            changePasswordToolStripMenuItem.Image = Properties.Resources.chnagePass;
            changePasswordToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            changePasswordToolStripMenuItem.Size = new Size(212, 54);
            changePasswordToolStripMenuItem.Text = "Change Password";
            changePasswordToolStripMenuItem.Click += changePasswordToolStripMenuItem_Click;
            // 
            // adminToolStripMenuItem
            // 
            adminToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { bookManagementToolStripMenuItem, imposeFineToolStripMenuItem });
            adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            adminToolStripMenuItem.Size = new Size(55, 20);
            adminToolStripMenuItem.Text = "Admin";
            // 
            // bookManagementToolStripMenuItem
            // 
            bookManagementToolStripMenuItem.BackgroundImageLayout = ImageLayout.Stretch;
            bookManagementToolStripMenuItem.Image = Properties.Resources.NewBook;
            bookManagementToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            bookManagementToolStripMenuItem.Name = "bookManagementToolStripMenuItem";
            bookManagementToolStripMenuItem.Size = new Size(221, 54);
            bookManagementToolStripMenuItem.Text = "Book Management";
            bookManagementToolStripMenuItem.Click += bookManagementToolStripMenuItem_Click;
            // 
            // imposeFineToolStripMenuItem
            // 
            imposeFineToolStripMenuItem.Image = Properties.Resources.Fine;
            imposeFineToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            imposeFineToolStripMenuItem.Name = "imposeFineToolStripMenuItem";
            imposeFineToolStripMenuItem.Size = new Size(221, 54);
            imposeFineToolStripMenuItem.Text = "Impose Fine";
            imposeFineToolStripMenuItem.Click += imposeFineToolStripMenuItem_Click;
            // 
            // userToolStripMenuItem
            // 
            userToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { borrowToolStripMenuItem, borrowReturnToolStripMenuItem, finePaymentToolStripMenuItem });
            userToolStripMenuItem.Name = "userToolStripMenuItem";
            userToolStripMenuItem.Size = new Size(42, 20);
            userToolStripMenuItem.Text = "User";
            // 
            // borrowToolStripMenuItem
            // 
            borrowToolStripMenuItem.Image = Properties.Resources._1245338;
            borrowToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            borrowToolStripMenuItem.Name = "borrowToolStripMenuItem";
            borrowToolStripMenuItem.Size = new Size(193, 54);
            borrowToolStripMenuItem.Text = "Borrow Book";
            borrowToolStripMenuItem.Click += borrowToolStripMenuItem_Click;
            // 
            // borrowReturnToolStripMenuItem
            // 
            borrowReturnToolStripMenuItem.Image = Properties.Resources.returnMenu;
            borrowReturnToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            borrowReturnToolStripMenuItem.Name = "borrowReturnToolStripMenuItem";
            borrowReturnToolStripMenuItem.Size = new Size(193, 54);
            borrowReturnToolStripMenuItem.Text = "Borrow Return";
            borrowReturnToolStripMenuItem.Click += borrowReturnToolStripMenuItem_Click;
            // 
            // finePaymentToolStripMenuItem
            // 
            finePaymentToolStripMenuItem.Image = Properties.Resources.finePay;
            finePaymentToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            finePaymentToolStripMenuItem.Name = "finePaymentToolStripMenuItem";
            finePaymentToolStripMenuItem.Size = new Size(193, 54);
            finePaymentToolStripMenuItem.Text = "Fine Payment";
            finePaymentToolStripMenuItem.Click += finePaymentToolStripMenuItem_Click;
            // 
            // reportsToolStripMenuItem
            // 
            reportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { bookDetailsToolStripMenuItem, borrowBooksToolStripMenuItem, imposeFineMemberToolStripMenuItem, imposeFineDetailsToolStripMenuItem });
            reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            reportsToolStripMenuItem.Size = new Size(98, 20);
            reportsToolStripMenuItem.Text = "Admin Reports";
            // 
            // bookDetailsToolStripMenuItem
            // 
            bookDetailsToolStripMenuItem.Image = Properties.Resources.bookRpt_new;
            bookDetailsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            bookDetailsToolStripMenuItem.Name = "bookDetailsToolStripMenuItem";
            bookDetailsToolStripMenuItem.Size = new Size(218, 54);
            bookDetailsToolStripMenuItem.Text = "Book Details";
            bookDetailsToolStripMenuItem.Click += bookDetailsToolStripMenuItem_Click;
            // 
            // borrowBooksToolStripMenuItem
            // 
            borrowBooksToolStripMenuItem.Image = Properties.Resources.borrowRptNew;
            borrowBooksToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            borrowBooksToolStripMenuItem.Name = "borrowBooksToolStripMenuItem";
            borrowBooksToolStripMenuItem.Size = new Size(218, 54);
            borrowBooksToolStripMenuItem.Text = "Borrow Books";
            borrowBooksToolStripMenuItem.Click += borrowBooksToolStripMenuItem_Click;
            // 
            // imposeFineMemberToolStripMenuItem
            // 
            imposeFineMemberToolStripMenuItem.Image = Properties.Resources.imposeFinememberRpt;
            imposeFineMemberToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            imposeFineMemberToolStripMenuItem.Name = "imposeFineMemberToolStripMenuItem";
            imposeFineMemberToolStripMenuItem.Size = new Size(218, 54);
            imposeFineMemberToolStripMenuItem.Text = "Impose Fine Member";
            imposeFineMemberToolStripMenuItem.Click += imposeFineMemberToolStripMenuItem_Click;
            // 
            // imposeFineDetailsToolStripMenuItem
            // 
            imposeFineDetailsToolStripMenuItem.Image = Properties.Resources.fineDetails;
            imposeFineDetailsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            imposeFineDetailsToolStripMenuItem.Name = "imposeFineDetailsToolStripMenuItem";
            imposeFineDetailsToolStripMenuItem.Size = new Size(218, 54);
            imposeFineDetailsToolStripMenuItem.Text = "Impose Fine Details";
            imposeFineDetailsToolStripMenuItem.Click += imposeFineDetailsToolStripMenuItem_Click;
            // 
            // userReportsToolStripMenuItem
            // 
            userReportsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { myBorrowBookToolStripMenuItem, myFineDetailsToolStripMenuItem });
            userReportsToolStripMenuItem.Name = "userReportsToolStripMenuItem";
            userReportsToolStripMenuItem.Size = new Size(85, 20);
            userReportsToolStripMenuItem.Text = "User Reports";
            // 
            // myBorrowBookToolStripMenuItem
            // 
            myBorrowBookToolStripMenuItem.Image = Properties.Resources.myBorrow;
            myBorrowBookToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            myBorrowBookToolStripMenuItem.Name = "myBorrowBookToolStripMenuItem";
            myBorrowBookToolStripMenuItem.Size = new Size(212, 54);
            myBorrowBookToolStripMenuItem.Text = "My Borrow Book";
            myBorrowBookToolStripMenuItem.Click += myBorrowBookToolStripMenuItem_Click;
            // 
            // myFineDetailsToolStripMenuItem
            // 
            myFineDetailsToolStripMenuItem.Image = Properties.Resources.myFIne;
            myFineDetailsToolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
            myFineDetailsToolStripMenuItem.Name = "myFineDetailsToolStripMenuItem";
            myFineDetailsToolStripMenuItem.Size = new Size(212, 54);
            myFineDetailsToolStripMenuItem.Text = "My Fine Details";
            myFineDetailsToolStripMenuItem.Click += myFineDetailsToolStripMenuItem_Click;
            // 
            // frmMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            BackgroundImage = Properties.Resources._1749;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(792, 422);
            Controls.Add(menuStrip2);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip2;
            Name = "frmMenu";
            Text = "Library Information System";
            WindowState = FormWindowState.Maximized;
            Load += frmMenu_Load;
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private ToolStripMenuItem managementToolStripMenuItem;
        private ToolStripMenuItem changePasswordToolStripMenuItem;
    }
}