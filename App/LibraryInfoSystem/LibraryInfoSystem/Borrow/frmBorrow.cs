using System.Data;

namespace LibraryInfoSystem
{
    public partial class frmBorrow : Form
    {
        string previousBookId = "";

        //ClsBook Book = new ClsBook();
        DataTable dt_list = new DataTable();
        List<ClsBook> BookList = new List<ClsBook>();
        public frmBorrow()
        {
            InitializeComponent();
        }

        private void frmBorrow_Load(object sender, EventArgs e)
        {
            getListData();
            btnNew_Click(sender, e);
        }
        private void getListData()
        {
            ClsBook book = new ClsBook();
            BookList = book.GetBooks();
            dgvBookList.DataSource = BookList;
            setGrid();
        }
        private void setGrid()
        {
            dgvBookList.Columns["BookID"].HeaderText = "Book ID";
            dgvBookList.Columns["BookID"].Width = 50;

            dgvBookList.Columns["BookName"].HeaderText = "Book Name";
            dgvBookList.Columns["BookName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvBookList.Columns["Author"].HeaderText = "Book Author";
            dgvBookList.Columns["Author"].Width = 80;

            dgvBookList.Columns["Description"].HeaderText = "Book Description";
            dgvBookList.Columns["Description"].Width = 80;

            dgvBookList.Columns["Edition"].HeaderText = "Edition";
            dgvBookList.Columns["Edition"].Width = 50;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            //tbBookID.Text = "";
            tbBookTitle.Text = "";
            tbBookAuthor.Text = "";
            tbBookDesc.Text = "";
            tbBookEdition.Text = "0";

            btnBorrow.Enabled = true;
            btnUpdate.Enabled = false;

            btnBorrow.BackColor = Color.LightSeaGreen;
            btnUpdate.BackColor = Color.LightGray;
            this.Text = "BOOK (NEW)";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvBookList.Rows.Count > 0)
            {
                getEdit(dgvBookList.CurrentRow.Cells["BookID"].Value.ToString().Trim());
            }
            //tbBookID.Focus();

        }
        private void getEdit(string _bookID)
        {
            ClsBook book = new ClsBook();
            book.BookID = _bookID;
            book.GetBookById();
            if (!string.IsNullOrEmpty(book.BookID))
            {
                this.Text = "BOOK (EDIT)";
                btnBorrow.Enabled = false;
                btnBorrow.BackColor = Color.LightGray;
                btnUpdate.Enabled = true;
                btnUpdate.BackColor = Color.SteelBlue;


                //tbBookID.Text = book.BookID;
                tbBookTitle.Text = book.BookName;
                tbBookAuthor.Text = book.Author;
                tbBookDesc.Text = book.Description;
                tbBookEdition.Text = book.Edition.ToString();
            }
            else
            {
                btnNew_Click(new object(), new EventArgs());

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveCheck())
            {
                ClsBook book = new ClsBook();

                //book.BookID = tbBookID.Text.Trim();
                book.BookName = tbBookTitle.Text;
                book.Author = tbBookAuthor.Text;
                book.Description = tbBookDesc.Text;
                book.Edition = int.Parse(tbBookEdition.Text);

                book.AddBook();

                MessageBox.Show("Record Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNew_Click(sender, e);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (saveCheck())
            {
                ClsBook book = new ClsBook();

                //book.BookID = tbBookID.Text.Trim();
                book.BookName = tbBookTitle.Text;
                book.Author = tbBookAuthor.Text;
                book.Description = tbBookDesc.Text;
                book.Edition = int.Parse(tbBookEdition.Text);


                book.UpdateBook();

                MessageBox.Show("Record Update Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getListData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvBookList.Rows.Count > 0)
            {
                string bookID = dgvBookList.CurrentRow.Cells["BookID"].Value.ToString().Trim();

                ClsBook book = new ClsBook();
                book.BookID = bookID;

                if (MessageBox.Show("Are you sure you want to delete " + dgvBookList.CurrentRow.Cells["BookName"].Value.ToString().Trim() + " Book?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    book.DeleteBook();
                    MessageBox.Show("Record Delete Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnNew_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Delete Cancel", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {

            string searchTerm = tbSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                dgvBookList.DataSource = BookList;
            }
            else
            {
                var filteredList = BookList.Where(book =>
                    book.BookID.ToLower().Contains(searchTerm) ||
                    book.BookName.ToLower().Contains(searchTerm) ||
                    book.Author.ToLower().Contains(searchTerm) ||
                    book.Description.ToLower().Contains(searchTerm) ||
                    book.Edition.ToString().Contains(searchTerm)
                ).ToList();
                dgvBookList.DataSource = filteredList;
            }
        }
        //-------------------------------------------------SAVE CHECK-------------------------------------------------------------------------
        private bool saveCheck()
        {
            //if (tbBookID.Text == "")
            //{
            //    MessageBox.Show("Book ID should not be empty", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    tbBookID.Focus();
            //    return false;
            // }
            if (tbBookTitle.Text == "")
            {
                MessageBox.Show("Book Name should not be empty", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbBookTitle.Focus();
                return false;
            }
            if (tbBookDesc.Text == "")
            {
                MessageBox.Show("Book Description should not be empty", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbBookDesc.Focus();
                return false;
            }
            if (tbBookAuthor.Text == "")
            {
                MessageBox.Show("Book Author should not be empty", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbBookAuthor.Focus();
                return false;
            }
            return true;
        }
        //-------------------------------------------------GRID DOUBLE CLICK EDIT-------------------------------------------------------------------------
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBookList.Rows.Count > 0)
            {
                getEdit(dgvBookList.CurrentRow.Cells["BookID"].Value.ToString().Trim());
            }
        }

        //-------------------------------------------------BOOK ID TEXTBOX VALIDATION-------------------------------------------------------------------------
        private void tbBookID_Validated(object sender, EventArgs e)
        {
            //if ((tbBookCode.Text != null) && (previousBookId != tbBookCode.Text))
            //{
            //    previousBookId = tbBookID.Text;
            //    getEdit(tbBookID.Text.Trim());
            //    tbBookID.Text = previousBookId;
            //}
        }
        //-------------------------------------------------FOCUS ON FORM FORM REFRESH-------------------------------------------------------------------------
        private void frmBook_Activated(object sender, EventArgs e)
        {
            getListData();
        }

        //-------------------------------------------------BOOK EDITION NUMERIC ALLOW ONLY-------------------------------------------------------------------------
        private void tbBorrowDays_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbBorrowDays.Text) && !int.TryParse(tbBorrowDays.Text, out _))
            {
                tbBorrowDays.Text = "0";
            }
            else if (string.IsNullOrEmpty(tbBorrowDays.Text))
            {
                tbBorrowDays.Text = "0";
            }
        }

 

    }
}