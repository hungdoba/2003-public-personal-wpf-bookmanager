using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Windows.Forms;

namespace booksManager
{
    class booksClass
    {
        public int bookID { get; set; }

        public string name { get; set; }

        public string author { get; set; }

        public string topic { get; set; }

        private int contentsID { get; set; }

        public string contents { get; set; }

        public string note { get; set; }

        public int numberOfBook { get; set; }

        public int numberOfBookInStorage { get; set; }

        public int contentsIDReturn()
        {
            return contentsID;
        }

        public void contentsIDInsert(int contentID)
        {
            contentsID = contentID;
        }

        public void updateNumberOfBookInStorage(ref List<booksClass> booksClasses, List<borrowBookClass> borrowBookClasses)
        {
            foreach(booksClass books in booksClasses)
            {
                int numberOfBookBorrowed = 0;
                foreach(borrowBookClass borrowBook in borrowBookClasses)
                {
                    if (borrowBook.bookIDReturn() == books.bookID && borrowBook.timeReturn.ToString() != "0001/01/01 0:00:00")
                    {
                        numberOfBookBorrowed += borrowBook.numberOfBookBorrowed;
                    }
                }
                books.numberOfBookInStorage = books.numberOfBook - numberOfBookBorrowed;
            }
        }

        public void showBookContents(ref List<booksClass> booksClasses, string connectString)
        {

            foreach(booksClass books in booksClasses)
            {
                SqlCeConnection connection = new SqlCeConnection(connectString);
                connection.Open();
                SqlCeCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select name as name from bookBorrowPrice where contentsID = "+books.contentsID.ToString();

                using (SqlCeDataReader dataReader = cmd.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        if (dataReader["name"].ToString() != "")
                        {
                            books.contents = dataReader["name"].ToString();
                        }
                    }

                }
                connection.Close();
            }
        }

        public int getBookIDfromName(List<booksClass> booksClasses, string name)
        {
            foreach(booksClass books in booksClasses)
            {
                if(books.name == name)
                {
                    return books.bookID;
                }
            }
            return -1;
        }

        public int bookHightestID(List<booksClass> booksClasses)
        {
            int hightestId = 0;
            foreach(booksClass booksClass in booksClasses)
            {
                if(hightestId<booksClass.bookID)
                {
                    hightestId = booksClass.bookID;
                }
            }
            return hightestId;
        }

        public List<booksClass> databaseToClass(string connectString)
        {
            SqlCeConnection connection = new SqlCeConnection(connectString);
            connection.Open();
            SqlCeCommand cmd = connection.CreateCommand();
            cmd.CommandText = "";
            cmd.CommandText = "SELECT * FROM books";

            List<booksClass> booksClasses = new List<booksClass>();
            booksClass booksClass = new booksClass();
            using (SqlCeDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    booksClass.bookID = Convert.ToInt32(dataReader["bookID"]);
                    booksClass.name = dataReader["name"].ToString();
                    booksClass.author = dataReader["author"].ToString();
                    booksClass.topic = dataReader["topic"].ToString();
                    booksClass.contentsID = Convert.ToInt32(dataReader["contentsID"]);
                    booksClass.note = dataReader["note"].ToString();
                    if (dataReader["numberOfBook"].ToString() != "")
                    {
                        booksClass.numberOfBook = Convert.ToInt32(dataReader["numberOfBook"]);
                    }
                    booksClasses.Add(booksClass);
                    booksClass = new booksClass();
                }
            }
            connection.Close();
            return booksClasses;
        }

        private int maxID(string connectString)
        {
            int ID = -1;
            SqlCeConnection connection = new SqlCeConnection(connectString);
            connection.Open();
            SqlCeCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select max(bookID) as maxID from books";

            using (SqlCeDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    if (dataReader["maxID"].ToString() != "")
                    {
                        ID = Convert.ToInt32(dataReader["maxID"]);
                    }
                }

            }
            connection.Close();
            return ID;
        }

        public void classToDatabase(string connectString, string name, string author, string topic, int contentsID, string numberOfBook, string note)
        {
            int ID = maxID(connectString) + 1;

            SqlCeConnection connection = new SqlCeConnection(connectString);
            connection.Open();
            SqlCeCommand cmd = connection.CreateCommand();
            cmd.CommandText = "insert into books (bookID, name, author, topic, contentsID, note, numberOfBook) " +
                "values(\'" + ID.ToString() +
                "\',\'" + name +
                "\',\'" + author +
                "\',\'" + topic +
                "\',\'" + contentsID.ToString() +
                "\',\'" + note +
                "\',\'" + numberOfBook +
                "\'); ";
            MessageBox.Show(cmd.CommandText);
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void updateDataInDatabase(string connectString, int bookID, string name, string author, string topic, int contentsID, string note, string amount)
        {
            SqlCeConnection connection = new SqlCeConnection(connectString);
            connection.Open();
            SqlCeCommand cmd = connection.CreateCommand();
            cmd.CommandText = "update books set name = \'" + name +
                                "\', author = \'" + author +
                                "\', topic = \'" + topic +
                                "\', contentsID = \'" + contentsID.ToString() +
                                "\', note = \'" + note +
                                "\', numberOfBook = \'" + amount +
                                "\' where bookID = " + bookID.ToString();
            //MessageBox.Show(cmd.CommandText);
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
