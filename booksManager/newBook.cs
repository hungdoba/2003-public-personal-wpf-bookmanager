using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace booksManager
{
    public partial class newBook : Form
    {
        public bool update = false;
        public int bookID;
        public string name;
        public string author;
        public string topic;
        public string contents;
        public string amount;
        public string note;

        List<bookBorrowPriceClass> bookBorrowPriceClasses = new List<bookBorrowPriceClass>();
        bookBorrowPriceClass bookBorrowPriceClass = new bookBorrowPriceClass();
        List<booksClass> booksClasses = new List<booksClass>();
        booksClass booksClass = new booksClass();

        private string connectionString = "Data Source = bookManagerDatabase.sdf; Password = ''";

        public newBook()
        {
            InitializeComponent();
        }

        private void newBook_Load(object sender, EventArgs e)
        {
            if (update == false)
            {
                btnEnter.Visible = true;
                btnUpdate.Visible = false;
            }
            else
            {
                btnEnter.Visible = false;
                btnUpdate.Visible = true;
            }
            cmbSuggest();

            bookBorrowPriceClasses = bookBorrowPriceClass.databaseToClass(connectionString);
            booksClasses = booksClass.databaseToClass(connectionString);
            txtBookName.Text = name;
            txtAuthor.Text = author;
            txtTopic.Text = topic;
            txtNumber.Text = amount;
            txtNote.Text = note;
            foreach(string st in cmbBookType.Items)
            {
                if(st == contents)
                {
                    cmbBookType.Text = st;
                    break;
                }
            }
        }
        private void cmbSuggest()
        {
            cmbBookType.Items.Clear();
            bookBorrowPriceClasses = bookBorrowPriceClass.databaseToClass(connectionString);
            foreach (bookBorrowPriceClass bookBorrowPriceClass in bookBorrowPriceClasses)
            {
                cmbBookType.Items.Add(bookBorrowPriceClass.name);
            }
            cmbBookType.Items.Add("Thể loại mới");
        }

        private void cmbBookType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbBookType.SelectedItem.ToString() == "Thể loại mới")
            {
                // new book type
                newBookType newBookType = new newBookType();
                newBookType.ShowDialog();
                cmbSuggest();
                booksClasses = booksClass.databaseToClass(connectionString);
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (txtBookName.Text.ToString() != "" && cmbBookType.SelectedIndex != -1 && txtTopic.Text.ToString() != "" && txtAuthor.Text.ToString() !="")
            {
                // Check book exist or not
                bool bookExits = false;
                foreach(booksClass books in booksClasses)
                {
                    if(books.name == txtBookName.Text.ToString())
                    {
                        MessageBox.Show("Sách có tên tương tự đã tồn tại");
                        bookExits = true;
                    }
                }
                if(bookExits == false)
                {
                    // insert to database
                    booksClass.classToDatabase(connectionString,txtBookName.Text.ToString(),txtAuthor.Text.ToString(),txtTopic.Text.ToString(), booksClass.getBookIDfromName(booksClasses, txtBookName.Text.ToString()),txtNumber.Text.ToString(),txtNote.Text.ToString());
                    Close();
                    MessageBox.Show("Thêm sách mới thành công");
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("Tên sách hoặc tác giả hoặc chủ đề hoặc thể loại đang bị thiếu");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            booksClass booksClass = new booksClass();
            int contentsID = -1;

            bookBorrowPriceClasses = bookBorrowPriceClass.databaseToClass(connectionString);
            foreach (bookBorrowPriceClass bookBorrowPriceClass in bookBorrowPriceClasses)
            {
                if(bookBorrowPriceClass.name == cmbBookType.Text)
                {
                    contentsID = bookBorrowPriceClass.contentsID;
                }
            }

            if (txtBookName.Text == null || txtAuthor.Text == null || txtTopic.Text == null || cmbBookType.SelectedIndex == -1)
            {
                MessageBox.Show("Chị chưa điền đầy đủ thông tin kìa");
            }
            else
            {
                booksClass.updateDataInDatabase(connectionString, bookID, txtBookName.Text.ToString(), txtAuthor.Text.ToString(), txtTopic.Text.ToString(), contentsID, txtNote.Text.ToString(), txtNumber.Text.ToString());
                MessageBox.Show("Thành công");
                Close();
            }
        }
    }
}
