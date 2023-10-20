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
            if (login.ChectUser())
            {
                frmMenu frmMenu = new frmMenu(login);
                frmMenu.Show();
                this.Hide();
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


    }
}
