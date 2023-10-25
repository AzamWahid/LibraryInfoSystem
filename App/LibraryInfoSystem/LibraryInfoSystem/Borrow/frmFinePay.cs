using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.collection;
using LibraryInfoSystem.Borrow;
using LibraryInfoSystem.Register_Login;
using System.Data;
using System.IO;

namespace LibraryInfoSystem
{
    public partial class frmFinePay : Form
    {
        List<clsFinePay> FinePayList = new List<clsFinePay>();
        private long _IFID = 0;


        private ClsLogin login;
        public frmFinePay(ClsLogin login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void frmFinePay_Load(object sender, EventArgs e)
        {
            NewFinePayRefNo();
        }
        private void getListData()
        {
            clsFinePay FinePay = new clsFinePay();
            FinePay.UID = login.UID;
            FinePayList = FinePay.GetImposeFineList();
            dgvIFList.DataSource = FinePayList;
            setGrid();
        }
        private void setGrid()
        {
            dgvIFList.Columns["UID"].Visible = false;
            dgvIFList.Columns["FinePayRefNo"].Visible = false;
            dgvIFList.Columns["FinePayRefDate"].Visible = false;
            dgvIFList.Columns["IFID"].Visible = false;
            dgvIFList.Columns["IFineRefNo"].Visible = false;
            dgvIFList.Columns["BorrowID"].Visible = false;
            dgvIFList.Columns["BorrowNo"].Visible = false;
            dgvIFList.Columns["BorrowDate"].Visible = false;
            dgvIFList.Columns["BorrowDays"].Visible = false;
            dgvIFList.Columns["BorrowRetID"].Visible = false;
            dgvIFList.Columns["BorrowRetNo"].Visible = false;
            dgvIFList.Columns["BorrowRetDate"].Visible = false;
            dgvIFList.Columns["Author"].Visible = false;
            dgvIFList.Columns["ISBN"].Visible = false;
            dgvIFList.Columns["Year"].Visible = false;
            dgvIFList.Columns["Edition"].Visible = false;
            dgvIFList.Columns["BRFineYN"].Visible = false;

            dgvIFList.Columns["IFineRefDate"].HeaderText = "Impose Fine Date";
            dgvIFList.Columns["IFineRefDate"].Width = 120;
            dgvIFList.Columns["IFineRefDate"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";

            dgvIFList.Columns["BookTitle"].HeaderText = "Book Title";
            dgvIFList.Columns["BookTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvIFList.Columns["LateDays"].HeaderText = "Late Days";
            dgvIFList.Columns["LateDays"].Width = 50;
            dgvIFList.Columns["LateDays"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvIFList.Columns["FineAmnt"].HeaderText = "Fine Value";
            dgvIFList.Columns["FineAmnt"].Width = 50;
            dgvIFList.Columns["FineAmnt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvIFList.Columns["FineAmnt"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (saveCheck())
            {
                clsFinePay finePay = new clsFinePay();

                finePay.FinePayRefNo = long.Parse(tbRefNo.Text);
                finePay.FinePayRefDate = dcFinePauDate.Value;
                finePay.IFID = _IFID;
                finePay.FineAmnt = decimal.Parse(tbFineValue.Text);

                finePay.SaveFinePay();

                MessageBox.Show("Fine Pay Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NewFinePayRefNo();
            }
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
                    FinePay.BookTitle.ToString().ToLower().Contains(searchTerm) ||
                    FinePay.LateDays.ToString().Contains(searchTerm) ||
                    FinePay.FineAmnt.ToString().ToLower().Contains(searchTerm)).ToList();

                dgvIFList.DataSource = filteredList;
            }
        }
        //-------------------------------------------------SAVE CHECK-------------------------------------------------------------------------
        private bool saveCheck()
        {
            if (tbRefNo.Text == "0")
            {
                MessageBox.Show("Impose Fine No. should not be zero", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbRefNo.Focus();
                return false;
            }
            if (_IFID == 0)
            {
                MessageBox.Show("please select any Late Return", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbBookTitle.Focus();
            }
            if (tbBookTitle.Text == "")
            {
                MessageBox.Show("Book Title should not be empty", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbBookTitle.Focus();
                return false;
            }
            if (tbFineValue.Text == "0")
            {
                MessageBox.Show("Fine Amount should not be zero", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tbBookTitle.Focus();
                return false;
            }
            return true;
        }
        //-------------------------------------------------GRID DOUBLE CLICK EDIT-------------------------------------------------------------------------

        private void dgvIFList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvIFList.Rows.Count > 0)
            {
                _IFID = long.Parse(dgvIFList.CurrentRow.Cells["IFID"].Value.ToString().Trim());
                lblImposeNo.Text = dgvIFList.CurrentRow.Cells["IFineRefNo"].Value.ToString().Trim();
                lblImposeDate.Text = Convert.ToDateTime(dgvIFList.CurrentRow.Cells["IFineRefDate"].Value.ToString().Trim()).ToString("dd/MM/yyyy hh:mm tt");
                lblBorrowNo.Text = dgvIFList.CurrentRow.Cells["BorrowNo"].Value.ToString().Trim();
                lblBorrowDate.Text = Convert.ToDateTime(dgvIFList.CurrentRow.Cells["BorrowDate"].Value.ToString().Trim()).ToString("dd/MM/yyyy hh:mm tt");
                lblBorrowDays.Text = dgvIFList.CurrentRow.Cells["BorrowDays"].Value.ToString().Trim();
                lblRetNo.Text = dgvIFList.CurrentRow.Cells["BorrowRetNo"].Value.ToString().Trim();
                lblRetDate.Text = Convert.ToDateTime(dgvIFList.CurrentRow.Cells["BorrowRetDate"].Value.ToString().Trim()).ToString("dd/MM/yyyy hh:mm tt");
                tbBookTitle.Text = dgvIFList.CurrentRow.Cells["BookTitle"].Value.ToString().Trim();
                tbBookAuthor.Text = dgvIFList.CurrentRow.Cells["Author"].Value.ToString().Trim();
                tbBookISBN.Text = dgvIFList.CurrentRow.Cells["ISBN"].Value.ToString().Trim();
                mskYear.Text = dgvIFList.CurrentRow.Cells["Year"].Value.ToString().Trim();
                tbBookEdition.Text = dgvIFList.CurrentRow.Cells["Edition"].Value.ToString().Trim();
                lblLateDays.Text = dgvIFList.CurrentRow.Cells["LateDays"].Value.ToString().Trim();
                tbFineValue.Text = Convert.ToDecimal(dgvIFList.CurrentRow.Cells["FineAmnt"].Value).ToString().Trim();
            }
        }
        //----------------------------NewImposeFineRefNo------------------------------------------------------------------
        private void NewFinePayRefNo()
        {
            clsFinePay finePay = new clsFinePay();

            finePay.GetFinePayNo();
            tbRefNo.Text = finePay.FinePayRefNo.ToString();
            dcFinePauDate.Value = DateTime.Now;

            _IFID = 0;
            lblBorrowNo.Text = "";
            lblBorrowDate.Text = "";
            lblBorrowDays.Text = "";
            lblRetNo.Text = "";
            lblRetDate.Text = "";
            tbBookTitle.Text = "";
            tbBookAuthor.Text = "";
            tbBookISBN.Text = "";
            mskYear.Text = "";
            tbBookEdition.Text = "0";
            lblLateDays.Text = "0";
            tbFineValue.Text = "0";

            getListData();
        }
        //-------------------------------------------------FOCUS ON FORM FORM REFRESH-------------------------------------------------------------------------
        private void frmFinePay_Activated(object sender, EventArgs e)
        {
            getListData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BaseFont baseFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
            PdfPTable PdfPTable = new PdfPTable(dgvIFList.Rows.Count);
            PdfPTable.DefaultCell.Padding = 3;
            PdfPTable.WidthPercentage = 100;
            PdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            PdfPTable.DefaultCell.BorderWidth = 1;

            iTextSharp.text.Font text = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL);



            // Add column headers
            foreach (DataGridViewColumn column in dgvIFList.Columns)
            {
                if (column.Visible)  // Check if the column is visible
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, text));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);



                    PdfPTable.AddCell(cell);
                }
            }

            // Add data rows
            foreach (DataGridViewRow row in dgvIFList.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Visible)  // Check if the column is visible
                    {
                        PdfPTable.AddCell(new Phrase(cell.Value.ToString(), text));
                    }
                }
            }

            var savefileddialogue = new SaveFileDialog();
            savefileddialogue.FileName = "hello";
            savefileddialogue.DefaultExt = ".pdf";
            if (savefileddialogue.ShowDialog()==DialogResult.OK)
            {
                using (FileStream stream = new FileStream(savefileddialogue.FileName,FileMode.Create))
                { 
                    Document pdfdoc = new Document(PageSize.A4,10f,10f,10f,0f);
                    PdfWriter.GetInstance(pdfdoc,stream);
                    pdfdoc.Open();
                    pdfdoc.Add(PdfPTable);
                    pdfdoc.Close();
                    stream.Close();

                }
            }

            MessageBox.Show("PDF saved successfully!");


        }
    }
}