using iTextSharp.text.pdf;
using iTextSharp.text;
using LibraryInfoSystem.Borrow;
using LibraryInfoSystem.Register_Login;
using System.Data;

namespace LibraryInfoSystem
{
    public partial class frmImpFineDetReport : Form
    {
        List<clsFineDetReport> DetList = new List<clsFineDetReport>();

        private ClsLogin login;
        public frmImpFineDetReport(ClsLogin login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void frmImpFineDetReport_Load(object sender, EventArgs e)
        {
            rbtnAll.Checked = true;
            //  getListData();
        }

        private void getListData()
        {

        }
        private void btnFetch_Click(object sender, EventArgs e)
        {
            clsFineDetReport FineDet = new clsFineDetReport();
            FineDet.UEmail = tbEmail.Text;
            DetList = FineDet.GetImposeFineDetail();
            if (DetList.Count == 0)
            {
                MessageBox.Show("No record found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvList.DataSource = DetList;
                setGrid();
            }
            else
            {
                dgvList.DataSource = DetList;
                setGrid();
            }
        }
        private void setGrid()
        {
            dgvList.Columns["IFRefDate"].HeaderText = "Impose Fine Date";
            dgvList.Columns["IFRefDate"].Width = 120;
            dgvList.Columns["IFRefDate"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";

            dgvList.Columns["UEmail"].HeaderText = "User Email";
            dgvList.Columns["UEmail"].Width = 150;

            dgvList.Columns["UName"].HeaderText = "User Name";
            dgvList.Columns["UName"].Width = 80;

            dgvList.Columns["UMobileNo"].HeaderText = "User Mobile";
            dgvList.Columns["UMobileNo"].Width = 80;

            dgvList.Columns["BBRefDate"].HeaderText = "Borrow Date";
            dgvList.Columns["BBRefDate"].Width = 120;
            dgvList.Columns["BBRefDate"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";

            dgvList.Columns["BBDays"].HeaderText = "Borrow Days";
            dgvList.Columns["BBDays"].Width = 50;
            dgvList.Columns["BBDays"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvList.Columns["BBDays"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvList.Columns["BRRefDate"].HeaderText = "Borrow Return Date";
            dgvList.Columns["BRREfDate"].Width = 120;
            dgvList.Columns["BRREfDate"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";

            dgvList.Columns["late_Days"].HeaderText = "Late Days";
            dgvList.Columns["late_Days"].Width = 45;
            dgvList.Columns["late_Days"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvList.Columns["late_Days"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvList.Columns["BookTitle"].HeaderText = "Book Title";
            dgvList.Columns["BookTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvList.Columns["Author"].HeaderText = "Book Author";
            dgvList.Columns["Author"].Width = 130;
            dgvList.Columns["Author"].Visible = false;

            dgvList.Columns["ISBN"].HeaderText = "ISBN";
            dgvList.Columns["ISBN"].Visible = false;

            dgvList.Columns["Edition"].HeaderText = "Edition";
            dgvList.Columns["Edition"].Width = 42;
            dgvList.Columns["Edition"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvList.Columns["Edition"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvList.Columns["Year"].HeaderText = "Year";
            dgvList.Columns["Year"].Width = 40;
            dgvList.Columns["Year"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvList.Columns["Year"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvList.Columns["Year"].Visible = false;

            dgvList.Columns["FineAmnt"].HeaderText = "Fine Amount";
            dgvList.Columns["FineAmnt"].Width = 60;
            dgvList.Columns["FineAmnt"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvList.Columns["FineAmnt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            string searchTerm = tbSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                dgvList.DataSource = DetList;
            }
            else
            {
                var filteredList = DetList.Where(Fine =>
                    Fine.IFRefDate.ToString().Contains(searchTerm) ||
                    Fine.UEmail.ToString().Contains(searchTerm) ||
                    Fine.UName.ToString().Contains(searchTerm) ||
                    Fine.UMobileNo.ToString().Contains(searchTerm) ||
                    Fine.BBRefDate.ToString().Contains(searchTerm) ||
                    Fine.BBDays.ToString().Contains(searchTerm) ||
                    Fine.BRRefDate.ToString().Contains(searchTerm) ||
                    Fine.late_Days.ToString().Contains(searchTerm) ||
                    Fine.BookTitle.ToLower().Contains(searchTerm) ||
                    Fine.Author.ToLower().Contains(searchTerm) ||
                    Fine.Year.ToString().Contains(searchTerm) ||
                    Fine.ISBN.ToString().Contains(searchTerm) ||
                    Fine.Edition.ToString().Contains(searchTerm)).ToList();
                dgvList.DataSource = filteredList;
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                BaseFont baseFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
                PdfPTable PdfPTable = new PdfPTable(dgvList.Columns.Cast<DataGridViewColumn>().Count(c => c.Visible));
                PdfPTable.DefaultCell.Padding = 3;
                PdfPTable.WidthPercentage = 100;
                PdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
                PdfPTable.DefaultCell.BorderWidth = 0;

                iTextSharp.text.Font HeaderFont = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font text = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL);
                float[] columnWidths = { 3f, 3f, 3f, 3f, 3f, 2f, 3f, 2f, 6f, 2f,3f };
                PdfPTable.SetWidths(columnWidths);
                foreach (DataGridViewColumn column in dgvList.Columns)
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
                foreach (DataGridViewRow row in dgvList.Rows)
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
                savefileddialogue.FileName = "ImposeFineDetail";
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

                        PdfPCell reportNameCell = new PdfPCell(new Phrase("Impose Fine Details", text));
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

        private void rbtnAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnAll.Checked)
            {
                tbEmail.Enabled = false;
                tbEmail.Text = "All";
            }
        }

        private void rbtnSpecific_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnSpecific.Checked)
            {
                tbEmail.Enabled = true;
                tbEmail.Text = "";
            }
        }


    }
}