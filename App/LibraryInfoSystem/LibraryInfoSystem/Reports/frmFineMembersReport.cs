using iTextSharp.text.pdf;
using iTextSharp.text;
using LibraryInfoSystem.Borrow;
using LibraryInfoSystem.Register_Login;
using System.Data;

namespace LibraryInfoSystem
{
    public partial class frmFineMembersReport : Form
    {
        List<clsFineMembersReport> ImposeFineList = new List<clsFineMembersReport>();

        private decimal _totFineVal;
        private ClsLogin login;
        public frmFineMembersReport(ClsLogin login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void frmFineMembersReport_Load(object sender, EventArgs e)
        {
            getListData();
        }

        private void getListData()
        {
            clsFineMembersReport ImposeFine = new clsFineMembersReport();
            ImposeFineList = ImposeFine.GetImposeFineMember();
            if (ImposeFineList.Count == 0)
            {
                MessageBox.Show("No record found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvList.DataSource = ImposeFineList;
                setGrid();
            }
            else
            {
                dgvList.DataSource = ImposeFineList;
                setGrid();
            }

            for (int i = 0; i < dgvList.Rows.Count; i++)
            {
                _totFineVal += Math.Round(Convert.ToDecimal(dgvList.Rows[i].Cells["FineAmnt"].Value), 2);
            }
            lblTotFine.Text = _totFineVal.ToString("N2");
        }
        private void setGrid()
        {
            dgvList.Columns["UEmail"].HeaderText = "User Email";
            dgvList.Columns["UEmail"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvList.Columns["UName"].HeaderText = "User Name";
            dgvList.Columns["UName"].Width = 140;

            dgvList.Columns["UMobileNo"].HeaderText = "User Mobile";
            dgvList.Columns["UMobileNo"].Width = 120;

            dgvList.Columns["FineAmnt"].HeaderText = "Fine Amount";
            dgvList.Columns["FineAmnt"].Width = 120;
            dgvList.Columns["FineAmnt"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvList.Columns["FineAmnt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            string searchTerm = tbSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                dgvList.DataSource = ImposeFineList;
            }
            else
            {
                var filteredList = ImposeFineList.Where(fine =>
                    fine.UEmail.ToString().Contains(searchTerm) ||
                    fine.UName.ToString().Contains(searchTerm) ||
                    fine.UMobileNo.ToString().Contains(searchTerm) ||
                    fine.FineAmnt.ToString().Contains(searchTerm)

                ).ToList();
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
                float[] columnWidths = { 6f, 4f, 4f, 2f };
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
                savefileddialogue.FileName = "FineMembers";
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

                        PdfPCell reportNameCell = new PdfPCell(new Phrase("All Members Fine ", text));
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