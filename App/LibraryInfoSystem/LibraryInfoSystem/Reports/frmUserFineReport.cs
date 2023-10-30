using iTextSharp.text;
using iTextSharp.text.pdf;
using LibraryInfoSystem.Borrow;
using LibraryInfoSystem.Register_Login;
using System.Data;

namespace LibraryInfoSystem
{
    public partial class frmUserFineReport : Form
    {
        List<clsUserFineReport> FinePayList = new List<clsUserFineReport>();


        private ClsLogin login;
        public frmUserFineReport(ClsLogin login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void frmUserFineReport_Load(object sender, EventArgs e)
        {
            getListData();
        }
        private void getListData()
        {
            clsUserFineReport FinePay = new clsUserFineReport();
            FinePay.UID = login.UID;
            FinePayList = FinePay.GetImposeFineList();
            dgvIFList.DataSource = FinePayList;
            setGrid();
        }
        private void setGrid()
        {
            dgvIFList.Columns["UID"].Visible = false;

            dgvIFList.Columns["IFineRefDate"].HeaderText = "Impose Fine Date";
            dgvIFList.Columns["IFineRefDate"].Width = 120;
            dgvIFList.Columns["IFineRefDate"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";

            dgvIFList.Columns["BorrowDate"].HeaderText = "Borrow Date";
            dgvIFList.Columns["BorrowDate"].Width = 120;
            dgvIFList.Columns["BorrowDate"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";

            dgvIFList.Columns["BorrowDays"].HeaderText = "Borrow Days";
            dgvIFList.Columns["BorrowDays"].Width = 40;
            dgvIFList.Columns["BorrowDays"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIFList.Columns["BorrowDays"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvIFList.Columns["BorrowRetDate"].HeaderText = "Return Date";
            dgvIFList.Columns["BorrowRetDate"].Width = 120;
            dgvIFList.Columns["BorrowRetDate"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";

            dgvIFList.Columns["LateDays"].HeaderText = "Late Days";
            dgvIFList.Columns["LateDays"].Width = 50;
            dgvIFList.Columns["LateDays"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIFList.Columns["LateDays"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvIFList.Columns["BookTitle"].HeaderText = "Book Title";
            dgvIFList.Columns["BookTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvIFList.Columns["Author"].HeaderText = "Book Author";
            dgvIFList.Columns["Author"].Width = 120;
            //dgvIFList.Columns["Author"].Visible = false;

            dgvIFList.Columns["ISBN"].HeaderText = "ISBN";
            dgvIFList.Columns["ISBN"].Width = 100;
            dgvIFList.Columns["ISBN"].Visible = false;

            dgvIFList.Columns["Edition"].HeaderText = "Edition";
            dgvIFList.Columns["Edition"].Width = 60;
            dgvIFList.Columns["Edition"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIFList.Columns["Edition"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvIFList.Columns["Year"].HeaderText = "Year";
            dgvIFList.Columns["Year"].Width = 60;
            dgvIFList.Columns["Year"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIFList.Columns["Year"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvIFList.Columns["Year"].Visible = false;

            dgvIFList.Columns["FineAmnt"].HeaderText = "Fine Value";
            dgvIFList.Columns["FineAmnt"].Width = 50;
            dgvIFList.Columns["FineAmnt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvIFList.Columns["FineAmnt"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {

            string searchTerm = tbSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                dgvIFList.DataSource = FinePayList;
            }
            else
            {
                var filteredList = FinePayList.Where(FinePay =>
                    FinePay.IFineRefDate.ToString().ToLower().Contains(searchTerm) ||
                    FinePay.BorrowDate.ToString().ToLower().Contains(searchTerm) ||
                    FinePay.BorrowDays.ToString().ToLower().Contains(searchTerm) ||
                    FinePay.BorrowRetDate.ToString().ToLower().Contains(searchTerm) ||
                    FinePay.LateDays.ToString().ToLower().Contains(searchTerm) ||
                    FinePay.BookTitle.ToString().ToLower().Contains(searchTerm) ||
                    FinePay.Author.ToString().ToLower().Contains(searchTerm) ||
                    FinePay.Edition.ToString().ToLower().Contains(searchTerm) ||
                    FinePay.FineAmnt.ToString().ToLower().Contains(searchTerm)).ToList();

                dgvIFList.DataSource = filteredList;
            }
        }

     
    }
}