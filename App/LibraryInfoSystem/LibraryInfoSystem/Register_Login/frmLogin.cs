using LibraryInfoSystem.menu;


namespace LibraryInfoSystem.Register_Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            tbUEmail.Text = "azamwahid@outlook.com";
            tbPass.Text = "azam";
        }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            ClsLogin login = new ClsLogin();
            login.UEmail = tbUEmail.Text;
            login.UPass = tbPass.Text;
            if (login.CheckUser())
            {
                if (login.UBlock == 'N')
                {
                    frmMenu frmMenu = new frmMenu(login);
                    frmMenu.Show();
                    this.Hide();
                }
                else if (login.UBlock == 'Y')
                {
                    MessageBox.Show("Your account is block. Please contact administrator", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Invalid User email or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void linkLableLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRegister frmRegister = new frmRegister();
            this.Hide();
            frmRegister.Show();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
