using LibraryInfoSystem.Register_Login;


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
        private void frmMenu_Load(object sender, EventArgs e)
        {
            if (login.UType == 'A')
            {
                userToolStripMenuItem.Visible = false;
                userReportsToolStripMenuItem.Visible = false;
            }
            else 
            {
                adminToolStripMenuItem.Visible = false;
                reportsToolStripMenuItem.Visible = false;
            }
            timer1.Start();
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

        private void imposeFineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImposeFine frmImposeFine = new frmImposeFine(login);
            frmImposeFine.MdiParent = this;
            frmImposeFine.Show();
        }

        private void finePaymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFinePay frmFinePay = new frmFinePay(login);
            frmFinePay.MdiParent = this;
            frmFinePay.Show();
        }

        private void bookDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookReport frmBookReport = new frmBookReport(login);
            frmBookReport.MdiParent = this;
            frmBookReport.Show();
        }

        private void borrowBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBorrowReport frmBorrowReport = new frmBorrowReport(login);
            frmBorrowReport.MdiParent = this;
            frmBorrowReport.Show();
        }

        private void imposeFineMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFineMembersReport frmFineMembersReport = new frmFineMembersReport(login);
            frmFineMembersReport.MdiParent = this;
            frmFineMembersReport.Show();
        }

        private void imposeFineDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImpFineDetReport frmImpFineDetReport = new frmImpFineDetReport(login);
            frmImpFineDetReport.MdiParent = this;
            frmImpFineDetReport.Show();
        }

        private void myBorrowBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserBorrowReport frmUserBorrowReport = new frmUserBorrowReport(login);
            frmUserBorrowReport.MdiParent = this;
            frmUserBorrowReport.Show();
        }

        private void myFineDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserFineReport frmUserFineReport = new frmUserFineReport(login);
            frmUserFineReport.MdiParent = this;
            frmUserFineReport.Show();

        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmBookReport frmBookReport = new frmBookReport(login);
            frmBookReport.MdiParent = this;
            frmBookReport.Show();
        }
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePass frmChangePass = new frmChangePass(login);
            frmChangePass.MdiParent = this;
            frmChangePass.Show();
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            frmChangePass frmChangePass = new frmChangePass(login);
            frmChangePass.MdiParent = this;
            frmChangePass.Show();
        }

        private void managementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePass frmChangePass = new frmChangePass(login);
            frmChangePass.MdiParent = this;
            frmChangePass.Show();
        }



        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Text = "Library Information System             User : " + login.UName + "              Date Time : " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");

        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (login.logoutClick == false)
            {
                Application.Exit();
            } }


    }
}
