using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksManager
{
    class bookBorrowPriceClass
    {
        public int contentsID { get; set; }

        public string name { get; set; }

        public int prices { get; set; }

        public List<bookBorrowPriceClass> databaseToClass(string connectString)
        {
            SqlCeConnection connection = new SqlCeConnection(connectString);
            connection.Open();
            SqlCeCommand cmd = connection.CreateCommand();
            cmd.CommandText = "";
            cmd.CommandText = "SELECT * FROM bookBorrowPrice";

            List<bookBorrowPriceClass> bookBorrowPrices = new List<bookBorrowPriceClass>();
            bookBorrowPriceClass bookBorrowPrice = new bookBorrowPriceClass();
            using (SqlCeDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    if (dataReader["contentsID"].ToString() != "")
                    {
                        bookBorrowPrice.contentsID = Convert.ToInt32(dataReader["contentsID"]);
                    }
                    bookBorrowPrice.name = dataReader["name"].ToString();
                    if (dataReader["prices"].ToString() != "")
                    {
                        bookBorrowPrice.prices = Convert.ToInt32(dataReader["prices"]);
                    }
                    bookBorrowPrices.Add(bookBorrowPrice);
                    bookBorrowPrice = new bookBorrowPriceClass();
                }
            }
            connection.Close();
            return bookBorrowPrices;
        }
    }
}
