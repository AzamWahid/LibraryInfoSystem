namespace LibraryInfoSystem
{
    partial class frmBorrowRet
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            BottomToolStripPanel = new ToolStripPanel();
            TopToolStripPanel = new ToolStripPanel();
            RightToolStripPanel = new ToolStripPanel();
            LeftToolStripPanel = new ToolStripPanel();
            ContentPanel = new ToolStripContentPanel();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            dgvBookList = new DataGridView();
            tbSearch = new TextBox();
            label7 = new Label();
            gbxInputs = new GroupBox();
            lblBorrowDate = new Label();
            label12 = new Label();
            lblBorrowNo = new Label();
            label11 = new Label();
            tbBookEdition = new Label();
            mskYear = new Label();
            tbBookISBN = new Label();
            tbBookAuthor = new Label();
            tbBookTitle = new Label();
            label8 = new Label();
            label9 = new Label();
            label1 = new Label();
            dcBorrowDate = new DateTimePicker();
            tbRefNo = new TextBox();
            btnReturn = new Button();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvBookList).BeginInit();
            gbxInputs.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // BottomToolStripPanel
            // 
            BottomToolStripPanel.Location = new Point(0, 0);
            BottomToolStripPanel.Name = "BottomToolStripPanel";
            BottomToolStripPanel.Orientation = Orientation.Horizontal;
            BottomToolStripPanel.RowMargin = new Padding(3, 0, 0, 0);
            BottomToolStripPanel.Size = new Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            TopToolStripPanel.Location = new Point(0, 0);
            TopToolStripPanel.Name = "TopToolStripPanel";
            TopToolStripPanel.Orientation = Orientation.Horizontal;
            TopToolStripPanel.RowMargin = new Padding(3, 0, 0, 0);
            TopToolStripPanel.Size = new Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            RightToolStripPanel.Location = new Point(0, 0);
            RightToolStripPanel.Name = "RightToolStripPanel";
            RightToolStripPanel.Orientation = Orientation.Horizontal;
            RightToolStripPanel.RowMargin = new Padding(3, 0, 0, 0);
            RightToolStripPanel.Size = new Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            LeftToolStripPanel.Location = new Point(0, 0);
            LeftToolStripPanel.Name = "LeftToolStripPanel";
            LeftToolStripPanel.Orientation = Orientation.Horizontal;
            LeftToolStripPanel.RowMargin = new Padding(3, 0, 0, 0);
            LeftToolStripPanel.Size = new Size(0, 0);
            // 
            // ContentPanel
            // 
            ContentPanel.Size = new Size(215, 23);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 49);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 4;
            label2.Text = "Return No. :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 183);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 6;
            label3.Text = "Book Title :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 217);
            label4.Name = "label4";
            label4.Size = new Size(80, 15);
            label4.TabIndex = 8;
            label4.Text = "Book Author :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(28, 252);
            label5.Name = "label5";
            label5.Size = new Size(68, 15);
            label5.TabIndex = 10;
            label5.Text = "Book ISBN :";
            // 
            // dgvBookList
            // 
            dgvBookList.AllowUserToAddRows = false;
            dgvBookList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.AliceBlue;
            dgvBookList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvBookList.BackgroundColor = Color.White;
            dgvBookList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvBookList.DefaultCellStyle = dataGridViewCellStyle2;
            dgvBookList.Location = new Point(3, 48);
            dgvBookList.Name = "dgvBookList";
            dgvBookList.ReadOnly = true;
            dgvBookList.RowHeadersVisible = false;
            dgvBookList.RowTemplate.Height = 25;
            dgvBookList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBookList.Size = new Size(455, 395);
            dgvBookList.TabIndex = 14;
            dgvBookList.CellDoubleClick += dgvBookList_CellDoubleClick;
            // 
            // tbSearch
            // 
            tbSearch.CharacterCasing = CharacterCasing.Upper;
            tbSearch.Location = new Point(53, 22);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(232, 23);
            tbSearch.TabIndex = 13;
            tbSearch.KeyDown += tbSearch_KeyDown;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Black;
            label7.Location = new Point(4, 27);
            label7.Name = "label7";
            label7.Size = new Size(48, 15);
            label7.TabIndex = 15;
            label7.Text = "Search :";
            // 
            // gbxInputs
            // 
            gbxInputs.Controls.Add(lblBorrowDate);
            gbxInputs.Controls.Add(label12);
            gbxInputs.Controls.Add(lblBorrowNo);
            gbxInputs.Controls.Add(label11);
            gbxInputs.Controls.Add(tbBookEdition);
            gbxInputs.Controls.Add(mskYear);
            gbxInputs.Controls.Add(tbBookISBN);
            gbxInputs.Controls.Add(tbBookAuthor);
            gbxInputs.Controls.Add(tbBookTitle);
            gbxInputs.Controls.Add(label8);
            gbxInputs.Controls.Add(label9);
            gbxInputs.Controls.Add(label1);
            gbxInputs.Controls.Add(dcBorrowDate);
            gbxInputs.Controls.Add(tbRefNo);
            gbxInputs.Controls.Add(btnReturn);
            gbxInputs.Controls.Add(label4);
            gbxInputs.Controls.Add(label5);
            gbxInputs.Controls.Add(label3);
            gbxInputs.Controls.Add(label2);
            gbxInputs.ForeColor = Color.Black;
            gbxInputs.Location = new Point(3, -1);
            gbxInputs.Name = "gbxInputs";
            gbxInputs.Size = new Size(346, 450);
            gbxInputs.TabIndex = 18;
            gbxInputs.TabStop = false;
            // 
            // lblBorrowDate
            // 
            lblBorrowDate.BackColor = Color.White;
            lblBorrowDate.BorderStyle = BorderStyle.FixedSingle;
            lblBorrowDate.Font = new Font("Calibri", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblBorrowDate.ForeColor = Color.Purple;
            lblBorrowDate.Location = new Point(95, 142);
            lblBorrowDate.Name = "lblBorrowDate";
            lblBorrowDate.Size = new Size(227, 29);
            lblBorrowDate.TabIndex = 38;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(13, 149);
            label12.Name = "label12";
            label12.Size = new Size(78, 15);
            label12.TabIndex = 37;
            label12.Text = "Borrow Date :";
            // 
            // lblBorrowNo
            // 
            lblBorrowNo.BackColor = Color.White;
            lblBorrowNo.BorderStyle = BorderStyle.FixedSingle;
            lblBorrowNo.Font = new Font("Calibri", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            lblBorrowNo.ForeColor = Color.Purple;
            lblBorrowNo.Location = new Point(95, 107);
            lblBorrowNo.Name = "lblBorrowNo";
            lblBorrowNo.Size = new Size(227, 29);
            lblBorrowNo.TabIndex = 36;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(13, 114);
            label11.Name = "label11";
            label11.Size = new Size(80, 15);
            label11.TabIndex = 35;
            label11.Text = "Borrown No. :";
            // 
            // tbBookEdition
            // 
            tbBookEdition.BackColor = Color.White;
            tbBookEdition.BorderStyle = BorderStyle.FixedSingle;
            tbBookEdition.Font = new Font("Calibri", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            tbBookEdition.ForeColor = Color.Purple;
            tbBookEdition.Location = new Point(95, 316);
            tbBookEdition.Name = "tbBookEdition";
            tbBookEdition.Size = new Size(227, 29);
            tbBookEdition.TabIndex = 34;
            tbBookEdition.TextAlign = ContentAlignment.MiddleRight;
            // 
            // mskYear
            // 
            mskYear.BackColor = Color.White;
            mskYear.BorderStyle = BorderStyle.FixedSingle;
            mskYear.Font = new Font("Calibri", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            mskYear.ForeColor = Color.Purple;
            mskYear.Location = new Point(95, 280);
            mskYear.Name = "mskYear";
            mskYear.Size = new Size(227, 29);
            mskYear.TabIndex = 33;
            // 
            // tbBookISBN
            // 
            tbBookISBN.BackColor = Color.White;
            tbBookISBN.BorderStyle = BorderStyle.FixedSingle;
            tbBookISBN.Font = new Font("Calibri", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            tbBookISBN.ForeColor = Color.Purple;
            tbBookISBN.Location = new Point(95, 245);
            tbBookISBN.Name = "tbBookISBN";
            tbBookISBN.Size = new Size(227, 29);
            tbBookISBN.TabIndex = 32;
            // 
            // tbBookAuthor
            // 
            tbBookAuthor.BackColor = Color.White;
            tbBookAuthor.BorderStyle = BorderStyle.FixedSingle;
            tbBookAuthor.Font = new Font("Calibri", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            tbBookAuthor.ForeColor = Color.Purple;
            tbBookAuthor.Location = new Point(95, 210);
            tbBookAuthor.Name = "tbBookAuthor";
            tbBookAuthor.Size = new Size(227, 29);
            tbBookAuthor.TabIndex = 31;
            // 
            // tbBookTitle
            // 
            tbBookTitle.BackColor = Color.White;
            tbBookTitle.BorderStyle = BorderStyle.FixedSingle;
            tbBookTitle.Font = new Font("Calibri", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            tbBookTitle.ForeColor = Color.Purple;
            tbBookTitle.Location = new Point(95, 176);
            tbBookTitle.Name = "tbBookTitle";
            tbBookTitle.Size = new Size(227, 29);
            tbBookTitle.TabIndex = 30;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(54, 287);
            label8.Name = "label8";
            label8.Size = new Size(35, 15);
            label8.TabIndex = 29;
            label8.Text = "Year :";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(39, 317);
            label9.Name = "label9";
            label9.Size = new Size(50, 15);
            label9.TabIndex = 28;
            label9.Text = "Edition :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(56, 80);
            label1.Name = "label1";
            label1.Size = new Size(37, 15);
            label1.TabIndex = 23;
            label1.Text = "Date :";
            // 
            // dcBorrowDate
            // 
            dcBorrowDate.Enabled = false;
            dcBorrowDate.Font = new Font("Calibri", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            dcBorrowDate.Format = DateTimePickerFormat.Short;
            dcBorrowDate.Location = new Point(95, 76);
            dcBorrowDate.Name = "dcBorrowDate";
            dcBorrowDate.Size = new Size(115, 23);
            dcBorrowDate.TabIndex = 22;
            // 
            // tbRefNo
            // 
            tbRefNo.BackColor = Color.White;
            tbRefNo.Font = new Font("Calibri", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            tbRefNo.Location = new Point(95, 46);
            tbRefNo.Name = "tbRefNo";
            tbRefNo.ReadOnly = true;
            tbRefNo.Size = new Size(227, 23);
            tbRefNo.TabIndex = 21;
            tbRefNo.Text = "0";
            tbRefNo.TextAlign = HorizontalAlignment.Right;
            // 
            // btnReturn
            // 
            btnReturn.BackColor = Color.Green;
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.ForeColor = Color.White;
            btnReturn.Location = new Point(95, 357);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(61, 30);
            btnReturn.TabIndex = 18;
            btnReturn.Text = "Return";
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += btnReturn_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(tbSearch);
            groupBox2.Controls.Add(dgvBookList);
            groupBox2.ForeColor = Color.Black;
            groupBox2.Location = new Point(354, -1);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(460, 450);
            groupBox2.TabIndex = 19;
            groupBox2.TabStop = false;
            groupBox2.Text = "Borrow History";
            // 
            // frmBorrowRet
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(817, 451);
            Controls.Add(groupBox2);
            Controls.Add(gbxInputs);
            Name = "frmBorrowRet";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Borrow Return";
            Load += frmBorrowRet_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBookList).EndInit();
            gbxInputs.ResumeLayout(false);
            gbxInputs.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ToolStripPanel BottomToolStripPanel;
        private ToolStripPanel TopToolStripPanel;
        private ToolStripPanel RightToolStripPanel;
        private ToolStripPanel LeftToolStripPanel;
        private ToolStripContentPanel ContentPanel;
        private Label label2;
        private TextBox tbBookCode;
        private Label label3;
        private TextBox tbBookName;
        private Label label4;
        private Label label5;
        private TextBox tbBookDesc;
        private DataGridView dgvBookList;
        private TextBox tbSearch;
        private Label label7;
        private GroupBox gbxInputs;
        private GroupBox groupBox2;
        private Button btnReturn;
        private Label label1;
        private DateTimePicker dcBorrowDate;
        private TextBox tbRefNo;
        private Label label8;
        private Label label9;
        private Label tbBookTitle;
        private Label tbBookAuthor;
        private Label tbBookEdition;
        private Label mskYear;
        private Label tbBookISBN;
        private Label lblBorrowDate;
        private Label label12;
        private Label lblBorrowNo;
        private Label label11;
    }
}