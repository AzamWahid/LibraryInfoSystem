using System.Data;
using System.Net;

namespace LibraryInfoSystem
{
    public partial class frmBook : Form
    {
        string previousBookCode = "";

        //ClsBook Book = new ClsBook();
        DataTable dt_list = new DataTable();
        List<ClsBook> BookList = new List<ClsBook>();
        public frmBook()
        {
            InitializeComponent();
        }
        private void frmBook_Load(object sender, EventArgs e)
        {
            getListData();
            btnNew_Click(sender, e);
        }

        private void getListData()
        {
            ClsBook book = new ClsBook();
            BookList = book.GetBooks();
            dgvList.DataSource = BookList;
            setGrid();
        }
        private void setGrid()
        {
            
            dgvList.Columns["BookID"].Visible = false;
            dgvList.Columns["ISBN"].Visible = false;

            dgvList.Columns["BookCode"].HeaderText = "Book Code";
            dgvList.Columns["BookCode"].Width = 60;

            dgvList.Columns["BookTitle"].HeaderText = "Book Title";
            dgvList.Columns["BookTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvList.Columns["Author"].HeaderText = "Book Author";
            dgvList.Columns["Author"].Width = 100;

            dgvList.Columns["Edition"].HeaderText = "Edition";
            dgvList.Columns["Edition"].Width = 45;
            dgvList.Columns["Edition"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvList.Columns["Edition"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvList.Columns["Year"].HeaderText = "Year";
            dgvList.Columns["Year"].Width = 45;
            dgvList.Columns["Year"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvList.Columns["Year"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvList.Columns["NoofCopies"].HeaderText = "Copies";
            dgvList.Columns["NoofCopies"].Width = 55;
            dgvList.Columns["NoofCopies"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvList.Columns["NoofCopies"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            tbBookCode.Text = "";
            tbBookTitle.Text = "";
            tbBookAuthor.Text = "";
            tbBookIsbn.Text = "";
            mskYear.Text = "";
            tbBookEdition.Text = "0";
            tbNoOfCopies.Text = "0";

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;

            btnSave.BackColor = Color.LightSeaGreen;
            btnUpdate.BackColor = Color.LightGray;
            this.Text = "BOOK (NEW)";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvList.Rows.Count > 0)
            {
                getEdit(dgvList.CurrentRow.Cells["BookCode"].Value.ToString().Trim());
            }
            //tbBookID.Focus();

        }
        private void getEdit(string _BookCode)
        {
            ClsBook book = new ClsBook();
            book.BookCode = _BookCode;
            book.GetBookById();
            if (!string.IsNullOrEmpty(book.BookCode))
            {
                this.Text = "BOOK (EDIT)";
                btnSave.Enabled = false;
                btnSave.BackColor = Color.LightGray;
                btnUpdate.Enabled = true;
                btnUpdate.BackColor = Color.SteelBlue;

                tbBookCode.Text = book.BookCode;
                tbBookTitle.Text = book.BookTitle;
                tbBookAuthor.Text = book.Author;
                tbBookIsbn.Text = book.ISBN;
                mskYear.Text = book.Year.ToString();
                tbBookEdition.Text = book.Edition.ToString();
                tbNoOfCopies.Text = book.NoofCopies.ToString();
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

                book.BookCode = tbBookCode.Text;
                book.BookTitle = tbBookTitle.Text;
                book.Author = tbBookAuthor.Text;
                book.ISBN = tbBookIsbn.Text;
                book.Year = long.Parse(mskYear.Text);
                book.Edition = long.Parse(tbBookEdition.Text);
                book.NoofCopies = long.Parse(tbNoOfCopies.Text);

                book.AddBook();

                MessageBox.Show("Record Saved Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnNew_Click(sender, e);
                getListData();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (saveCheck())
            {
                ClsBook book = new ClsBook();

                book.BookCode = tbBookCode.Text;
                book.BookTitle = tbBookTitle.Text;
                book.Author = tbBookAuthor.Text;
                book.ISBN = tbBookIsbn.Text;
                book.Year = long.Parse(mskYear.Text);
                book.Edition = long.Parse(tbBookEdition.Text);
                book.NoofCopies = long.Parse(tbNoOfCopies.Text);

                book.UpdateBook();

                MessageBox.Show("Record Update Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getListData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvList.Rows.Count > 0)
            {
                string bookCode = dgvList.CurrentRow.Cells["BookCode"].Value.ToString().Trim();

                ClsBook book = new ClsBook();
                book.BookCode = bookCode;

                if (MessageBox.Show("Are you sure you want to delete " + dgvList.CurrentRow.Cells["BookTitle"].Value.ToString().Trim() + " Book?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    book.DeleteBook();
                    MessageBox.Show("Record Delete Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnNew_Click(sender, e);
                    getListData();

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
                dgvList.DataSource = BookList;
            }
            else
            {
                var filteredList = BookList.Where(book =>
                    book.BookCode.ToLower().Contains(searchTerm) ||
                    book.BookTitle.ToLower().Contains(searchTerm) ||
                    book.Author.ToLower().Contains(searchTerm) ||
                    book.ISBN.ToLower().Contains(searchTerm) ||
                    book.Year.ToString().Contains(searchTerm) ||
                    book.Edition.ToString().Contains(searchTerm) ||
                    book.NoofCopies.ToString().Contains(searchTerm)

                ).ToList();
                dgvList.DataSource = filteredList;
            }
        }
        //-------------------------------------------------SAVE CHECK-------------------------------------------------------------------------
        private bool saveCheck()
        {
            if (tbBookCode.Text == "")
            {
                MessageBox.Show("Book ID should not be empty", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbBookCode.Focus();
                return false;
            }
            if (tbBookTitle.Text == "")
            {
                MessageBox.Show("Book Name should not be empty", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbBookTitle.Focus();
                return false;
            }
            if (tbBookIsbn.Text == "")
            {
                MessageBox.Show("Book Description should not be empty", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbBookIsbn.Focus();
                return false;
            }
            if (tbBookAuthor.Text == "")
            {
                MessageBox.Show("Book Author should not be empty", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbBookAuthor.Focus();
                return false;
            }
            if (mskYear.Text == "")
            {
                MessageBox.Show("Book Year should not be empty", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                mskYear.Focus();
                return false;
            }
            if (tbBookEdition.Text == "0")
            {
                MessageBox.Show("Book Edition should not be empty", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbBookEdition.Focus();
                return false;
            }
            if (tbNoOfCopies.Text == "0")
            {
                MessageBox.Show("Book No. Of copies should not be empty", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbNoOfCopies.Focus();
                return false;
            }
            return true;
        }
        //-------------------------------------------------GRID DOUBLE CLICK EDIT-------------------------------------------------------------------------
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvList.Rows.Count > 0)
            {
                getEdit(dgvList.CurrentRow.Cells["BookCode"].Value.ToString().Trim());
            }
        }

        //-------------------------------------------------BOOK ID TEXTBOX VALIDATION-------------------------------------------------------------------------
        private void tbBookCode_Validated(object sender, EventArgs e)
        {
            if ((tbBookCode.Text != null) && (previousBookCode != tbBookCode.Text))
            {
                previousBookCode = tbBookCode.Text;
                getEdit(tbBookCode.Text.Trim());
                tbBookCode.Text = previousBookCode;
            }
        }
        //-------------------------------------------------FOCUS ON FORM FORM REFRESH-------------------------------------------------------------------------
        private void frmBook_Activated(object sender, EventArgs e)
        {
            getListData();
        }

        //-------------------------------------------------BOOK EDITION NUMERIC ALLOW ONLY-------------------------------------------------------------------------
        private void tbBookEdition_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbBookEdition.Text) && !int.TryParse(tbBookEdition.Text, out _))
            {
                tbBookEdition.Text = "0";
            }
            else if (string.IsNullOrEmpty(tbBookEdition.Text))
            {
                tbBookEdition.Text = "0";
            }
        }

        private void mskYear_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int year;
            if (!int.TryParse(mskYear.Text, out year) || year < 1900 || year > 3000)
            {
                MessageBox.Show("Year must be between 1900 and 3000.", "Invalid Year", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true; // Cancel the event to keep focus on the MaskedTextBox.
            }
        }


    }
}