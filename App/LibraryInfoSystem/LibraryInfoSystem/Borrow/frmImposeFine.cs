using LibraryInfoSystem.Borrow;
using LibraryInfoSystem.Register_Login;
using System.Data;

namespace LibraryInfoSystem
{
    public partial class frmImposeFine : Form
    {
        List<ClsImopseFine> LateRetList = new List<ClsImopseFine>();
        private long _borrowRetID = 0;


        private ClsLogin login;
        public frmImposeFine(ClsLogin login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void frmImposeFine_Load(object sender, EventArgs e)
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
                    dgvLateRetList.DataSource = LateRetList;
                    setGrid();
                }
            }
        }
        private void setGrid()
        {

            dgvLateRetList.Columns["UEmail"].Visible = false;
            dgvLateRetList.Columns["UName"].Visible = false;
            dgvLateRetList.Columns["UMobile"].Visible = false;
            dgvLateRetList.Columns["UType"].Visible = false;
            dgvLateRetList.Columns["IFineRefNo"].Visible = false;
            dgvLateRetList.Columns["IFineRefDate"].Visible = false;
            dgvLateRetList.Columns["BorrowID"].Visible = false;
            dgvLateRetList.Columns["BorrowRetID"].Visible = false;
            dgvLateRetList.Columns["Author"].Visible = false;
            dgvLateRetList.Columns["ISBN"].Visible = false;
            dgvLateRetList.Columns["Year"].Visible = false;
            dgvLateRetList.Columns["Edition"].Visible = false;
            dgvLateRetList.Columns["BRFineYN"].Visible = false;
            dgvLateRetList.Columns["FineAmnt"].Visible = false;

            dgvLateRetList.Columns["BorrowNo"].HeaderText = "Borrow No";
            dgvLateRetList.Columns["BorrowNo"].Width = 50;
            dgvLateRetList.Columns["BorrowNo"].Visible = false;

            dgvLateRetList.Columns["BorrowDate"].HeaderText = "Borrow Date";
            dgvLateRetList.Columns["BorrowDate"].Width = 120;
            dgvLateRetList.Columns["BorrowDate"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";

            dgvLateRetList.Columns["BorrowRetNo"].HeaderText = "Return No";
            dgvLateRetList.Columns["BorrowRetNo"].Width = 50;
            dgvLateRetList.Columns["BorrowRetNo"].Visible = false;

            dgvLateRetList.Columns["BorrowDays"].HeaderText = "Borrow Days";
            dgvLateRetList.Columns["BorrowDays"].Width = 50;
            dgvLateRetList.Columns["BorrowDays"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvLateRetList.Columns["BorrowRetDate"].HeaderText = "Return Date"; ;
            dgvLateRetList.Columns["BorrowRetDate"].Width = 120;
            dgvLateRetList.Columns["BorrowRetDate"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";

            dgvLateRetList.Columns["BookTitle"].HeaderText = "Book Title";
            dgvLateRetList.Columns["BookTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvLateRetList.Columns["LateDays"].HeaderText = "Late Days";
            dgvLateRetList.Columns["LateDays"].Width = 50;
            dgvLateRetList.Columns["LateDays"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
     
        private void btnImpose_Click(object sender, EventArgs e)
        {
            if (saveCheck())
            {
                ClsImopseFine imopseFine = new ClsImopseFine();


                imopseFine.IFineRefNo = long.Parse(tbRefNo.Text);
                imopseFine.IFineRefDate = dcImposeDate.Value;
                imopseFine.BorrowRetID = _borrowRetID;
                imopseFine.FineAmnt = decimal.Parse(tbFineValue.Text);

                imopseFine.SaveImposeFine();

                MessageBox.Show("Impose fine Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NewImposeFineRefNo();
            }
        }
        private void btnNeglect_Click(object sender, EventArgs e)
        {
            if (_borrowRetID != 0)
            {
                ClsImopseFine imopseFine = new ClsImopseFine();

                imopseFine.BorrowRetID = _borrowRetID;

                imopseFine.NeglectImposeFine();

                if (MessageBox.Show("Are you sure you want to Neglect?", "Neglect Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MessageBox.Show("Neglected Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    NewImposeFineRefNo();
                }
            }
            else
            {
                MessageBox.Show("Please select any Late Return", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {

            string searchTerm = tbSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                dgvLateRetList.DataSource = LateRetList;
            }
            else
            {
                var filteredList = LateRetList.Where(LateRet =>
                    LateRet.BorrowDate.ToString().ToLower().Contains(searchTerm) ||
                    LateRet.BorrowDays.ToString().ToLower().Contains(searchTerm) ||
                    LateRet.BorrowRetDate.ToString().Contains(searchTerm) ||
                    LateRet.BookTitle.ToLower().Contains(searchTerm) ||
                    LateRet.LateDays.ToString().ToLower().Contains(searchTerm)).ToList();

                dgvLateRetList.DataSource = filteredList;
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

        private void dgvLateRetList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLateRetList.Rows.Count > 0)
            {
                lblBorrowNo.Text = dgvLateRetList.CurrentRow.Cells["BorrowNo"].Value.ToString().Trim();
                lblBorrowDate.Text = Convert.ToDateTime(dgvLateRetList.CurrentRow.Cells["BorrowDate"].Value.ToString().Trim()).ToString("dd/MM/yyyy hh:mm tt");
                lblBorrowDays.Text = dgvLateRetList.CurrentRow.Cells["BorrowDays"].Value.ToString().Trim();
                _borrowRetID = long.Parse(dgvLateRetList.CurrentRow.Cells["BorrowRetID"].Value.ToString().Trim());
                lblRetNo.Text = dgvLateRetList.CurrentRow.Cells["BorrowRetNo"].Value.ToString().Trim();
                lblRetDate.Text = Convert.ToDateTime(dgvLateRetList.CurrentRow.Cells["BorrowRetDate"].Value.ToString().Trim()).ToString("dd/MM/yyyy hh:mm tt");
                tbBookTitle.Text = dgvLateRetList.CurrentRow.Cells["BookTitle"].Value.ToString().Trim();
                tbBookAuthor.Text = dgvLateRetList.CurrentRow.Cells["Author"].Value.ToString().Trim();
                tbBookISBN.Text = dgvLateRetList.CurrentRow.Cells["ISBN"].Value.ToString().Trim();
                mskYear.Text = dgvLateRetList.CurrentRow.Cells["Year"].Value.ToString().Trim();
                tbBookEdition.Text = dgvLateRetList.CurrentRow.Cells["Edition"].Value.ToString().Trim();
                lblLateDays.Text = dgvLateRetList.CurrentRow.Cells["LateDays"].Value.ToString().Trim();
            }
        }
        //----------------------------NewImposeFineRefNo------------------------------------------------------------------
        private void NewImposeFineRefNo()
        {
            ClsImopseFine ImopseFine = new ClsImopseFine();

            ImopseFine.GetImposeFineNo();
            tbRefNo.Text = ImopseFine.IFineRefNo.ToString();
            dcImposeDate.Value = DateTime.Now;

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
            dgvLateRetList.DataSource = LateRetList;
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