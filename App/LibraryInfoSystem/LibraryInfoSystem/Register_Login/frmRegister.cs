using System.ComponentModel;
using System.Text.RegularExpressions;


namespace LibraryInfoSystem.Register_Login
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            rbtnStudent.Checked = true;
        }
        private void tbUEmail_Validating(object sender, CancelEventArgs e)
        {
            string email = tbUEmail.Text;
            string emailPattern = @"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";

            if (!Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Invalid email address format. Please enter a valid email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private bool CheckUser()
        {
            if (tbUName.Text == "")
            {
                MessageBox.Show("User Name should not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tbFName.Text == "")
            {
                MessageBox.Show("Father Name should not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tbUEmail.Text == "")
            {
                MessageBox.Show("Email should not be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (tbMobileNo.Text == "" || tbMobileNo.Text == "0")
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

            ClsRegister reg = new ClsRegister();
            reg.UEmail= tbUEmail.Text;
            reg.UMobileNo = tbMobileNo.Text;
            if (reg.CheckExistUser())
            {
                MessageBox.Show("User Email/Mobile already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (CheckUser())
            {
                ClsRegister register = new ClsRegister();

                register.UName = tbUName.Text;
                register.UFName = tbFName.Text;
                register.UEmail = tbUEmail.Text;
                register.UMobileNo = tbMobileNo.Text;
                register.UPass = tbPass.Text;
                if (rbtnStudent.Checked)
                {
                    register.UType = 'S';
                }
                else if (rbtnFaculty.Checked)
                {
                    register.UType = 'F';
                }

                register.AddUser();

                MessageBox.Show("Record Register Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OpenLoginForm();

            }
        }

        private void linkLableLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenLoginForm();
        }
        private void OpenLoginForm()
        {
            frmLogin frmLogin = new frmLogin();
            this.Hide();
            frmLogin.Show();
        }
    }
}
