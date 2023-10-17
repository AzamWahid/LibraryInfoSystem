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
        public frmMenu()
        {
            InitializeComponent();
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
            frmBorrow frmBorrow = new frmBorrow();
            frmBorrow.MdiParent = this;
            frmBorrow.Show();
        }
    }
}
