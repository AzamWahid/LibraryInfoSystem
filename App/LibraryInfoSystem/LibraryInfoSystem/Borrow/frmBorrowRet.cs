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
            dgvBorrowList.DataSource = BorrowtList;
            setGrid();
        }
        private void setGrid()
        {

            dgvBorrowList.Columns["UID"].Visible = false;
            dgvBorrowList.Columns["BorrowRetNo"].Visible = false;
            dgvBorrowList.Columns["BorrowRetDate"].Visible = false;
            dgvBorrowList.Columns["BorrowID"].Visible = false;
            dgvBorrowList.Columns["BRFineYN"].Visible = false;

            dgvBorrowList.Columns["BorrowNo"].HeaderText = "Borrow No";
            dgvBorrowList.Columns["BorrowNo"].Width = 50;

            dgvBorrowList.Columns["BorrowDate"].HeaderText = "Borrow Date";
            dgvBorrowList.Columns["BorrowDate"].Width = 120;
            dgvBorrowList.Columns["BorrowDate"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";

            dgvBorrowList.Columns["BookTitle"].HeaderText = "Book Title";
            dgvBorrowList.Columns["BookTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvBorrowList.Columns["Author"].HeaderText = "Book Author";
            dgvBorrowList.Columns["Author"].Width = 100;

            dgvBorrowList.Columns["DaysLeft"].HeaderText = "Return Day Left";
            dgvBorrowList.Columns["DaysLeft"].Width = 50;

            dgvBorrowList.Columns["ISBN"].HeaderText = "Book ISBN";
            dgvBorrowList.Columns["ISBN"].Width = 80;
            dgvBorrowList.Columns["ISBN"].Visible = false;

            dgvBorrowList.Columns["Year"].HeaderText = "Year";
            dgvBorrowList.Columns["Year"].Visible = false;

            dgvBorrowList.Columns["Edition"].HeaderText = "Edition";
            dgvBorrowList.Columns["Edition"].Visible = false;
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
                dgvBorrowList.DataSource = BorrowtList;
            }
            else
            {
                var filteredList = BorrowtList.Where(borrow =>
                    borrow.BorrowNo.ToString().ToLower().Contains(searchTerm) ||
                    borrow.BorrowDate.ToString().ToLower().Contains(searchTerm) ||
                    borrow.BookTitle.ToLower().Contains(searchTerm) ||
                    borrow.Author.ToLower().Contains(searchTerm) ||
                    borrow.DaysLeft.ToString().ToLower().Contains(searchTerm)).ToList();

                dgvBorrowList.DataSource = filteredList;
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
                MessageBox.Show("please select any borrow book to return", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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

        private void dgvBorrowList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvBorrowList.Rows.Count > 0)
            {
                _borrowID = long.Parse(dgvBorrowList.CurrentRow.Cells["BorrowID"].Value.ToString().Trim());
                lblBorrowNo.Text = dgvBorrowList.CurrentRow.Cells["BorrowNo"].Value.ToString().Trim();
                lblBorrowDate.Text = Convert.ToDateTime(dgvBorrowList.CurrentRow.Cells["BorrowDate"].Value.ToString().Trim()).ToString("dd/MM/yyyy hh:mm tt");
                tbBookTitle.Text = dgvBorrowList.CurrentRow.Cells["BookTitle"].Value.ToString().Trim();
                tbBookAuthor.Text = dgvBorrowList.CurrentRow.Cells["Author"].Value.ToString().Trim();
                tbBookISBN.Text = dgvBorrowList.CurrentRow.Cells["ISBN"].Value.ToString().Trim();
                mskYear.Text = dgvBorrowList.CurrentRow.Cells["Year"].Value.ToString().Trim();
                tbBookEdition.Text = dgvBorrowList.CurrentRow.Cells["Edition"].Value.ToString().Trim();
                _RetDayLeft = long.Parse(dgvBorrowList.CurrentRow.Cells["DaysLeft"].Value.ToString().Trim());
            }
        }

        //-------------------------------------------------FOCUS ON FORM FORM REFRESH-------------------------------------------------------------------------
        private void frmBorrowRet_Activated(object sender, EventArgs e)
        {
            getListData();
        }
    }
}