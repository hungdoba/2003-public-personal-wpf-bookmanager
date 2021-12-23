using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace booksManager
{
    public partial class newBorrowForm : Form
    {
        private string connectionString = "Data Source = bookManagerDatabase.sdf; Password = ''";
        List<borrowBookClass> borrowBookClasses = new List<borrowBookClass>();
        List<bookBorrowPriceClass> bookBorrowPriceClasses = new List<bookBorrowPriceClass>();
        List<booksClass> booksClasses = new List<booksClass>();
        List<borrowerClass> borrowerClasses = new List<borrowerClass>();
        borrowerClass borrowerClass = new borrowerClass();
        booksClass booksClass = new booksClass();
        bookBorrowPriceClass bookBorrowPriceClass = new bookBorrowPriceClass();

        public newBorrowForm()
        {
            InitializeComponent();
        }

        private void newBorrowForm_Load(object sender, EventArgs e)
        {
            
            borrowerClasses = borrowerClass.databaseToClass(connectionString);
            gridSuggest.DataSource = borrowerClasses;

            booksClasses = booksClass.databaseToClass(connectionString);
            bookBorrowPriceClasses = bookBorrowPriceClass.databaseToClass(connectionString);

            txtUserName.AutoCompleteSource = AutoCompleteSource.AllSystemSources;
            txtUserName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtUserName.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txtPhoneNumber.AutoCompleteSource = AutoCompleteSource.AllSystemSources;
            txtPhoneNumber.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtPhoneNumber.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txtAddress.AutoCompleteSource = AutoCompleteSource.AllSystemSources;
            txtAddress.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtAddress.AutoCompleteSource = AutoCompleteSource.CustomSource;

            txtBookName.AutoCompleteSource = AutoCompleteSource.AllSystemSources;
            txtBookName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtBookName.AutoCompleteSource = AutoCompleteSource.CustomSource;

            //cmbSuggest();
            TxtSuggest();
        }

        //private void cmbSuggest()
        //{
        //    cmbBookType.Items.Clear();
        //    bookBorrowPriceClasses = bookBorrowPriceClass.databaseToClass(connectionString);
        //    foreach (bookBorrowPriceClass bookBorrowPriceClass in bookBorrowPriceClasses)
        //    {
        //        cmbBookType.Items.Add(bookBorrowPriceClass.name);
        //    }
        //    cmbBookType.Items.Add("Thể loại mới");
        //}

        private void TxtSuggest()
        {
            booksClasses = booksClass.databaseToClass(connectionString);
            borrowerClasses = borrowerClass.databaseToClass(connectionString);
            bookBorrowPriceClasses = bookBorrowPriceClass.databaseToClass(connectionString);
            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            AutoCompleteStringCollection data1 = new AutoCompleteStringCollection();
            AutoCompleteStringCollection data2 = new AutoCompleteStringCollection();
            AutoCompleteStringCollection data3 = new AutoCompleteStringCollection();

            foreach (borrowerClass borrowerClass in borrowerClasses)
            {
                data.Add(borrowerClass.name.ToString());
                data1.Add(borrowerClass.phone.ToString());
                data2.Add(borrowerClass.address.ToString());
            }
            txtUserName.AutoCompleteCustomSource = data;
            txtPhoneNumber.AutoCompleteCustomSource = data1;
            txtAddress.AutoCompleteCustomSource = data2;

            foreach (booksClass booksClass in booksClasses)
            {
                data3.Add(booksClass.name.ToString());
            }
            txtBookName.AutoCompleteCustomSource = data3;
        }

        private void gridSuggest_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex>-1)
            {
                txtUserName.Text = gridSuggest.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtAddress.Text = gridSuggest.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPhoneNumber.Text = gridSuggest.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            borrowerClass borrowerClass = new borrowerClass();
            gridSuggest.DataSource = null;
            gridSuggest.DataSource = borrowerClass.findData(borrowerClasses, "name", txtUserName.Text.ToString()); 
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.ToString() == "" || txtBookName.Text.ToString() == "")
            {
                MessageBox.Show("Chưa điền tên người mượn hoặc tên sách");
            }
            else
            {
                booksClass books = new booksClass();
                borrowBookClass borrowBookClass = new borrowBookClass();
                borrowerClass borrower = new borrowerClass();

                borrowerClasses = borrower.databaseToClass(connectionString);
                booksClasses = books.databaseToClass(connectionString);

                // Check exist people
                bool userExist = false;
                int userID = -1;

                foreach (borrowerClass borrowerClass in borrowerClasses)
                {
                    if (borrowerClass.name == txtUserName.Text.ToString() && borrowerClass.phone == txtPhoneNumber.Text.ToString())
                    {
                        // import infor
                        userID = borrowerClass.userID;
                        userExist = true;
                        break;
                    }
                }
                if (userExist == false)
                {
                    // insert new user
                    newUser newUser = new newUser();
                    newUser.nameUser = txtUserName.Text.ToString();
                    newUser.phone = txtPhoneNumber.Text.ToString();
                    newUser.address = txtAddress.Text.ToString();
                    newUser.ShowDialog();
                    if(newUser.DialogResult == DialogResult.OK)
                    {
                        userExist = true;
                    }
                    TxtSuggest();
                }

                // Book data process
                int bookID = books.getBookIDfromName(booksClasses, txtBookName.Text.ToString());
                bool bookExits = false;

                if (bookID == -1) // Book not exist yet
                {
                    bookID = books.bookHightestID(booksClasses) + 1;
                    // new isert data to book -> new form to insert book
                    newBook newBook = new newBook();
                    newBook.name = txtBookName.Text.ToString();
                    newBook.ShowDialog();
                    if(newBook.DialogResult == DialogResult.OK)
                    {
                        bookExits = true;
                    }
                    TxtSuggest();
                }

                if(userExist == true && bookExits == true)
                {
                    // insert new borrow book
                    borrowBookClass.classToDatabaseBorrow(connectionString, userID, bookID, dateBorrow.Value.ToString("MM-dd-yyyy"), txtNote.Text.ToString());
                    MessageBox.Show("Thêm lượt thuê mới thành công");
                }
                else
                {
                    MessageBox.Show(" Chị phải điền thông tin người mượn và thông tin của sách thì mới có thể tiếp tục");
                }


            }
        }

        //private void cmbBookType_SelectedValueChanged(object sender, EventArgs e)
        //{
        //    if (cmbBookType.SelectedItem.ToString() == "Thể loại mới")
        //    {
        //        // new book type
        //        newBookType newBookType = new newBookType();
        //        newBookType.ShowDialog();
        //        cmbSuggest();
        //    }
        //}
    }
}
