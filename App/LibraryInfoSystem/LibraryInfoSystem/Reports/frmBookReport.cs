using iTextSharp.text.pdf;
using iTextSharp.text;
using LibraryInfoSystem.Borrow;
using LibraryInfoSystem.Register_Login;
using System.Data;

namespace LibraryInfoSystem
{
    public partial class frmBookReport : Form
    {
        List<clsBookReport> BookList = new List<clsBookReport>();

        private ClsLogin login;
        public frmBookReport(ClsLogin login)
        {
            InitializeComponent();
            this.login = login;
        }

        private void frmBorrowReport_Load(object sender, EventArgs e)
        {

            getListData();
        }

        private void getListData()
        {
            clsBookReport borrow = new clsBookReport();
            BookList = borrow.GetAvaBooks();
            dgvBookList.DataSource = BookList;
            setGrid();
        }
        private void setGrid()
        {

            dgvBookList.Columns["BookID"].Visible = false;
            dgvBookList.Columns["BookCode"].Visible = false;

            dgvBookList.Columns["BookTitle"].HeaderText = "Book Title";
            dgvBookList.Columns["BookTitle"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvBookList.Columns["Author"].HeaderText = "Book Author";
            dgvBookList.Columns["Author"].Width = 120;

            dgvBookList.Columns["ISBN"].HeaderText = "ISBN";
            dgvBookList.Columns["ISBN"].Width = 100;

            dgvBookList.Columns["Edition"].HeaderText = "Edition";
            dgvBookList.Columns["Edition"].Width = 45;
            dgvBookList.Columns["Edition"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBookList.Columns["Edition"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvBookList.Columns["Year"].HeaderText = "Year";
            dgvBookList.Columns["Year"].Width = 45;
            dgvBookList.Columns["Year"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBookList.Columns["Year"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvBookList.Columns["NoofCopies"].HeaderText = "Copies";
            dgvBookList.Columns["NoofCopies"].Width = 80;
            dgvBookList.Columns["NoofCopies"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBookList.Columns["NoofCopies"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvBookList.Columns["Borrow"].HeaderText = "Borrow";
            dgvBookList.Columns["Borrow"].Width = 80;
            dgvBookList.Columns["Borrow"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBookList.Columns["Borrow"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvBookList.Columns["remainingCopies"].HeaderText = "Remaining Copies";
            dgvBookList.Columns["remainingCopies"].Width = 80;
            dgvBookList.Columns["remainingCopies"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBookList.Columns["remainingCopies"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }
    
        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {

            string searchTerm = tbSearch.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                dgvBookList.DataSource = BookList;
            }
            else
            {
                var filteredList = BookList.Where(book =>
                    book.BookTitle.ToLower().Contains(searchTerm) ||
                    book.Author.ToLower().Contains(searchTerm) ||
                    book.Year.ToString().Contains(searchTerm) ||
                    book.ISBN.ToString().Contains(searchTerm) ||
                    book.Edition.ToString().Contains(searchTerm) ||
                    book.NoofCopies.ToString().Contains(searchTerm) ||
                    book.Borrow.ToString().Contains(searchTerm) ||
                    book.remainingCopies.ToString().Contains(searchTerm)

                ).ToList();
                dgvBookList.DataSource = filteredList;
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                BaseFont baseFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
                PdfPTable PdfPTable = new PdfPTable(dgvBookList.Columns.Cast<DataGridViewColumn>().Count(c => c.Visible));
                PdfPTable.DefaultCell.Padding = 3;
                PdfPTable.WidthPercentage = 100;
                PdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
                PdfPTable.DefaultCell.BorderWidth = 0;

                iTextSharp.text.Font HeaderFont = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font text = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL);
                float[] columnWidths = { 6f, 4f, 3f, 2f,2f, 2f, 2f,2f };
                PdfPTable.SetWidths(columnWidths);
                foreach (DataGridViewColumn column in dgvBookList.Columns)
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
                foreach (DataGridViewRow row in dgvBookList.Rows)
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
                savefileddialogue.FileName = "BookDetail";
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

                        PdfPCell reportNameCell = new PdfPCell(new Phrase("Book Details", text));
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