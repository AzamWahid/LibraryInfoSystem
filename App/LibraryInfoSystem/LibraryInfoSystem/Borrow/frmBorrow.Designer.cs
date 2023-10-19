namespace LibraryInfoSystem
{
    partial class frmBorrow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbBookTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbBookAuthor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbBookISBN = new System.Windows.Forms.TextBox();
            this.dgvBookList = new System.Windows.Forms.DataGridView();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gbxInputs = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.mskYear = new System.Windows.Forms.MaskedTextBox();
            this.tbBookEdition = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbBorrowDays = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dcBorrowDate = new System.Windows.Forms.DateTimePicker();
            this.tbRefNo = new System.Windows.Forms.TextBox();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookList)).BeginInit();
            this.gbxInputs.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(215, 23);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Borrow No. :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Book Title :";
            // 
            // tbBookTitle
            // 
            this.tbBookTitle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBookTitle.Location = new System.Drawing.Point(95, 104);
            this.tbBookTitle.Name = "tbBookTitle";
            this.tbBookTitle.Size = new System.Drawing.Size(227, 23);
            this.tbBookTitle.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Book Author :";
            // 
            // tbBookAuthor
            // 
            this.tbBookAuthor.BackColor = System.Drawing.Color.White;
            this.tbBookAuthor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBookAuthor.Location = new System.Drawing.Point(95, 133);
            this.tbBookAuthor.Name = "tbBookAuthor";
            this.tbBookAuthor.ReadOnly = true;
            this.tbBookAuthor.Size = new System.Drawing.Size(227, 23);
            this.tbBookAuthor.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Book ISBN :";
            // 
            // tbBookISBN
            // 
            this.tbBookISBN.BackColor = System.Drawing.Color.White;
            this.tbBookISBN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbBookISBN.Location = new System.Drawing.Point(95, 162);
            this.tbBookISBN.Multiline = true;
            this.tbBookISBN.Name = "tbBookISBN";
            this.tbBookISBN.ReadOnly = true;
            this.tbBookISBN.Size = new System.Drawing.Size(227, 23);
            this.tbBookISBN.TabIndex = 6;
            // 
            // dgvBookList
            // 
            this.dgvBookList.AllowUserToAddRows = false;
            this.dgvBookList.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.dgvBookList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBookList.BackgroundColor = System.Drawing.Color.White;
            this.dgvBookList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBookList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBookList.Location = new System.Drawing.Point(3, 45);
            this.dgvBookList.Name = "dgvBookList";
            this.dgvBookList.ReadOnly = true;
            this.dgvBookList.RowHeadersVisible = false;
            this.dgvBookList.RowTemplate.Height = 25;
            this.dgvBookList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBookList.Size = new System.Drawing.Size(455, 398);
            this.dgvBookList.TabIndex = 14;
            this.dgvBookList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBookList_CellDoubleClick);
            // 
            // tbSearch
            // 
            this.tbSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tbSearch.Location = new System.Drawing.Point(85, 16);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(205, 23);
            this.tbSearch.TabIndex = 13;
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(4, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Search Book :";
            // 
            // gbxInputs
            // 
            this.gbxInputs.Controls.Add(this.label8);
            this.gbxInputs.Controls.Add(this.label9);
            this.gbxInputs.Controls.Add(this.mskYear);
            this.gbxInputs.Controls.Add(this.tbBookEdition);
            this.gbxInputs.Controls.Add(this.label6);
            this.gbxInputs.Controls.Add(this.tbBorrowDays);
            this.gbxInputs.Controls.Add(this.label1);
            this.gbxInputs.Controls.Add(this.dcBorrowDate);
            this.gbxInputs.Controls.Add(this.tbRefNo);
            this.gbxInputs.Controls.Add(this.btnBorrow);
            this.gbxInputs.Controls.Add(this.tbBookAuthor);
            this.gbxInputs.Controls.Add(this.label4);
            this.gbxInputs.Controls.Add(this.label5);
            this.gbxInputs.Controls.Add(this.tbBookTitle);
            this.gbxInputs.Controls.Add(this.tbBookISBN);
            this.gbxInputs.Controls.Add(this.label3);
            this.gbxInputs.Controls.Add(this.label2);
            this.gbxInputs.ForeColor = System.Drawing.Color.Black;
            this.gbxInputs.Location = new System.Drawing.Point(3, -1);
            this.gbxInputs.Name = "gbxInputs";
            this.gbxInputs.Size = new System.Drawing.Size(346, 450);
            this.gbxInputs.TabIndex = 18;
            this.gbxInputs.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(54, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 15);
            this.label8.TabIndex = 29;
            this.label8.Text = "Year :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 225);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 15);
            this.label9.TabIndex = 28;
            this.label9.Text = "Edition :";
            // 
            // mskYear
            // 
            this.mskYear.Location = new System.Drawing.Point(95, 194);
            this.mskYear.Mask = "0000";
            this.mskYear.Name = "mskYear";
            this.mskYear.Size = new System.Drawing.Size(100, 23);
            this.mskYear.TabIndex = 26;
            // 
            // tbBookEdition
            // 
            this.tbBookEdition.Location = new System.Drawing.Point(95, 223);
            this.tbBookEdition.Name = "tbBookEdition";
            this.tbBookEdition.Size = new System.Drawing.Size(227, 23);
            this.tbBookEdition.TabIndex = 27;
            this.tbBookEdition.Text = "0";
            this.tbBookEdition.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 15);
            this.label6.TabIndex = 25;
            this.label6.Text = "Borrow Days :";
            // 
            // tbBorrowDays
            // 
            this.tbBorrowDays.Location = new System.Drawing.Point(95, 252);
            this.tbBorrowDays.Name = "tbBorrowDays";
            this.tbBorrowDays.Size = new System.Drawing.Size(227, 23);
            this.tbBorrowDays.TabIndex = 24;
            this.tbBorrowDays.Text = "0";
            this.tbBorrowDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbBorrowDays.TextChanged += new System.EventHandler(this.tbBorrowDays_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "Date :";
            // 
            // dcBorrowDate
            // 
            this.dcBorrowDate.Enabled = false;
            this.dcBorrowDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dcBorrowDate.Location = new System.Drawing.Point(95, 75);
            this.dcBorrowDate.Name = "dcBorrowDate";
            this.dcBorrowDate.Size = new System.Drawing.Size(115, 23);
            this.dcBorrowDate.TabIndex = 22;
            // 
            // tbRefNo
            // 
            this.tbRefNo.BackColor = System.Drawing.Color.White;
            this.tbRefNo.Location = new System.Drawing.Point(95, 46);
            this.tbRefNo.Name = "tbRefNo";
            this.tbRefNo.Size = new System.Drawing.Size(227, 23);
            this.tbRefNo.TabIndex = 21;
            this.tbRefNo.Text = "0";
            this.tbRefNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnBorrow
            // 
            this.btnBorrow.BackColor = System.Drawing.Color.Green;
            this.btnBorrow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrow.ForeColor = System.Drawing.Color.White;
            this.btnBorrow.Location = new System.Drawing.Point(95, 291);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(61, 30);
            this.btnBorrow.TabIndex = 18;
            this.btnBorrow.Text = "Borrow";
            this.btnBorrow.UseVisualStyleBackColor = false;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tbSearch);
            this.groupBox2.Controls.Add(this.dgvBookList);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(354, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(460, 449);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            // 
            // frmBorrow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 451);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbxInputs);
            this.Name = "frmBorrow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Borrow";
            this.Load += new System.EventHandler(this.frmBorrow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookList)).EndInit();
            this.gbxInputs.ResumeLayout(false);
            this.gbxInputs.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

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
        private TextBox tbBookAuthor;
        private Label label5;
        private TextBox tbBookDesc;
        private DataGridView dgvBookList;
        private TextBox tbSearch;
        private Label label7;
        private GroupBox gbxInputs;
        private GroupBox groupBox2;
        private Button btnBorrow;
        //private TextBox tbBookCode;
        private TextBox tbBookTitle;
        private Label label1;
        private DateTimePicker dcBorrowDate;
        private TextBox tbRefNo;
        private Label label6;
        private TextBox tbBorrowDays;
        private MaskedTextBox mskYear;
        private TextBox tbBookEdition;
        private Label label8;
        private Label label9;
        private TextBox tbBookISBN;
    }
}