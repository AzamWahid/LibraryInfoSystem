using LibraryInfoSystem.Borrow;
using LibraryInfoSystem.Register_Login;
using System.Data;

namespace LibraryInfoSystem
{
    public partial class frmBorrowRet : Form
    {
        List<ClsBorrowRet> BorrowtList = new List<ClsBorrowRet>();
        private long _borrowID = 0;
        private long _RetDayLeft = 0;


        private ClsLogin login;
        public frmBorrowRet(ClsLogin login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void frmBorrowRet_Load(object sender, EventArgs e)
        {

            NewBorrowRet();
            getListData();
        }

        private void getListData()
        {
            ClsBorrowRet borrowRet = new ClsBorrowRet();
            borrowRet.UID = login.UID;
            BorrowtList = borrowRet.GetBorrowList();
            dgvBookList.DataSource = BorrowtList;
            setGrid();
        }
        private void setGrid()
        {

            dgvBookList.Columns["UID"].Visible = false;
            dgvBookList.Columns["BorrowRetNo"].Visible = false;
            dgvBookList.Columns["BorrowRetDate"].Visible = false;
            dgvBookList.Columns["BorrowID"].Visible = false;
            dgvBookList.Columns["BRFineYN"].Visible = false;

            dgvBookList.Columns["BorrowNo"].HeaderText = "Borrow No";
            dgvBookList.Columns["BorrowNo"].Width = 50;

            dgvBookList.Columns["BorrowDate"].HeaderText = "Borrow Date";
            dgvBookList.Columns["BorrowDate"].Width = 120;
            dgvBookList.Columns["BorrowDate"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";

            dgvBookList.Columns["BookTitle"].HeaderText = "Book Title";
            dgvBookList.Columns["BookTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvBookList.Columns["Author"].HeaderText = "Book Author";
            dgvBookList.Columns["Author"].Width = 100;

            dgvBookList.Columns["DaysLeft"].HeaderText = "Return Day Left";
            dgvBookList.Columns["DaysLeft"].Width = 50;

            dgvBookList.Columns["ISBN"].HeaderText = "Book ISBN";
            dgvBookList.Columns["ISBN"].Width = 80;
            dgvBookList.Columns["ISBN"].Visible = false;

            dgvBookList.Columns["Year"].HeaderText = "Year";
            dgvBookList.Columns["Year"].Visible = false;

            dgvBookList.Columns["Edition"].HeaderText = "Edition";
            dgvBookList.Columns["Edition"].Visible = false;
        }
        private void NewBorrowRet()
        {
            ClsBorrowRet borrowRet = new ClsBorrowRet();

            borrowRet.UID = login.UID;
            borrowRet.GetBorrowRetNo();
            tbRefNo.Text = borrowRet.BorrowRetNo.ToString();

            dcBorrowDate.Value = DateTime.Now;
            _borrowID = 0;
            lblBorrowNo.Text = "";
            lblBorrowDate.Text = "";
            tbBookTitle.Text = "";
            tbBookAuthor.Text = "";
            tbBookISBN.Text = "";
            mskYear.Text = "";
            tbBookEdition.Text = "0";
            getListData();
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (saveCheck())
            {
                ClsBorrowRet borrowRet = new ClsBorrowRet();


                borrowRet.BorrowRetNo = long.Parse(tbRefNo.Text);
                borrowRet.BorrowRetDate = dcBorrowDate.Value;
                borrowRet.BorrowID = _borrowID;
                borrowRet.BRFineYN = _RetDayLeft < 0 ? 'Y' : 'N';


                borrowRet.SaveBorrowRet();

                MessageBox.Show("Book Return Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NewBorrowRet();
            }
        }



        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {

            string searchTerm = tbSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                dgvBookList.DataSource = BorrowtList;
            }
            else
            {
                var filteredList = BorrowtList.Where(borrow =>
                    borrow.BorrowNo.ToString().ToLower().Contains(searchTerm) ||
                    borrow.BorrowDate.ToString().ToLower().Contains(searchTerm) ||
                    borrow.BookTitle.ToLower().Contains(searchTerm) ||
                    borrow.Author.ToLower().Contains(searchTerm) ||
                    borrow.DaysLeft.ToString().ToLower().Contains(searchTerm)).ToList();

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
            if (_borrowID == 0)
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
            return true;
        }
        //-------------------------------------------------GRID DOUBLE CLICK EDIT-------------------------------------------------------------------------

        private void dgvBookList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBookList.Rows.Count > 0)
            {
                _borrowID = long.Parse(dgvBookList.CurrentRow.Cells["BorrowID"].Value.ToString().Trim());
                lblBorrowNo.Text = dgvBookList.CurrentRow.Cells["BorrowNo"].Value.ToString().Trim();
                lblBorrowDate.Text = Convert.ToDateTime(dgvBookList.CurrentRow.Cells["BorrowDate"].Value.ToString().Trim()).ToString("dd/MM/yyyy hh:mm tt");
                tbBookTitle.Text = dgvBookList.CurrentRow.Cells["BookTitle"].Value.ToString().Trim();
                tbBookAuthor.Text = dgvBookList.CurrentRow.Cells["Author"].Value.ToString().Trim();
                tbBookISBN.Text = dgvBookList.CurrentRow.Cells["ISBN"].Value.ToString().Trim();
                mskYear.Text = dgvBookList.CurrentRow.Cells["Year"].Value.ToString().Trim();
                tbBookEdition.Text = dgvBookList.CurrentRow.Cells["Edition"].Value.ToString().Trim();
                _RetDayLeft = long.Parse(dgvBookList.CurrentRow.Cells["DaysLeft"].Value.ToString().Trim());
            }
        }

        //-------------------------------------------------FOCUS ON FORM FORM REFRESH-------------------------------------------------------------------------
        private void frmBook_Activated(object sender, EventArgs e)
        {
            getListData();
        }
    }
}