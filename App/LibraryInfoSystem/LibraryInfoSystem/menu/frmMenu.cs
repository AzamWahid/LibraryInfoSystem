using LibraryInfoSystem.Register_Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryInfoSystem.menu
{
    public partial class frmMenu : Form
    {
        private ClsLogin login;
        public frmMenu(ClsLogin login)
        {
            InitializeComponent();

            this.login = login;
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {

        }

        private void btnBookManagement_Click(object sender, EventArgs e)
        {
            //frmBook frmBook = new frmBook();
            //frmBook.MdiParent = this;
            //frmBook.Show();
        }

        private void bookManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBook frmBook = new frmBook();
            frmBook.MdiParent = this;
            frmBook.Show();
        }

        private void borrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBorrow frmBorrow = new frmBorrow(login);
            frmBorrow.MdiParent = this;
            frmBorrow.Show();
        }

        private void borrowReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBorrowRet frmBorrowRet = new frmBorrowRet(login);
            frmBorrowRet.MdiParent = this;
            frmBorrowRet.Show();
        }
    }
}
