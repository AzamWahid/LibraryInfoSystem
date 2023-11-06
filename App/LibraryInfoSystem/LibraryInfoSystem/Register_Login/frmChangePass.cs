using LibraryInfoSystem.Borrow;
using LibraryInfoSystem.menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryInfoSystem.Register_Login
{
    public partial class frmChangePass : Form
    {
        private ClsLogin login;
        public frmChangePass(ClsLogin login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void frmChangePass_Load(object sender, EventArgs e)
        {
            tbUEmail.Text = login.UEmail;
        }
        private void btnChangePass_Click(object sender, EventArgs e)
        {
            clsChangePass changePass = new clsChangePass();
            changePass.UEmail = tbUEmail.Text;
            changePass.UCurrPass = tbCurrPass.Text;
            if (changePass.CheckCurrPass())
            {
                if (tbNewPass.Text == "")
                {
                    MessageBox.Show("New password should not be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tbReNewPass.Text == "")
                {
                    MessageBox.Show("Re-enter password should not be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tbNewPass.Text != tbReNewPass.Text)
                {
                    MessageBox.Show("Password and re-entered password mismatch.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (tbCurrPass.Text == tbNewPass.Text)
                { 
                    MessageBox.Show("Currentr Password and New password should be different to each other.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    changePass.UNewPass = tbNewPass.Text;

                    changePass.UpdatePass();

                    MessageBox.Show("Password change Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    login.logoutClick = true;
                    List<Form> formsToClose = new List<Form>();

                    foreach (Form form in Application.OpenForms)
                    {
                        if (form.Name != "frmLogin")
                        {
                            formsToClose.Add(form);
                        }
                    }

                    foreach (Form form in formsToClose)
                    {
                        form.Close();
                    }

                    frmLogin frmLogin = new frmLogin();
                    frmLogin.Show();
                }

            }
            else
            {
                MessageBox.Show("Invalid current password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
