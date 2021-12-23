using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace booksManager
{
    class borrowBookClass
    {
        public int borrowID { get; set; }

        private int userID { get; set; }

        public string userName { get; set; }

        public string phone { get; set; }

        public string address { get; set; }

        private int bookID { get; set; }

        public string bookName { get; set; }

        private string contentsID { get; set; }

        public DateTime timeBorrow { get; set; }

        public DateTime timeReturn { get; set; }

        public int money { get; set; }

        private int moneyDay { get; set; }

        public int numberOfBookBorrowed { get; set; }

        public string note { get; set; }

        public int moneyDayReturn()
        {
            return moneyDay;
        }

        public int userIDReturn()
        {
            return userID;
        }

        public int bookIDReturn()
        {
            return bookID;
        }

        public string contentIDReturn()
        {
            return contentsID;
        }

        public void getContentID(string contentsIn)
        {
            contentsID = contentsIn;
        }

        public List<borrowBookClass> databaseToClass(string connectString)
        {
            SqlCeConnection connection = new SqlCeConnection(connectString);
            connection.Open();
            SqlCeCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM borrowBook";

            List<borrowBookClass> borrowBookClasses = new List<borrowBookClass>();
            borrowBookClass borrowBookClass = new borrowBookClass();
            using (SqlCeDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    if (dataReader["borrowID"].ToString() != "")
                    {
                        borrowBookClass.borrowID = Convert.ToInt32(dataReader["borrowID"]);
                    }
                    if (dataReader["userID"].ToString() != "")
                    {
                        borrowBookClass.userID = Convert.ToInt32(dataReader["userID"]);
                    }
                    if (dataReader["bookID"].ToString() != "")
                    {
                        borrowBookClass.bookID = Convert.ToInt32(dataReader["bookID"]);
                    }
                    if (dataReader["timeborrow"].ToString() != "")
                    {
                        borrowBookClass.timeBorrow = Convert.ToDateTime(dataReader["timeborrow"]);
                    }
                    if (dataReader["timeReturn"].ToString() != "")
                    {
                        borrowBookClass.timeReturn = Convert.ToDateTime(dataReader["timeReturn"]);
                    }
                    if (dataReader["money"].ToString() != "")
                    {
                        borrowBookClass.money = Convert.ToInt32(dataReader["money"]);
                    }
                    if (dataReader["note"].ToString() != "")
                    {
                        borrowBookClass.note = dataReader["note"].ToString();
                    }
                    if (dataReader["numberOfBookBorrowed"].ToString() != "")
                    {
                        borrowBookClass.numberOfBookBorrowed = Convert.ToInt32(dataReader["numberOfBookBorrowed"]);
                    }
                    borrowBookClasses.Add(borrowBookClass);
                    borrowBookClass = new borrowBookClass();
                }
            }
            connection.Close();
            return borrowBookClasses;
        }

        public  void getInforID(ref List<borrowBookClass> borrowBookClasses, List<borrowerClass> borrowerClasses, List<booksClass> booksClasses, List<bookBorrowPriceClass> bookBorrowPriceClasses)
        {
            foreach(borrowBookClass borrowBookClass in borrowBookClasses)
            {
                foreach(borrowerClass borrowerClass in borrowerClasses)
                {
                    if(borrowBookClass.userIDReturn() == borrowerClass.userID)
                    {
                        borrowBookClass.userName = borrowerClass.name;
                        borrowBookClass.phone = borrowerClass.phone;
                        borrowBookClass.address = borrowerClass.address;
                        break;
                    }
                }
                foreach(booksClass booksClass in booksClasses)
                {
                    if(borrowBookClass.bookIDReturn()==booksClass.bookID)
                    {
                        borrowBookClass.bookName = booksClass.name;
                        foreach(bookBorrowPriceClass bookBorrowPriceClass in bookBorrowPriceClasses)
                        {
                            if(bookBorrowPriceClass.contentsID == booksClass.contentsIDReturn())
                            {
                                if(borrowBookClass.money==0)
                                {
                                    Int32.TryParse(((borrowBookClass.timeReturn - borrowBookClass.timeBorrow).TotalDays).ToString(), out int day);
                                    if (day > 0)
                                    {
                                        borrowBookClass.money = day * bookBorrowPriceClass.prices;
                                    }
                                    else
                                    {
                                        borrowBookClass.money = 0;
                                    }
                                }
                                borrowBookClass.moneyDay = bookBorrowPriceClass.prices;
                            }
                        }
                        break;
                    }
                }
            }
        }
    
        public List<borrowBookClass> findData(List<borrowBookClass> borrowBookClasses, string type, string contents)
        {
            if (borrowBookClasses.Count > 0)
            {
                List<borrowBookClass> borrowBookClassesReturn = new List<borrowBookClass>();
                if (type == "userName")
                {
                    foreach (borrowBookClass borrowBookClass in borrowBookClasses)
                    {
                        if (borrowBookClass.userName!=null && borrowBookClass.userName.Contains(contents))
                        {
                            borrowBookClassesReturn.Add(borrowBookClass);
                        }
                    }
                    if (borrowBookClassesReturn.Count() != 0)
                    {
                        return borrowBookClassesReturn;
                    }
                    else return null;
                }
                else if (type == "phone")
                {
                    foreach (borrowBookClass borrowBookClass in borrowBookClasses)
                    {
                        if (borrowBookClass.phone != null && borrowBookClass.phone.Contains(contents))
                        {
                            borrowBookClassesReturn.Add(borrowBookClass);
                        }
                    }
                    if (borrowBookClassesReturn.Count() != 0)
                    {
                        return borrowBookClassesReturn;
                    }
                    else return null;
                }
                else if (type == "bookName")
                {
                    foreach (borrowBookClass borrowBookClass in borrowBookClasses)
                    {
                        if (borrowBookClass.bookName != null && borrowBookClass.bookName.Contains(contents))
                        {
                            borrowBookClassesReturn.Add(borrowBookClass);
                        }
                    }
                    if (borrowBookClassesReturn.Count() != 0)
                    {
                        return borrowBookClassesReturn;
                    }
                    else return null;
                }
                else if (type == "address")
                {
                    foreach (borrowBookClass borrowBookClass in borrowBookClasses)
                    {
                        if (borrowBookClass.address!=null && borrowBookClass.address.Contains(contents))
                        {
                            borrowBookClassesReturn.Add(borrowBookClass);
                        }
                    }
                    if (borrowBookClassesReturn.Count() != 0)
                    {
                        return borrowBookClassesReturn;
                    }
                    else return null;
                }
                else if (type == "timeBorrow")
                {
                    foreach (borrowBookClass borrowBookClass in borrowBookClasses)
                    {
                        if (borrowBookClass.timeBorrow!=null && borrowBookClass.timeBorrow.ToString("dd/MM/yyyy").Contains(contents))
                        {
                            borrowBookClassesReturn.Add(borrowBookClass);
                            
                        }
                    }
                    if (borrowBookClassesReturn.Count() != 0)
                    {
                        return borrowBookClassesReturn;
                    }
                    else return null;
                }
                else if (type == "timeReturn")
                {
                    foreach (borrowBookClass borrowBookClass in borrowBookClasses)
                    {
                        if (borrowBookClass.timeReturn!=null && borrowBookClass.timeReturn.ToString("dd/MM/yyyy").Contains(contents))
                        {
                            borrowBookClassesReturn.Add(borrowBookClass);
                        }
                    }
                    if (borrowBookClassesReturn.Count() != 0)
                    {
                        return borrowBookClassesReturn;
                    }
                    else return null;
                }
                else return null;
            }
            else return null;
        }

        private int maxID(string connectString)
        {
            int ID = -1;
            SqlCeConnection connection = new SqlCeConnection(connectString);
            connection.Open();
            SqlCeCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select max(borrowID) as maxID from borrowBook";

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

        public void classToDatabaseBorrow(string connectString, int userID, int bookID, string timeBorrow, string note)
        {
            int borrowID = maxID(connectString) + 1;

            SqlCeConnection connection = new SqlCeConnection(connectString);
            connection.Open();
            SqlCeCommand cmd = connection.CreateCommand();
            cmd.CommandText = "insert into borrowBook (borrowID, userId, bookID, timeBorrow, note) " +
                "values(\'" + borrowID.ToString()+
                "\',\'" + userID.ToString() + 
                "\',\'" + bookID.ToString() +
                "\',\'" + timeBorrow +
                "\',\'" + note +
                "\'); ";
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void classToDatabaseReturn(string connectString, int borrowID, string timeReturn, string money)
        {
            SqlCeConnection connection = new SqlCeConnection(connectString);
            connection.Open();
            SqlCeCommand cmd = connection.CreateCommand();
            cmd.CommandText = "update borrowBook set timeReturn = " +
                "\'"+timeReturn+"\', money = \'"+money+"\' where borrowID = "+borrowID.ToString();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void deleteDataInDatabase(string connectString, int borrowID)
        {
            SqlCeConnection connection = new SqlCeConnection(connectString);
            connection.Open();
            SqlCeCommand cmd = connection.CreateCommand();
            cmd.CommandText = "delete from borrowBook where borrowID = " + borrowID.ToString();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
