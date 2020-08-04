using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksManager
{
    class borrowBookClass
    {
        private int borrowID { get; set; }

        private int userID { get; set; }

        public string userName { get; set; }

        public string phone { get; set; }

        private int bookID { get; set; }

        public string bookName { get; set; }

        private string contentsID { get; set; }

        public DateTime timeBorrow { get; set; }

        public DateTime timeReturn { get; set; }

        public int money { get; set; }

        public string note { get; set; }

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
            cmd.CommandText = "";
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
                    borrowBookClass.timeBorrow = Convert.ToDateTime(dataReader["timeborrow"]);
                    borrowBookClass.timeReturn = Convert.ToDateTime(dataReader["timeReturn"]);
                    borrowBookClass.note = dataReader["note"].ToString();
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
                            if(bookBorrowPriceClass.contentsID == booksClass.contentsID)
                            {
                                Int32.TryParse(((borrowBookClass.timeBorrow - borrowBookClass.timeReturn).TotalDays).ToString(), out int day);
                                borrowBookClass.money = day * bookBorrowPriceClass.prices;
                            }
                        }
                        break;
                    }
                }
            }
        }
    
        public List<borrowBookClass> findData(List<borrowBookClass> borrowBookClasses, string name, string phone)
        {
            List<borrowBookClass> borrowBookClassesReturn = new List<borrowBookClass>();
            foreach (borrowBookClass borrowBookClass in borrowBookClasses)
            {
                if(borrowBookClass.userName==name||borrowBookClass.phone == phone)
                {
                    borrowBookClassesReturn.Add(borrowBookClass);
                }
            }
            return borrowBookClassesReturn;
        }
    }
}
