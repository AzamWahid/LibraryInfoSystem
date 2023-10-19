using LibraryInfoSystem.Borrow;
using LibraryInfoSystem.Register_Login;
using System.Data;

namespace LibraryInfoSystem
{
    public partial class frmBorrow : Form
    {
        string previousBookId = "";
        ClsLogin login = new ClsLogin();
        DataTable dt_list = new DataTable();
        List<ClsBook> BookList = new List<ClsBook>();
        private long _bookID = 0;  
        public frmBorrow()
        {
            InitializeComponent();
        }

        private void frmBorrow_Load(object sender, EventArgs e)
        {
            MessageBox.Show(login.UID.ToString());
            dcBorrowDate.Value = DateTime.Now;
            GetBorrowNumber();
            getListData();
        }
        private void GetBorrowNumber()
        { 
        }
        private void getListData()
        {
            ClsBorrow borrow = new ClsBorrow();
            BookList = borrow.GetAvaBooks();
            dgvBookList.DataSource = BookList;
            setGrid();
        }
        private void setGrid()
        {

            dgvBookList.Columns["BookID"].Visible = false;
            dgvBookList.Columns["BookCode"].Visible = false;

            dgvBookList.Columns["BookTitle"].HeaderText = "Book Title";
            dgvBookList.Columns["BookTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvBookList.Columns["Author"].HeaderText = "Book Author";
            dgvBookList.Columns["Author"].Width = 80;

            dgvBookList.Columns["ISBN"].HeaderText = "Book ISBN";
            dgvBookList.Columns["ISBN"].Width = 80;

            dgvBookList.Columns["Year"].HeaderText = "Year";
            dgvBookList.Columns["Year"].Width = 45;

            dgvBookList.Columns["Edition"].HeaderText = "Edition";
            dgvBookList.Columns["Edition"].Width = 45;

            dgvBookList.Columns["NoofCopies"].HeaderText = "Copies";
            dgvBookList.Columns["NoofCopies"].Width = 45;
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (saveCheck())
            {
                ClsBorrow borrow = new ClsBorrow();


                borrow.BorrowNo = long.Parse(tbRefNo.Text);
                borrow.BorrowDate = dcBorrowDate.Value;

                borrow.BorrowUID = login.UID;
                borrow.BorrowBookID = _bookID;
                borrow.BorrowDays = long.Parse(tbBorrowDays.Text);

                borrow.SaveBorrow();

                MessageBox.Show("Book Borrow Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (saveCheck())
            {
                ClsBorrow borrow = new ClsBorrow();
                ClsLogin login = new ClsLogin();

                borrow.BorrowNo = long.Parse(tbRefNo.Text);
                borrow.BorrowDate = dcBorrowDate.Value;
                borrow.BorrowUID = login.UID;


             //   borrow.UpdateBook();

                MessageBox.Show("Record Update Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getListData();
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
                    book.BookTitle.ToLower().Contains(searchTerm) ||
                    book.Author.ToLower().Contains(searchTerm) ||
                    book.ISBN.ToLower().Contains(searchTerm) ||
                    book.Year.ToString().Contains(searchTerm) ||
                    book.Edition.ToString().Contains(searchTerm) ||
                    book.NoofCopies.ToString().Contains(searchTerm)

                ).ToList();
                dgvBookList.DataSource = filteredList;
            }
        }
        //-------------------------------------------------SAVE CHECK-------------------------------------------------------------------------
        private bool saveCheck()
        {
            if (tbRefNo.Text == "0")
            {
                MessageBox.Show("Borrow No. should not be zero", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbRefNo.Focus();
                return false;
            }
            if (_bookID == 0)
            {
                MessageBox.Show("please select any book", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbBookTitle.Focus();
                return false;
            }
            if (tbBookTitle.Text == "")
            {
                MessageBox.Show("Book Title should not be empty", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbBookTitle.Focus();
                return false;
            }

            if (tbBorrowDays.Text == "0")
            {
                MessageBox.Show("Borrow Days should not be zero", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbBorrowDays.Focus();
                return false;
            }
            return true;
        }
        //-------------------------------------------------GRID DOUBLE CLICK EDIT-------------------------------------------------------------------------

        private void dgvBookList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBookList.Rows.Count > 0)
            {
                _bookID = long.Parse(dgvBookList.CurrentRow.Cells["BookID"].Value.ToString().Trim());
                tbBookTitle.Text = dgvBookList.CurrentRow.Cells["BookTitle"].Value.ToString().Trim();
                tbBookAuthor.Text = dgvBookList.CurrentRow.Cells["Author"].Value.ToString().Trim();
                tbBookISBN.Text = dgvBookList.CurrentRow.Cells["ISBN"].Value.ToString().Trim();
                mskYear.Text = dgvBookList.CurrentRow.Cells["Year"].Value.ToString().Trim();
                tbBookEdition.Text = dgvBookList.CurrentRow.Cells["Edition"].Value.ToString().Trim();
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