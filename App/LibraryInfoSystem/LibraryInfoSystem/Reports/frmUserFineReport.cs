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
        private decimal _totFineVal;

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

            for (int i = 0; i < dgvIFList.Rows.Count; i++)
            {
                _totFineVal += Math.Round(Convert.ToDecimal(dgvIFList.Rows[i].Cells["FineAmnt"].Value), 2);
            }
            lblTotFine.Text = _totFineVal.ToString("N2");
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
            dgvIFList.Columns["BorrowDays"].Width = 50;
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
            dgvIFList.Columns["Author"].Visible = false;

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
            dgvIFList.Columns["FineAmnt"].Width = 80;
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

        private void btnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                BaseFont baseFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
                PdfPTable PdfPTable = new PdfPTable(dgvIFList.Columns.Cast<DataGridViewColumn>().Count(c => c.Visible));
                PdfPTable.DefaultCell.Padding = 3;
                PdfPTable.WidthPercentage = 100;
                PdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
                PdfPTable.DefaultCell.BorderWidth = 0;

                iTextSharp.text.Font HeaderFont = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font text = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL);
                float[] columnWidths = { 3f, 3f, 2f, 3f, 1f, 6f, 2f, 3f };
                PdfPTable.SetWidths(columnWidths);
                foreach (DataGridViewColumn column in dgvIFList.Columns)
                {
                    if (column.Visible)
                    {
                        PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, HeaderFont));
                        cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);

                        if (column.HeaderCell.Style.Alignment == DataGridViewContentAlignment.MiddleCenter)
                        {
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        }
                        // Set alignment for right-aligned columns
                        else if (column.HeaderCell.Style.Alignment == DataGridViewContentAlignment.MiddleRight)
                        {
                            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                        }
                        else
                        {
                            cell.HorizontalAlignment = Element.ALIGN_LEFT; // Default to center alignment
                        }

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
                            PdfPCell dataCell = new PdfPCell(new Phrase(cell.Value.ToString(), text));

                            if (cell.InheritedStyle.Alignment == DataGridViewContentAlignment.MiddleCenter)
                            {
                                dataCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            }
                            // Set alignment for right-aligned cells
                            else if (cell.InheritedStyle.Alignment == DataGridViewContentAlignment.MiddleRight)
                            {
                                dataCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                            }
                            else
                            {
                                dataCell.HorizontalAlignment = Element.ALIGN_LEFT; // Default to center alignment
                            }

                            PdfPTable.AddCell(dataCell);
                        }
                    }
                }

                var savefileddialogue = new SaveFileDialog();
                savefileddialogue.FileName = login.UName + "_FinrDetailst";
                savefileddialogue.DefaultExt = ".pdf";
                if (savefileddialogue.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(savefileddialogue.FileName, FileMode.Create))
                    {
                        Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                        PdfWriter.GetInstance(pdfdoc, stream);
                        pdfdoc.Open();



                        PdfPTable headerTable = new PdfPTable(1);
                        headerTable.WidthPercentage = 100;
                        headerTable.DefaultCell.Border = PdfPCell.NO_BORDER;

                        PdfPCell companyNameCell = new PdfPCell(new Phrase("Library Information System", text));
                        companyNameCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        companyNameCell.PaddingTop = 10f;
                        headerTable.AddCell(companyNameCell);

                        PdfPCell reportNameCell = new PdfPCell(new Phrase(login.UName + " Fine Details", text));
                        reportNameCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerTable.AddCell(reportNameCell);
                        PdfPTable userDetailsTable = new PdfPTable(1);
                        userDetailsTable.WidthPercentage = 100;
                        userDetailsTable.DefaultCell.Border = PdfPCell.NO_BORDER;

                        // Add a cell for user details
                        PdfPCell userDetailsCell = new PdfPCell(new Phrase("User Name: " + login.UName + "           Email: " + login.UEmail + "         Mobile No. : " + login.UMobileNo, text));
                        userDetailsCell.HorizontalAlignment = Element.ALIGN_LEFT;
                        userDetailsTable.AddCell(userDetailsCell);

                        pdfdoc.Add(headerTable);
                        pdfdoc.Add(userDetailsTable);
                        pdfdoc.Add(PdfPTable);
                        pdfdoc.Close();
                        stream.Close();

                    }
                    MessageBox.Show("PDF saved successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Process Cancel", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch
            {
                MessageBox.Show("An error occurred while saving the PDF. Please make sure the file is not already open.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}