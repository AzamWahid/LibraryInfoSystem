using LibraryInfoSystem.Borrow;
using LibraryInfoSystem.Register_Login;
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
            BookList = borrow.GetBooks();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (saveCheck())
            {
                ClsBook book = new ClsBook();

                ////book.BookID = tbBookID.Text.Trim();
                //book.BookName = tbBookTitle.Text;
                //book.Author = tbBookAuthor.Text;
                //book.Description = tbBookDesc.Text;
                //book.Edition = int.Parse(tbBookEdition.Text);

                book.AddBook();

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

        private void dgvBookList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBookList.Rows.Count > 0)
            {

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