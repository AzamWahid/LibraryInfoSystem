using LibraryInfoSystem.Borrow;
using LibraryInfoSystem.Register_Login;
using System.Data;

namespace LibraryInfoSystem
{
    public partial class frmUserManagement : Form
    {
        List<clsUserManagement> UserList = new List<clsUserManagement>();
        private long _UID = 0;

        private ClsLogin login;
        public frmUserManagement(ClsLogin login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void frmUserManagement_Load(object sender, EventArgs e)
        {
            New();
           
        }

        private void getListData()
        {
            clsUserManagement users = new clsUserManagement();
            UserList = users.GetUsers();
            dgvList.DataSource = UserList;
            setGrid();
        }
        private void setGrid()
        {

            dgvList.Columns["UID"].Visible = false;
            dgvList.Columns["UFName"].Visible = false;
            dgvList.Columns["UAllowBorrow"].Visible = false;
            dgvList.Columns["UBookRights"].Visible = false;

            dgvList.Columns["UName"].HeaderText = "Name";
            dgvList.Columns["UName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvList.Columns["UEmail"].HeaderText = "Email";
            dgvList.Columns["UEmail"].Width = 150;

            dgvList.Columns["UMobileNo"].HeaderText = "Mobile No.";
            dgvList.Columns["UMobileNo"].Width = 80;

            dgvList.Columns["UType"].HeaderText = "Type";
            dgvList.Columns["UType"].Width = 60;

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (saveCheck())
            {
                clsUserManagement usermanage = new clsUserManagement();

                usermanage.UID = _UID;
                usermanage.UAllowBorrow = rbtnAllowYes.Checked ? 'Y' : 'N';
                usermanage.UBookRights = rbtnBookManageYes.Checked ? 'Y' : 'N';

                usermanage.UpdateUsers();

                MessageBox.Show("Book Borrow Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                New();
            }
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {

            string searchTerm = tbSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                dgvList.DataSource = UserList;
            }
            else
            {
                var filteredList = UserList.Where(user =>
                    user.UName.ToLower().Contains(searchTerm) ||
                    user.UEmail.ToLower().Contains(searchTerm) ||
                    user.UMobileNo.ToString().Contains(searchTerm) ||
                    user.UType.ToString().Contains(searchTerm)).ToList();
                dgvList.DataSource = filteredList;
            }
        }
        //-------------------------------------------------SAVE CHECK-------------------------------------------------------------------------
        private bool saveCheck()
        {
            if (tbUName.Text == "")
            {
                MessageBox.Show("User Name should not be empty", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (tbUEmail.Text == "")
            {
                MessageBox.Show("User Email should not be zero", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }
        //-------------------------------------------------GRID DOUBLE CLICK EDIT-------------------------------------------------------------------------

        private void dgvBookList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvList.Rows.Count > 0)
            {
                _UID = long.Parse(dgvList.CurrentRow.Cells["UID"].Value.ToString().Trim());
                tbUName.Text = dgvList.CurrentRow.Cells["UName"].Value.ToString().Trim();
                tbUFName.Text = dgvList.CurrentRow.Cells["UFName"].Value.ToString().Trim();
                tbUEmail.Text = dgvList.CurrentRow.Cells["UEmail"].Value.ToString().Trim();
                tbUMobNo.Text = dgvList.CurrentRow.Cells["UMobileNo"].Value.ToString().Trim();
                tbUType.Text = dgvList.CurrentRow.Cells["UType"].Value.ToString().Trim();
                if (dgvList.CurrentRow.Cells["UAllowBorrow"].Value.ToString() == "Y")
                {
                    rbtnAllowYes.Checked = true;
                }
                else if (dgvList.CurrentRow.Cells["UAllowBorrow"].Value.ToString() == "N")
                {
                    rbtnAllowNo.Checked = true;
                }

                if (dgvList.CurrentRow.Cells["UBookRights"].Value.ToString() == "Y")
                {
                    rbtnBookManageYes.Checked = true;
                }
                else if (dgvList.CurrentRow.Cells["UBookRights"].Value.ToString() == "N")
                {
                    rbtnBookManageNo.Checked = true;
                }
            }
        }

        //-------------------------------------------------FOCUS ON FORM FORM REFRESH-------------------------------------------------------------------------
        private void frmUserManagement_Activated(object sender, EventArgs e)
        {
            getListData();
        }


        //-------------------------------------NEW-------------------------------
        private void New()
        {
            _UID = 0;
            tbUName.Text = "";
            tbUFName.Text = "";
            tbUEmail.Text = "";
            tbUMobNo.Text = "";
            tbUType.Text = "";
            getListData();
        }


    }
}