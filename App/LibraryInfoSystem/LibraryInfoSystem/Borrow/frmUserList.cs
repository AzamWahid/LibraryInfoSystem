using Accessibility;
using LibraryInfoSystem.Borrow;
using LibraryInfoSystem.Register_Login;
using System.Data;

namespace LibraryInfoSystem
{
    public partial class frmUserList : Form
    {
        List<clsUserList> UserList = new List<clsUserList>();
        TextBox tb = new TextBox();
        public frmUserList(TextBox _tbEmail)
        {
            InitializeComponent();
            tb = _tbEmail;
        }

        private void frmUserList_Load(object sender, EventArgs e)
        {
            getListData();
        }

        private void getListData()
        {
            clsUserList userList = new clsUserList();
            UserList = userList.GetUsers();
            dgvUserList.DataSource = UserList;
            setGrid();
        }
        private void setGrid()
        {

            dgvUserList.Columns["UID"].Visible = false;

            dgvUserList.Columns["UName"].HeaderText = "Name";
            dgvUserList.Columns["UName"].Width = 120;

            dgvUserList.Columns["UEmail"].HeaderText = "Email";
            dgvUserList.Columns["UEmail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvUserList.Columns["UMobileNo"].HeaderText = "Mobile No.";
            dgvUserList.Columns["UMobileNo"].Width = 120;

            dgvUserList.Columns["UType"].HeaderText = "Student/Faculty";
            dgvUserList.Columns["UType"].Width = 60;
        }



        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {

            string searchTerm = tbSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                dgvUserList.DataSource = UserList;
            }
            else
            {
                var filteredList = UserList.Where(book =>
                    book.UName.ToLower().Contains(searchTerm) ||
                    book.UEmail.ToLower().Contains(searchTerm) ||
                    book.UMobileNo.ToLower().Contains(searchTerm) ||
                    book.UType.ToString().Contains(searchTerm)).ToList();
                dgvUserList.DataSource = filteredList;
            }
        }
        //-------------------------------------------------GRID DOUBLE CLICK EDIT-------------------------------------------------------------------------
        private void dgvUserList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUserList.Rows.Count > 0)
            {

                tb.Text = dgvUserList.CurrentRow.Cells["UEmail"].Value.ToString().Trim();
                this.Close();
                tb.Focus();
            }
        }
    }
}