using LibraryInfoSystem.Borrow;
using LibraryInfoSystem.Register_Login;
using System.Data;

namespace LibraryInfoSystem
{
    public partial class frmUserBorrowReport : Form
    {
        List<clsUserBorrowReport> BorrowtList = new List<clsUserBorrowReport>();
        private long _borrowID = 0;
        private long _RetDayLeft = 0;


        private ClsLogin login;
        public frmUserBorrowReport(ClsLogin login)
        {
            InitializeComponent();
            this.login = login;
        }
        private void frmUserBorrowReport_Load(object sender, EventArgs e)
        {
            getListData();
        }
        private void getListData()
        {
            clsUserBorrowReport borrowRet = new clsUserBorrowReport();
            borrowRet.UID = login.UID;
            BorrowtList = borrowRet.GetBorrowList();
            dgvBorrowList.DataSource = BorrowtList;
            setGrid();
        }
        private void setGrid()
        {

            dgvBorrowList.Columns["UID"].Visible = false;

            dgvBorrowList.Columns["BorrowDate"].HeaderText = "Borrow Date";
            dgvBorrowList.Columns["BorrowDate"].Width = 150;
            dgvBorrowList.Columns["BorrowDate"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";

            dgvBorrowList.Columns["BookTitle"].HeaderText = "Book Title";
            dgvBorrowList.Columns["BookTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvBorrowList.Columns["Author"].HeaderText = "Book Author";
            dgvBorrowList.Columns["Author"].Width = 120;
            //dgvBorrowList.Columns["Author"].Visible = false;

            dgvBorrowList.Columns["ISBN"].HeaderText = "ISBN";
            dgvBorrowList.Columns["ISBN"].Width = 100;

            dgvBorrowList.Columns["Edition"].HeaderText = "Edition";
            dgvBorrowList.Columns["Edition"].Width = 60;
            dgvBorrowList.Columns["Edition"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBorrowList.Columns["Edition"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvBorrowList.Columns["Year"].HeaderText = "Year";
            dgvBorrowList.Columns["Year"].Width = 60;
            dgvBorrowList.Columns["Year"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBorrowList.Columns["Year"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvBorrowList.Columns["DaysLeft"].HeaderText = "Return Day Left";
            dgvBorrowList.Columns["DaysLeft"].Width = 80;
            dgvBorrowList.Columns["DaysLeft"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBorrowList.Columns["DaysLeft"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    
        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {

            string searchTerm = tbSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                dgvBorrowList.DataSource = BorrowtList;
            }
            else
            {
                var filteredList = BorrowtList.Where(borrow =>
                    borrow.BorrowDate.ToString().ToLower().Contains(searchTerm) ||
                    borrow.BookTitle.ToLower().Contains(searchTerm) ||
                    borrow.Author.ToLower().Contains(searchTerm) ||
                    borrow.DaysLeft.ToString().ToLower().Contains(searchTerm)).ToList();

                dgvBorrowList.DataSource = filteredList;
            }
        }


    }
}