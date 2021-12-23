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

        private int maxID(string connectString)
        {
            int ID = -1;
            SqlCeConnection connection = new SqlCeConnection(connectString);
            connection.Open();
            SqlCeCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select max(contentsID) as maxID from bookBorrowPrice";

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

        public void classToDatabase(string connectString, string name, int prices)
        {
            int ID = maxID(connectString) + 1;

            SqlCeConnection connection = new SqlCeConnection(connectString);
            connection.Open();
            SqlCeCommand cmd = connection.CreateCommand();
            cmd.CommandText = "insert into bookBorrowPrice (contentsID, name, prices) " +
                "values(\'" + ID.ToString() +
                "\',\'" + name +
                "\',\'" + prices.ToString() +
                "\'); ";
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void updateDataInDatabase(string connectString, int contentsId, string name, string prices)
        {
            SqlCeConnection connection = new SqlCeConnection(connectString);
            connection.Open();
            SqlCeCommand cmd = connection.CreateCommand();
            cmd.CommandText = "update bookBorrowPrice set name = \'" + name +
                                "\', prices = \'" + prices +
                                "\' where contentsID = " + contentsId.ToString();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void deleteDataInDatabase(string connectString, int contentsID)
        {
            SqlCeConnection connection = new SqlCeConnection(connectString);
            connection.Open();
            SqlCeCommand cmd = connection.CreateCommand();
            cmd.CommandText = "delete from bookBorrowPrice where contentsID = " + contentsID.ToString();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
