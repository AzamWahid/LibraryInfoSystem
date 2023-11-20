using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing.Charts;
using iTextSharp.text.pdf;
using LibraryInfoSystem.Borrow;
using LibraryInfoSystem.Register_Login;
using System.Data;

namespace LibraryInfoSystem
{
    public partial class frmUserManagement : Form
    {
        List<clsUserManagement> UserList = new List<clsUserManagement>();
        private long? _UID = 0;

        private ClsLogin login;
        private string previousUEmail = "";
        private string entryMode;
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
            dgvList.Columns["UBlock"].Visible = false;
            dgvList.Columns["UPass"].Visible = false;
            
            dgvList.Columns["UName"].HeaderText = "Name";
            dgvList.Columns["UName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvList.Columns["UEmail"].HeaderText = "Email";
            dgvList.Columns["UEmail"].Width = 150;

            dgvList.Columns["UMobileNo"].HeaderText = "Mobile No.";
            dgvList.Columns["UMobileNo"].Width = 80;

            dgvList.Columns["UType"].HeaderText = "Type";
            dgvList.Columns["UType"].Width = 60;

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            New();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvList.Rows.Count > 0)
            {
                getEdit(dgvList.CurrentRow.Cells["UEmail"].Value.ToString().Trim());
            }
        }
        private void getEdit(string _UEmail)
        {
            clsUserManagement user = new clsUserManagement();
            user.UEmail = _UEmail;
            user.GetUserByEmail();
            if (!string.IsNullOrEmpty(user.UEmail))
            {
                entryMode = "Edit";

                this.Text = "User Management (EDIT)";
                tbUEmail.ReadOnly = true;
                btnSave.Enabled = false;
                btnSave.BackColor = Color.LightGray;
                btnUpdate.Enabled = true;
                btnUpdate.BackColor = Color.SteelBlue;

                _UID = user.UID;
                tbUName.Text = user.UName;
                tbUFName.Text = user.UFName;
                tbUEmail.Text = user.UEmail;
                tbUMobNo.Text = user.UMobileNo;
                tbPass.Text = user.UPass;
                tbCnfmPass.Text = user.UPass;

                if (user.UType == "Student")
                {
                    rbtnStudent.Checked = true;
                }
                else if (user.UType == "Faculty")
                {
                    rbtnFaculty.Checked = true;
                }
                else if (user.UType == "Admin")
                {
                    rbtnAdmin.Checked = true;
                }

                if (user.UAllowBorrow == 'Y')
                {
                    rbtnAllowYes.Checked = true;
                }
                else if (user.UAllowBorrow == 'N')
                {
                    rbtnAllowNo.Checked = true;
                }

                if (user.UBookRights == 'Y')
                {
                    rbtnBookManageYes.Checked = true;
                }
                else if (user.UBookRights == 'N')
                {
                    rbtnBookManageNo.Checked = true;
                }

                if (user.UBlock == 'Y')
                {
                    rbtnBlockYes.Checked = true;
                }
                else if (user.UBlock == 'N')
                {
                    rbtnBlockNo.Checked = true;
                }
            }
            else
            {
                btnNew_Click(new object(), new EventArgs());

            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckUser())
            {
                clsUserManagement usermanage = new clsUserManagement();

                usermanage.UName = tbUName.Text;
                usermanage.UFName = tbUFName.Text;
                usermanage.UEmail = tbUEmail.Text;
                usermanage.UMobileNo = tbUMobNo.Text;
                usermanage.UPass = tbPass.Text;
                if (rbtnStudent.Checked)
                {
                    usermanage.UType = "S";
                }
                else if (rbtnFaculty.Checked)
                {
                    usermanage.UType = "F";
                }
                else if (rbtnAdmin.Checked)
                {
                    usermanage.UType = "A";
                }
                usermanage.UAllowBorrow = rbtnAllowYes.Checked ? 'Y' : 'N';
                usermanage.UBookRights = rbtnBookManageYes.Checked ? 'Y' : 'N';
                usermanage.UBlock = rbtnBlockYes.Checked ? 'Y' : 'N';

                usermanage.AddUser();

                MessageBox.Show("User Register Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                New();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CheckUser())
            {
                clsUserManagement usermanage = new clsUserManagement();

                usermanage.UID = _UID;
                usermanage.UName = tbUName.Text;
                usermanage.UFName = tbUFName.Text;
                usermanage.UEmail = tbUEmail.Text;
                usermanage.UMobileNo = tbUMobNo.Text;
                usermanage.UPass = tbPass.Text;
                if (rbtnStudent.Checked)
                {
                    usermanage.UType = "S";
                }
                else if (rbtnFaculty.Checked)
                {
                    usermanage.UType = "F";
                }
                else if (rbtnAdmin.Checked)
                {
                    usermanage.UType = "A";
                }
                usermanage.UAllowBorrow = rbtnAllowYes.Checked ? 'Y' : 'N';
                usermanage.UBookRights = rbtnBookManageYes.Checked ? 'Y' : 'N';
                usermanage.UBlock = rbtnBlockYes.Checked ? 'Y' : 'N';

                usermanage.UpdateUsers();

                MessageBox.Show("User Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private bool CheckUser()
        {
            if (tbUName.Text == "")
            {
                MessageBox.Show("User Name should not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tbUFName.Text == "")
            {
                MessageBox.Show("Father Name should not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tbUEmail.Text == "")
            {
                MessageBox.Show("Email should not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tbUMobNo.Text == "" || tbUMobNo.Text == "0")
            {
                MessageBox.Show("Mobile No. should not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tbPass.Text == "")
            {
                MessageBox.Show("Password should not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tbCnfmPass.Text == "")
            {
                MessageBox.Show("Confirm Password should not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (tbPass.Text != tbCnfmPass.Text)
            {
                MessageBox.Show("Confirm password mismatch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (entryMode == "New")
            {
                ClsRegister reg = new ClsRegister();
                reg.UEmail = tbUEmail.Text;
                reg.UMobileNo = tbUMobNo.Text;
                if (reg.CheckExistUser())
                {
                    MessageBox.Show("User Email/Mobile already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }
     
        //-------------------------------------------------GRID DOUBLE CLICK EDIT-------------------------------------------------------------------------

        private void dgvBookList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        { 
            if (dgvList.Rows.Count > 0)
            {
                getEdit(dgvList.CurrentRow.Cells["UEmail"].Value.ToString().Trim());
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
            entryMode = "New";
            _UID = 0;
            tbUName.Text = "";
            tbUFName.Text = "";
            tbUEmail.Text = "";
            tbUMobNo.Text = "";
            tbPass.Text = "";
            tbCnfmPass.Text = "";
            rbtnAllowYes.Checked = true;
            rbtnBookManageNo.Checked = true;
            rbtnBlockYes.Checked = true;

            tbUEmail.ReadOnly = false;
            btnSave.Enabled = true;
            btnUpdate.Enabled = false;

            btnSave.BackColor = Color.LightSeaGreen;
            btnUpdate.BackColor = Color.LightGray;
            this.Text = "User Management (NEW)";

            getListData();

        }

        private void tbUEmail_Validated(object sender, EventArgs e)
        {
            if ((tbUEmail.Text != null) && (previousUEmail != tbUEmail.Text))
            {
                previousUEmail = tbUEmail.Text;
                getEdit(tbUEmail.Text.Trim());
                tbUEmail.Text = previousUEmail;
            }
        }
    }
}