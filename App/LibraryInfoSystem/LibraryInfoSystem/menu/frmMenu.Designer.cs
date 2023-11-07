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
            this.components = new System.ComponentModel.Container();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.managementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.btnChangePass = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutToolStripMenuItem,
            this.managementToolStripMenuItem,
            this.adminToolStripMenuItem,
            this.userToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.userReportsToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1165, 56);
            this.menuStrip2.TabIndex = 3;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Image = global::LibraryInfoSystem.Properties.Resources.logout;
            this.logoutToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(105, 52);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // managementToolStripMenuItem
            // 
            this.managementToolStripMenuItem.Image = global::LibraryInfoSystem.Properties.Resources.chnagePass;
            this.managementToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.managementToolStripMenuItem.Name = "managementToolStripMenuItem";
            this.managementToolStripMenuItem.Size = new System.Drawing.Size(161, 52);
            this.managementToolStripMenuItem.Text = "Change Password";
            this.managementToolStripMenuItem.Click += new System.EventHandler(this.managementToolStripMenuItem_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bookManagementToolStripMenuItem,
            this.imposeFineToolStripMenuItem});
            this.adminToolStripMenuItem.Image = global::LibraryInfoSystem.Properties.Resources.EditingSec;
            this.adminToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(103, 52);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // bookManagementToolStripMenuItem
            // 
            this.bookManagementToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bookManagementToolStripMenuItem.Image = global::LibraryInfoSystem.Properties.Resources.NewBook;
            this.bookManagementToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bookManagementToolStripMenuItem.Name = "bookManagementToolStripMenuItem";
            this.bookManagementToolStripMenuItem.Size = new System.Drawing.Size(221, 54);
            this.bookManagementToolStripMenuItem.Text = "Book Management";
            this.bookManagementToolStripMenuItem.Click += new System.EventHandler(this.bookManagementToolStripMenuItem_Click);
            // 
            // imposeFineToolStripMenuItem
            // 
            this.imposeFineToolStripMenuItem.Image = global::LibraryInfoSystem.Properties.Resources.Fine;
            this.imposeFineToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imposeFineToolStripMenuItem.Name = "imposeFineToolStripMenuItem";
            this.imposeFineToolStripMenuItem.Size = new System.Drawing.Size(221, 54);
            this.imposeFineToolStripMenuItem.Text = "Impose Fine";
            this.imposeFineToolStripMenuItem.Click += new System.EventHandler(this.imposeFineToolStripMenuItem_Click);
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.borrowToolStripMenuItem,
            this.borrowReturnToolStripMenuItem,
            this.finePaymentToolStripMenuItem});
            this.userToolStripMenuItem.Image = global::LibraryInfoSystem.Properties.Resources.EditingSec;
            this.userToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(90, 52);
            this.userToolStripMenuItem.Text = "User";
            // 
            // borrowToolStripMenuItem
            // 
            this.borrowToolStripMenuItem.Image = global::LibraryInfoSystem.Properties.Resources._1245338;
            this.borrowToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.borrowToolStripMenuItem.Name = "borrowToolStripMenuItem";
            this.borrowToolStripMenuItem.Size = new System.Drawing.Size(223, 54);
            this.borrowToolStripMenuItem.Text = "Borrow Book";
            this.borrowToolStripMenuItem.Click += new System.EventHandler(this.borrowToolStripMenuItem_Click);
            // 
            // borrowReturnToolStripMenuItem
            // 
            this.borrowReturnToolStripMenuItem.Image = global::LibraryInfoSystem.Properties.Resources.returnMenu;
            this.borrowReturnToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.borrowReturnToolStripMenuItem.Name = "borrowReturnToolStripMenuItem";
            this.borrowReturnToolStripMenuItem.Size = new System.Drawing.Size(223, 54);
            this.borrowReturnToolStripMenuItem.Text = "Borrow Return";
            this.borrowReturnToolStripMenuItem.Click += new System.EventHandler(this.borrowReturnToolStripMenuItem_Click);
            // 
            // finePaymentToolStripMenuItem
            // 
            this.finePaymentToolStripMenuItem.Image = global::LibraryInfoSystem.Properties.Resources.finePay;
            this.finePaymentToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.finePaymentToolStripMenuItem.Name = "finePaymentToolStripMenuItem";
            this.finePaymentToolStripMenuItem.Size = new System.Drawing.Size(223, 54);
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
            this.reportsToolStripMenuItem.Image = global::LibraryInfoSystem.Properties.Resources.repotview;
            this.reportsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(146, 52);
            this.reportsToolStripMenuItem.Text = "Admin Reports";
            // 
            // bookDetailsToolStripMenuItem
            // 
            this.bookDetailsToolStripMenuItem.Image = global::LibraryInfoSystem.Properties.Resources.bookRpt_new;
            this.bookDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.bookDetailsToolStripMenuItem.Name = "bookDetailsToolStripMenuItem";
            this.bookDetailsToolStripMenuItem.Size = new System.Drawing.Size(218, 54);
            this.bookDetailsToolStripMenuItem.Text = "Book Details";
            this.bookDetailsToolStripMenuItem.Click += new System.EventHandler(this.bookDetailsToolStripMenuItem_Click);
            // 
            // borrowBooksToolStripMenuItem
            // 
            this.borrowBooksToolStripMenuItem.Image = global::LibraryInfoSystem.Properties.Resources.borrowRptNew;
            this.borrowBooksToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.borrowBooksToolStripMenuItem.Name = "borrowBooksToolStripMenuItem";
            this.borrowBooksToolStripMenuItem.Size = new System.Drawing.Size(218, 54);
            this.borrowBooksToolStripMenuItem.Text = "Borrow Books";
            this.borrowBooksToolStripMenuItem.Click += new System.EventHandler(this.borrowBooksToolStripMenuItem_Click);
            // 
            // imposeFineMemberToolStripMenuItem
            // 
            this.imposeFineMemberToolStripMenuItem.Image = global::LibraryInfoSystem.Properties.Resources.imposeFinememberRpt;
            this.imposeFineMemberToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imposeFineMemberToolStripMenuItem.Name = "imposeFineMemberToolStripMenuItem";
            this.imposeFineMemberToolStripMenuItem.Size = new System.Drawing.Size(218, 54);
            this.imposeFineMemberToolStripMenuItem.Text = "Impose Fine Member";
            this.imposeFineMemberToolStripMenuItem.Click += new System.EventHandler(this.imposeFineMemberToolStripMenuItem_Click);
            // 
            // imposeFineDetailsToolStripMenuItem
            // 
            this.imposeFineDetailsToolStripMenuItem.Image = global::LibraryInfoSystem.Properties.Resources.fineDetails;
            this.imposeFineDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.imposeFineDetailsToolStripMenuItem.Name = "imposeFineDetailsToolStripMenuItem";
            this.imposeFineDetailsToolStripMenuItem.Size = new System.Drawing.Size(218, 54);
            this.imposeFineDetailsToolStripMenuItem.Text = "Impose Fine Details";
            this.imposeFineDetailsToolStripMenuItem.Click += new System.EventHandler(this.imposeFineDetailsToolStripMenuItem_Click);
            // 
            // userReportsToolStripMenuItem
            // 
            this.userReportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.myBorrowBookToolStripMenuItem,
            this.myFineDetailsToolStripMenuItem});
            this.userReportsToolStripMenuItem.Image = global::LibraryInfoSystem.Properties.Resources.repotview;
            this.userReportsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.userReportsToolStripMenuItem.Name = "userReportsToolStripMenuItem";
            this.userReportsToolStripMenuItem.Size = new System.Drawing.Size(133, 52);
            this.userReportsToolStripMenuItem.Text = "User Reports";
            // 
            // myBorrowBookToolStripMenuItem
            // 
            this.myBorrowBookToolStripMenuItem.Image = global::LibraryInfoSystem.Properties.Resources.myBorrow;
            this.myBorrowBookToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.myBorrowBookToolStripMenuItem.Name = "myBorrowBookToolStripMenuItem";
            this.myBorrowBookToolStripMenuItem.Size = new System.Drawing.Size(212, 54);
            this.myBorrowBookToolStripMenuItem.Text = "My Borrow Book";
            this.myBorrowBookToolStripMenuItem.Click += new System.EventHandler(this.myBorrowBookToolStripMenuItem_Click);
            // 
            // myFineDetailsToolStripMenuItem
            // 
            this.myFineDetailsToolStripMenuItem.Image = global::LibraryInfoSystem.Properties.Resources.myFIne;
            this.myFineDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.myFineDetailsToolStripMenuItem.Name = "myFineDetailsToolStripMenuItem";
            this.myFineDetailsToolStripMenuItem.Size = new System.Drawing.Size(212, 54);
            this.myFineDetailsToolStripMenuItem.Text = "My Fine Details";
            this.myFineDetailsToolStripMenuItem.Click += new System.EventHandler(this.myFineDetailsToolStripMenuItem_Click);
            // 
            // btnChangePass
            // 
            this.btnChangePass.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnChangePass.BackColor = System.Drawing.Color.MintCream;
            this.btnChangePass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnChangePass.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnChangePass.Image = global::LibraryInfoSystem.Properties.Resources.chnagePass;
            this.btnChangePass.Location = new System.Drawing.Point(34, 152);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(168, 139);
            this.btnChangePass.TabIndex = 5;
            this.btnChangePass.Text = "Change Password";
            this.btnChangePass.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnChangePass.UseVisualStyleBackColor = false;
            this.btnChangePass.Visible = false;
            this.btnChangePass.Click += new System.EventHandler(this.btnChangePass_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button2.BackColor = System.Drawing.Color.MintCream;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.Image = global::LibraryInfoSystem.Properties.Resources._1245338;
            this.button2.Location = new System.Drawing.Point(34, 312);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(168, 139);
            this.button2.TabIndex = 13;
            this.button2.Text = "Borrow Books";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button4.BackColor = System.Drawing.Color.MintCream;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button4.Image = global::LibraryInfoSystem.Properties.Resources.returnMenu;
            this.button4.Location = new System.Drawing.Point(256, 312);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(168, 139);
            this.button4.TabIndex = 16;
            this.button4.Text = "Return Book";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            // 
            // button12
            // 
            this.button12.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button12.BackColor = System.Drawing.Color.MintCream;
            this.button12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button12.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button12.Image = global::LibraryInfoSystem.Properties.Resources.finePay;
            this.button12.Location = new System.Drawing.Point(490, 312);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(168, 139);
            this.button12.TabIndex = 32;
            this.button12.Text = "Fine Payment";
            this.button12.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Visible = false;
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button5.BackColor = System.Drawing.Color.MintCream;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button5.Image = global::LibraryInfoSystem.Properties.Resources.Fine;
            this.button5.Location = new System.Drawing.Point(490, 152);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(168, 139);
            this.button5.TabIndex = 33;
            this.button5.Text = "Impose Fine";
            this.button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.BackColor = System.Drawing.Color.MintCream;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Image = global::LibraryInfoSystem.Properties.Resources.NewBook;
            this.button1.Location = new System.Drawing.Point(256, 152);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 139);
            this.button1.TabIndex = 34;
            this.button1.Text = "Book Management";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button3.BackColor = System.Drawing.Color.MintCream;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.Image = global::LibraryInfoSystem.Properties.Resources.borrowRptNew;
            this.button3.Location = new System.Drawing.Point(778, 297);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(168, 139);
            this.button3.TabIndex = 35;
            this.button3.Text = "Borrow Books Report";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            // 
            // button9
            // 
            this.button9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button9.BackColor = System.Drawing.Color.MintCream;
            this.button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button9.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button9.Image = global::LibraryInfoSystem.Properties.Resources.fineDetails;
            this.button9.Location = new System.Drawing.Point(778, 587);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(168, 139);
            this.button9.TabIndex = 36;
            this.button9.Text = "Impose Fine Detail Report";
            this.button9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Visible = false;
            // 
            // button10
            // 
            this.button10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button10.BackColor = System.Drawing.Color.MintCream;
            this.button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button10.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button10.Image = global::LibraryInfoSystem.Properties.Resources.imposeFinememberRpt;
            this.button10.Location = new System.Drawing.Point(778, 442);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(168, 139);
            this.button10.TabIndex = 37;
            this.button10.Text = "Impose Fine Members";
            this.button10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Visible = false;
            // 
            // button11
            // 
            this.button11.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button11.BackColor = System.Drawing.Color.MintCream;
            this.button11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button11.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button11.Image = global::LibraryInfoSystem.Properties.Resources.bookRpt_new;
            this.button11.Location = new System.Drawing.Point(778, 152);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(168, 139);
            this.button11.TabIndex = 38;
            this.button11.Text = "Books Detail Report";
            this.button11.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Visible = false;
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button6.BackColor = System.Drawing.Color.MintCream;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button6.Image = global::LibraryInfoSystem.Properties.Resources.myBorrow;
            this.button6.Location = new System.Drawing.Point(172, 496);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(168, 139);
            this.button6.TabIndex = 39;
            this.button6.Text = "My Borrow Books";
            this.button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Visible = false;
            // 
            // button8
            // 
            this.button8.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button8.BackColor = System.Drawing.Color.MintCream;
            this.button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button8.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button8.Image = global::LibraryInfoSystem.Properties.Resources.myFIne;
            this.button8.Location = new System.Drawing.Point(391, 496);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(168, 139);
            this.button8.TabIndex = 40;
            this.button8.Text = "My Fine Details";
            this.button8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::LibraryInfoSystem.Properties.Resources.bookRpt_new;
            this.toolStripMenuItem2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(212, 54);
            this.toolStripMenuItem2.Text = "Book List";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LibraryInfoSystem.Properties.Resources._1749;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1165, 803);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnChangePass);
            this.Controls.Add(this.menuStrip2);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip2;
            this.Name = "frmMenu";
            this.Text = "Library Information System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMenu_FormClosing);
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
        private Button btnChangePass;
        private Label label4;
        private Button button4;
        private Button button12;
        private Button button5;
        private Button button1;
        private Button button3;
        private Button button9;
        private Button button10;
        private Button button11;
        private Button button6;
        private Button button8;
        private PictureBox pictureBox1;
        private Label label1;
        private System.Windows.Forms.Timer timer1;
        private ToolStripMenuItem logoutToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
    }
}