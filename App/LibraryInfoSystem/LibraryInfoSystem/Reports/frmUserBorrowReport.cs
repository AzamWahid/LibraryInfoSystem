using iTextSharp.text.pdf;
using iTextSharp.text;
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

            dgvBorrowList.Columns["BBDays"].HeaderText = "Borrow Days";
            dgvBorrowList.Columns["BBDays"].Width = 60;
            dgvBorrowList.Columns["BBDays"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBorrowList.Columns["BBDays"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

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

        private void btnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                BaseFont baseFont = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
                PdfPTable PdfPTable = new PdfPTable(dgvBorrowList.Columns.Cast<DataGridViewColumn>().Count(c => c.Visible));
                PdfPTable.DefaultCell.Padding = 3;
                PdfPTable.WidthPercentage = 100;
                PdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
                PdfPTable.DefaultCell.BorderWidth = 0;

                iTextSharp.text.Font HeaderFont = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font text = new iTextSharp.text.Font(baseFont, 10, iTextSharp.text.Font.NORMAL);
                float[] columnWidths = { 3f,2f, 6f, 5f, 4f, 2f, 2f, 2f };
                PdfPTable.SetWidths(columnWidths);
                foreach (DataGridViewColumn column in dgvBorrowList.Columns)
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
                foreach (DataGridViewRow row in dgvBorrowList.Rows)
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
                savefileddialogue.FileName = login.UName+"_BorrowReport";
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

                        PdfPCell reportNameCell = new PdfPCell(new Phrase(login.UName + " Borrow Details", text));
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