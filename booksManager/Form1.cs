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
        SqlCeConnection conn = null;
        SqlCeCommand cmd;
        private string connectionString = "Data Source = bookManagerDatabase.sdf; Password = ''";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<bookBorrowPriceClass> bookBorrowPriceClasses = new List<bookBorrowPriceClass>();
            bookBorrowPriceClass bookBorrowPriceClass = new bookBorrowPriceClass();

            List<booksClass> booksClasses = new List<booksClass>();
            booksClass booksClass = new booksClass();

            List<borrowBookClass> borrowBookClasses = new List<borrowBookClass>();
            borrowBookClass borrowBookClass = new borrowBookClass();

            List<borrowerClass> borrowerClasses = new List<borrowerClass>();
            borrowerClass borrowerClass = new borrowerClass();

            bookBorrowPriceClasses = bookBorrowPriceClass.databaseToClass(connectionString);
            booksClasses = booksClass.databaseToClass(connectionString);
            borrowBookClasses = borrowBookClass.databaseToClass(connectionString);
            borrowerClasses = borrowerClass.databaseToClass(connectionString);

            gridBookBorrowPrice.DataSource = bookBorrowPriceClasses;
            gridBooks.DataSource = booksClasses;
            gridBorrower.DataSource = borrowerClasses;

            borrowBookClass.getInforID(ref borrowBookClasses, borrowerClasses, booksClasses, bookBorrowPriceClasses);
            gridBorrowBook.DataSource = borrowBookClasses;
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
                    booksClass.contentsID = Convert.ToInt32(databaseContents["contentsID"]);
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

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
