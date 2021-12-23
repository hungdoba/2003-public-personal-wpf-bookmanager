using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace booksManager
{
    public partial class Form1 : Form
    {
        SqlCeCommand cmd;
        private string connectionString = "Data Source = bookManagerDatabase.sdf; Password = ''";
        List<borrowBookClass> borrowBookClasses = new List<borrowBookClass>();
        List<bookBorrowPriceClass> bookBorrowPriceClasses = new List<bookBorrowPriceClass>();
        List<booksClass> booksClasses = new List<booksClass>();
        List<borrowerClass> borrowerClasses = new List<borrowerClass>();
        bookBorrowPriceClass bookBorrowPriceClass = new bookBorrowPriceClass();
        booksClass booksClass = new booksClass();
        borrowBookClass borrowBookClass = new borrowBookClass();
        borrowerClass borrowerClass = new borrowerClass();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            searchResult.Visible = false;
            updateDataGridBorrower();
            updateDataGridBooks();
            updateDataGridBookBorrowPrice();
            updateDataGridBorrowBook();
            TxtSuggest();
        }

        private void updateDataGridBorrowBook()
        {
            // Update borrow book data grid view
            borrowBookClasses = borrowBookClass.databaseToClass(connectionString);
            borrowBookClass.getInforID(ref borrowBookClasses, borrowerClasses, booksClasses, bookBorrowPriceClasses);
            gridBorrowBook.DataSource = borrowBookClasses.OrderBy(r => r.borrowID).ToList();
            gridBorrowBookShow(borrowBookClasses);
        }

        private void updateDataGridBorrower()
        {
            // Update borrower data grid view
            borrowerClasses = borrowerClass.databaseToClass(connectionString);
            gridBorrower.DataSource = borrowerClasses.OrderBy(r => r.userID).ToList();
        }

        private void updateDataGridBooks()
        {
            // Update book data grid view
            booksClasses = booksClass.databaseToClass(connectionString);
            booksClass.showBookContents(ref booksClasses, connectionString);
            booksClass.updateNumberOfBookInStorage(ref booksClasses, borrowBookClasses);
            gridBooks.DataSource = booksClasses.OrderBy(r => r.bookID).ToList();
        }

        private void updateDataGridBookBorrowPrice()
        {
            // Update book type data grid view
            bookBorrowPriceClasses = bookBorrowPriceClass.databaseToClass(connectionString);
            gridBookBorrowPrice.DataSource = bookBorrowPriceClasses.OrderBy(r => r.contentsID).ToList();
        }

        private void gridBorrowBookShow(List<borrowBookClass> borrowBookClasses)
        {
            foreach (DataGridViewRow row in gridBorrowBook.Rows)
            {
                //MessageBox.Show(row.Cells["timeReturnDataGridViewTextBoxColumn"].Value.ToString());
                if (row.Cells["timeReturnDataGridViewTextBoxColumn"].Value.ToString()=="0001/01/01 0:00:00")
                {
                    DataGridViewButtonCell dataGridViewButton = new DataGridViewButtonCell();
                    row.Cells["timeReturnDataGridViewTextBoxColumn"].Value = DateTime.Now.ToString("MM/dd/yyy");
                    row.Cells["timeReturnDataGridViewTextBoxColumn"] = dataGridViewButton;
                }
            }
        }

        private void TxtSuggest()
        {
            txtFilter.AutoCompleteSource = AutoCompleteSource.AllSystemSources;
            txtFilter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtFilter.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            foreach (borrowerClass borrowerClass1 in borrowerClasses)
            {
                data.Add(borrowerClass1.name.ToString());
                data.Add(borrowerClass1.address.ToString());
                data.Add(borrowerClass1.phone.ToString());
            }
            foreach (booksClass books in booksClasses)
            {
                data.Add(books.name.ToString());
            }
            txtFilter.AutoCompleteCustomSource = data;
        }

        private List<booksClass> dataToClassBook(string connectingString)
        {
            // connect to database
            SqlCeConnection connection = new SqlCeConnection(connectingString);
            connection.Open();
            cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM books";

            // get data from database book to class book
            List<booksClass> booksClasses = new List<booksClass>();
            booksClass booksClass = new booksClass();
            using(SqlCeDataReader databaseContents = cmd.ExecuteReader())
            {
                while(databaseContents.Read())
                {
                    booksClass.bookID = Convert.ToInt32(databaseContents["bookID"]);
                    booksClass.name = databaseContents["name"].ToString();
                    booksClass.author = databaseContents["author"].ToString();
                    booksClass.topic = databaseContents["topic"].ToString();
                    booksClass.contentsIDInsert(Convert.ToInt32(databaseContents["contentsID"]));
                    booksClass.note = databaseContents["note"].ToString();
                    if(databaseContents["numberOfBook"].ToString()!="")
                    {
                        booksClass.numberOfBook = Convert.ToInt32(databaseContents["numberOfBook"]);
                    }
                    booksClasses.Add(booksClass);
                    booksClass = new booksClass();
                }
            }
            return booksClasses;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            searchResult.Visible = false;
            borrowBookClass borrowBookClass = new borrowBookClass();
            if(cmbFilter.SelectedItem == null)
            {
                MessageBox.Show("Hãy chọn thông tin bộ lọc");
            }
            else if (cmbFilter.SelectedItem.ToString() == "Lọc theo tên người mượn")
            {
                if (txtFilter.Text.ToString()=="")
                {
                    MessageBox.Show("Hãy điền tên người mượn sách");
                }
                else
                {
                    gridBorrowBook.DataSource = null;
                    gridBorrowBook.DataSource = borrowBookClass.findData(borrowBookClasses, "userName", txtFilter.Text.ToString());
                    if (gridBorrowBook.DataSource == null)
                    {
                        MessageBox.Show("Không tìm thấy tên người mượn sách này");
                        gridBorrowBook.DataSource = borrowBookClasses;
                    }
                    else
                    {
                        searchResult.Text = "có " + gridBorrowBook.RowCount.ToString() + " kết quả";
                        searchResult.Visible = true;
                    }
                }
            }
            else if (cmbFilter.SelectedItem.ToString() == "Lọc theo số điện thoại")
            {
                if (txtFilter.Text.ToString() == "")
                {
                    MessageBox.Show("Hãy điền số điện thoại người mượn");
                }
                else
                {
                    gridBorrowBook.DataSource = null;
                    gridBorrowBook.DataSource = borrowBookClass.findData(borrowBookClasses, "phone", txtFilter.Text.ToString());
                    if (gridBorrowBook.DataSource == null)
                    {
                        MessageBox.Show("Không tìm thấy số điện thoại này");
                        gridBorrowBook.DataSource = borrowBookClasses;
                    }
                    else
                    {
                        searchResult.Text = "có " + gridBorrowBook.RowCount.ToString() + " kết quả";
                        searchResult.Visible = true;
                    }
                }
            }
            else if (cmbFilter.SelectedItem.ToString() == "Lọc theo tên sách")
            {
                if (txtFilter.Text.ToString() == "")
                {
                    MessageBox.Show("Hãy điền tên sách");
                }
                else
                {
                    gridBorrowBook.DataSource = null;
                    gridBorrowBook.DataSource = borrowBookClass.findData(borrowBookClasses, "bookName", txtFilter.Text.ToString());
                    if (gridBorrowBook.DataSource==null)
                    {
                        MessageBox.Show("Không tìm thấy tên sách này");
                        gridBorrowBook.DataSource = borrowBookClasses;
                    }
                    else
                    {
                        searchResult.Text = "có " + gridBorrowBook.RowCount.ToString() + " kết quả";
                        searchResult.Visible = true;
                    }
                }
            }
            else if (cmbFilter.SelectedItem.ToString() == "Lọc theo địa chỉ")
            {
                if (txtFilter.Text.ToString() == "")
                {
                    MessageBox.Show("Hãy điền địa chỉ");
                }
                else
                {
                    gridBorrowBook.DataSource = null;
                    gridBorrowBook.DataSource = borrowBookClass.findData(borrowBookClasses, "address", txtFilter.Text.ToString());
                    if (gridBorrowBook.DataSource == null)
                    {
                        MessageBox.Show("Không có ai ở địa chỉ này");
                        gridBorrowBook.DataSource = borrowBookClasses;
                    }
                    else
                    {
                        searchResult.Text = "có " + gridBorrowBook.RowCount.ToString() + " kết quả";
                        searchResult.Visible = true;
                    }
                }
            }
            else if (cmbFilter.SelectedItem.ToString().Contains("Lọc theo thời gian mượn"))
            {
                gridBorrowBook.DataSource = null;
                gridBorrowBook.DataSource = borrowBookClass.findData(borrowBookClasses, "timeBorrow", dateTimePick.Value.ToString("dd/MM/yyyy"));
                if (gridBorrowBook.DataSource == null)
                {
                    MessageBox.Show("Không có ai mượn sách trong ngày:  "+ dateTimePick.Value.ToString("dd/MM/yyyy"));
                    gridBorrowBook.DataSource = borrowBookClasses;
                }
                else
                {
                    searchResult.Text = "có " + gridBorrowBook.RowCount.ToString() + " kết quả";
                    searchResult.Visible = true;
                }
            }
            else if (cmbFilter.SelectedItem.ToString().Contains("Lọc theo thời gian trả"))
            {
                gridBorrowBook.DataSource = null;
                gridBorrowBook.DataSource = borrowBookClass.findData(borrowBookClasses, "timeReturn", dateTimePick.Value.ToString("dd/MM/yyyy"));
                if (gridBorrowBook.DataSource == null)
                {
                    MessageBox.Show("Không có ai trả sách trong ngày:  " + dateTimePick.Value.ToString("dd/MM/yyyy"));
                    gridBorrowBook.DataSource = borrowBookClasses;
                }
                else
                {
                    searchResult.Text = "có " + gridBorrowBook.RowCount.ToString() + " kết quả";
                    searchResult.Visible = true;
                }
            }
            else if(cmbFilter.SelectedItem.ToString().Contains("Xem tất cả"))
            {
                gridBorrowBook.DataSource = null;
                gridBorrowBook.DataSource = borrowBookClasses;
            }
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbFilter.SelectedItem.ToString().Contains("Lọc theo thời gian mượn")|| cmbFilter.SelectedItem.ToString().Contains("Lọc theo thời gian trả"))
            {
                dateTimePick.Visible = true;
                txtFilter.Visible = false;
            }
            else
            {
                dateTimePick.Visible = false;
                txtFilter.Visible = true;
            }
        }

        private void btnNewBorrow_Click(object sender, EventArgs e)
        {
            newBorrowForm newBorrowForm = new newBorrowForm();
            newBorrowForm.ShowDialog();
            //borrowBookClasses = borrowBookClass.databaseToClass(connectionString);
            //borrowBookClass.getInforID(ref borrowBookClasses, borrowerClasses, booksClasses, bookBorrowPriceClasses);
            //gridBorrowBook.DataSource = borrowBookClasses;
            updateDataGridBorrowBook();
        }

        private void gridBorrowBook_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.RowIndex >= 0 && senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewButtonCell)
            {
                if(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    DialogResult dialog = MessageBox.Show("Nếu Chị ấn OK thì hàng này sẽ bị xóa vĩnh viễn. Muốn quay lại hãy ấn Cancel", "Xác nhận xóa hàng", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if(dialog == DialogResult.OK)
                    {
                        Int32.TryParse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString(), out int index);
                        borrowBookClass.deleteDataInDatabase(connectionString, index);
                        updateDataGridBorrowBook();
                        MessageBox.Show("Xóa hàng thành công");
                    }
                }
                else
                {
                    string[] sendData = new string[8];
                    for(int i = 0, j = 0;i<senderGrid.Rows[e.RowIndex].Cells.Count;i++)
                    {
                        if (i != 7 && i != 8 && i != 10 && senderGrid.Rows[e.RowIndex].Cells[i].Value != null)
                        {
                            //MessageBox.Show(senderGrid.Rows[e.RowIndex].Cells.Count.ToString()+i.ToString()+j.ToString());
                            sendData[j] = senderGrid.Rows[e.RowIndex].Cells[i].Value.ToString();
                            j++;
                        }
                    }

                    // New return form
                    returnBookForm returnBookForm = new returnBookForm();
                    // Get money day
                    foreach(borrowBookClass borrowBookClass in borrowBookClasses)
                    {
                        if(borrowBookClass.borrowID == Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[0].Value))
                        {
                            returnBookForm.dayMoney = borrowBookClass.moneyDayReturn();
                        }
                    }
                    returnBookForm.borrowID = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[0].Value);
                    returnBookForm.inputData = sendData;
                    DialogResult result = returnBookForm.ShowDialog();
                    if(result == DialogResult.OK)
                    {
                        updateDataGridBorrowBook();
                    }
                }
            }
            //MessageBox.Show(senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].GetType().ToString());
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            newUser newUser = new newUser();
            newUser.ShowDialog();
            updateDataGridBorrower();
        }

        private void btnNewBook_Click(object sender, EventArgs e)
        {
            newBook newBook = new newBook();
            newBook.ShowDialog();
            updateDataGridBooks();
        }

        private void gridBorrower_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                if(e.ColumnIndex==5)
                {
                    newUser newUser = new newUser();
                    newUser.userID = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[0].Value);
                    newUser.nameUser = senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                    newUser.address = senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
                    newUser.phone = senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                    newUser.notes = senderGrid.Rows[e.RowIndex].Cells[4].Value.ToString();
                    newUser.update = true;
                    newUser.ShowDialog();
                    updateDataGridBorrower();
                }
                else if(e.ColumnIndex==6)
                {
                    DialogResult dialog = MessageBox.Show("Nếu Chị ấn OK thì hàng này sẽ bị xóa vĩnh viễn. Muốn quay lại hãy ấn Cancel", "Xác nhận xóa hàng", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.OK)
                    {
                        Int32.TryParse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString(), out int index);
                        borrowerClass.deleteDataInDatabase(connectionString, index);
                        updateDataGridBorrower();
                        MessageBox.Show("Xóa hàng thành công");
                    }
                }
            }
        }

        private void gridBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                // Button change book's information
                if (e.ColumnIndex == 7)
                {
                    newBook newBook = new newBook();
                    newBook.update = true;
                    newBook.bookID = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[0].Value);
                    newBook.name = senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                    newBook.author = senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString();
                    newBook.topic = senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                    if(senderGrid.Rows[e.RowIndex].Cells[4].Value!=null)
                    {
                        newBook.contents = senderGrid.Rows[e.RowIndex].Cells[4].Value.ToString();
                    }
                    else
                    {
                        newBook.contents = null;
                    }
                    newBook.amount = senderGrid.Rows[e.RowIndex].Cells[5].Value.ToString();
                    newBook.note = senderGrid.Rows[e.RowIndex].Cells[6].Value.ToString();
                    newBook.ShowDialog();
                    updateDataGridBooks();
                }
                // Button delete books
                else if (e.ColumnIndex == 8)
                {
                    DialogResult dialog = MessageBox.Show("Nếu Chị ấn OK thì hàng này sẽ bị xóa vĩnh viễn. Muốn quay lại hãy ấn Cancel", "Xác nhận xóa hàng", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.OK)
                    {
                        Int32.TryParse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString(), out int index);
                        borrowerClass.deleteDataInDatabase(connectionString, index);
                        updateDataGridBorrower();
                        MessageBox.Show("Xóa hàng thành công");
                    }
                }
            }
        }

        private void gridBookBorrowPrice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.RowIndex >= 0 && senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                // Button change book's information
                if (e.ColumnIndex == 3)
                {
                    newBookType newBookType = new newBookType();
                    newBookType.update = true;

                    newBookType.contentsID = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[0].Value);
                    newBookType.name = senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
                    newBookType.prices = senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString();

                    newBookType.ShowDialog();
                    updateDataGridBookBorrowPrice();
                }
                // Button delete books
                else if (e.ColumnIndex == 4)
                {
                    DialogResult dialog = MessageBox.Show("Nếu Chị ấn OK thì hàng này sẽ bị xóa vĩnh viễn. Muốn quay lại hãy ấn Cancel", "Xác nhận xóa hàng", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dialog == DialogResult.OK)
                    {
                        Int32.TryParse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString(), out int index);
                        bookBorrowPriceClass.deleteDataInDatabase(connectionString, index);
                        updateDataGridBookBorrowPrice();
                        MessageBox.Show("Xóa hàng thành công");
                    }
                }
            }
        }

        private void borrowerTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(borrowerTabControl.SelectedIndex == 0)
            {
                updateDataGridBorrowBook();
            }
            if (borrowerTabControl.SelectedIndex == 1)
            {
                updateDataGridBorrower();
            }
            if (borrowerTabControl.SelectedIndex == 2)
            {
                updateDataGridBooks();
            }
            if (borrowerTabControl.SelectedIndex == 3)
            {
                updateDataGridBookBorrowPrice();
            }
        }
    }
}
