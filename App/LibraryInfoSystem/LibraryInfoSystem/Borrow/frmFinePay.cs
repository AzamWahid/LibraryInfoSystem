using LibraryInfoSystem.Borrow;
using LibraryInfoSystem.Register_Login;
using System.Data;

namespace LibraryInfoSystem
{
    public partial class frmFinePay : Form
    {
        List<ClsImopseFine> LateRetList = new List<ClsImopseFine>();
        private long _borrowRetID = 0;


        private ClsLogin login;
        public frmFinePay(ClsLogin login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void frmFinePay_Load(object sender, EventArgs e)
        {
            NewImposeFineRefNo();
        }
        private void btnFetch_Click(object sender, EventArgs e)
        {
            ClsImopseFine ImopseFine = new ClsImopseFine();
            if (tbUEmail.Text != "")
            {
                ImopseFine.UEmail = tbUEmail.Text;
                if (ImopseFine.ChectUser())
                {
                    tbUName.Text = ImopseFine.UName;
                    tbUMobile.Text = ImopseFine.UMobile;
                    tbUType.Text = ImopseFine.UType;
                    getListData();
                }
                else
                {
                    tbUName.Text = "";
                    tbUMobile.Text = "";
                    tbUType.Text = "";
                    MessageBox.Show("User Not Found", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        private void getListData()
        {
            ClsImopseFine ImopseFine = new ClsImopseFine();
            ImopseFine.UEmail = tbUEmail.Text;
            if (tbUEmail.Text != "")
            {
                LateRetList = ImopseFine.GetLateRetList();
                if (LateRetList.Count == 0)
                {
                    MessageBox.Show("No record found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    dgvIFList.DataSource = LateRetList;
                    setGrid();
                }
            }
        }
        private void setGrid()
        {

            dgvIFList.Columns["UEmail"].Visible = false;
            dgvIFList.Columns["UName"].Visible = false;
            dgvIFList.Columns["UMobile"].Visible = false;
            dgvIFList.Columns["UType"].Visible = false;
            dgvIFList.Columns["IFineRefNo"].Visible = false;
            dgvIFList.Columns["IFineRefDate"].Visible = false;
            dgvIFList.Columns["BorrowID"].Visible = false;
            dgvIFList.Columns["BorrowRetID"].Visible = false;
            dgvIFList.Columns["Author"].Visible = false;
            dgvIFList.Columns["ISBN"].Visible = false;
            dgvIFList.Columns["Year"].Visible = false;
            dgvIFList.Columns["Edition"].Visible = false;
            dgvIFList.Columns["BRFineYN"].Visible = false;
            dgvIFList.Columns["FineAmnt"].Visible = false;

            dgvIFList.Columns["BorrowNo"].HeaderText = "Borrow No";
            dgvIFList.Columns["BorrowNo"].Width = 50;
            dgvIFList.Columns["BorrowNo"].Visible = false;

            dgvIFList.Columns["BorrowDate"].HeaderText = "Borrow Date";
            dgvIFList.Columns["BorrowDate"].Width = 120;
            dgvIFList.Columns["BorrowDate"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";

            dgvIFList.Columns["BorrowRetNo"].HeaderText = "Return No";
            dgvIFList.Columns["BorrowRetNo"].Width = 50;
            dgvIFList.Columns["BorrowRetNo"].Visible = false;

            dgvIFList.Columns["BorrowDays"].HeaderText = "Borrow Days";
            dgvIFList.Columns["BorrowDays"].Width = 50;
            dgvIFList.Columns["BorrowDays"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvIFList.Columns["BorrowRetDate"].HeaderText = "Return Date"; ;
            dgvIFList.Columns["BorrowRetDate"].Width = 120;
            dgvIFList.Columns["BorrowRetDate"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";

            dgvIFList.Columns["BookTitle"].HeaderText = "Book Title";
            dgvIFList.Columns["BookTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvIFList.Columns["LateDays"].HeaderText = "Late Days";
            dgvIFList.Columns["LateDays"].Width = 50;
            dgvIFList.Columns["LateDays"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
     
        private void btnPay_Click(object sender, EventArgs e)
        {
            if (saveCheck())
            {
                ClsImopseFine imopseFine = new ClsImopseFine();


                imopseFine.IFineRefNo = long.Parse(tbRefNo.Text);
                imopseFine.IFineRefDate = dcFinePauDate.Value;
                imopseFine.BorrowRetID = _borrowRetID;
                imopseFine.FineAmnt = decimal.Parse(tbFineValue.Text);

                imopseFine.SaveImposeFine();

                MessageBox.Show("Impose fine Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NewImposeFineRefNo();
            }
        }
        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {

            string searchTerm = tbSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                dgvIFList.DataSource = LateRetList;
            }
            else
            {
                var filteredList = LateRetList.Where(LateRet =>
                    LateRet.BorrowDate.ToString().ToLower().Contains(searchTerm) ||
                    LateRet.BorrowDays.ToString().ToLower().Contains(searchTerm) ||
                    LateRet.BorrowRetDate.ToString().Contains(searchTerm) ||
                    LateRet.BookTitle.ToLower().Contains(searchTerm) ||
                    LateRet.LateDays.ToString().ToLower().Contains(searchTerm)).ToList();

                dgvIFList.DataSource = filteredList;
            }
        }
        //-------------------------------------------------SAVE CHECK-------------------------------------------------------------------------
        private bool saveCheck()
        {
            if (tbRefNo.Text == "0")
            {
                MessageBox.Show("Impose Fine No. should not be zero", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbRefNo.Focus();
                return false;
            }
            if (_borrowRetID == 0)
            {
                MessageBox.Show("please select any Late Return", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbBookTitle.Focus();
            }
            if (tbBookTitle.Text == "")
            {
                MessageBox.Show("Book Title should not be empty", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbBookTitle.Focus();
                return false;
            }
            if (tbFineValue.Text == "0")
            {
                MessageBox.Show("Fine Amount should not be zero", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbBookTitle.Focus();
                return false;
            }
            return true;
        }
        //-------------------------------------------------GRID DOUBLE CLICK EDIT-------------------------------------------------------------------------

        private void dgvIFList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvIFList.Rows.Count > 0)
            {
                lblBorrowNo.Text = dgvIFList.CurrentRow.Cells["BorrowNo"].Value.ToString().Trim();
                lblBorrowDate.Text = Convert.ToDateTime(dgvIFList.CurrentRow.Cells["BorrowDate"].Value.ToString().Trim()).ToString("dd/MM/yyyy hh:mm tt");
                lblBorrowDays.Text = dgvIFList.CurrentRow.Cells["BorrowDays"].Value.ToString().Trim();
                _borrowRetID = long.Parse(dgvIFList.CurrentRow.Cells["BorrowRetID"].Value.ToString().Trim());
                lblRetNo.Text = dgvIFList.CurrentRow.Cells["BorrowRetNo"].Value.ToString().Trim();
                lblRetDate.Text = Convert.ToDateTime(dgvIFList.CurrentRow.Cells["BorrowRetDate"].Value.ToString().Trim()).ToString("dd/MM/yyyy hh:mm tt");
                tbBookTitle.Text = dgvIFList.CurrentRow.Cells["BookTitle"].Value.ToString().Trim();
                tbBookAuthor.Text = dgvIFList.CurrentRow.Cells["Author"].Value.ToString().Trim();
                tbBookISBN.Text = dgvIFList.CurrentRow.Cells["ISBN"].Value.ToString().Trim();
                mskYear.Text = dgvIFList.CurrentRow.Cells["Year"].Value.ToString().Trim();
                tbBookEdition.Text = dgvIFList.CurrentRow.Cells["Edition"].Value.ToString().Trim();
                lblLateDays.Text = dgvIFList.CurrentRow.Cells["LateDays"].Value.ToString().Trim();
            }
        }
        //----------------------------NewImposeFineRefNo------------------------------------------------------------------
        private void NewImposeFineRefNo()
        {
            ClsImopseFine ImopseFine = new ClsImopseFine();

            ImopseFine.GetImposeFineNo();
            tbRefNo.Text = ImopseFine.IFineRefNo.ToString();
            dcFinePauDate.Value = DateTime.Now;

            _borrowRetID = 0;
            lblBorrowNo.Text = "";
            lblBorrowDate.Text = "";
            lblBorrowDays.Text = "";
            lblRetNo.Text = "";
            lblRetDate.Text = "";
            tbBookTitle.Text = "";
            tbBookAuthor.Text = "";
            tbBookISBN.Text = "";
            mskYear.Text = "";
            tbBookEdition.Text = "0";
            lblLateDays.Text = "0";
            tbFineValue.Text = "0";

            ImopseFine.UEmail = tbUEmail.Text;
            LateRetList = ImopseFine.GetLateRetList();
            dgvIFList.DataSource = LateRetList;
            setGrid();
        }
        //-------------------------------------------------FOCUS ON FORM FORM REFRESH-------------------------------------------------------------------------
        private void frmImposeFine_Activated(object sender, EventArgs e)
        {
            getListData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmUserList frmUserList = new frmUserList(tbUEmail);
            frmUserList.ShowDialog();
        }
    }
}