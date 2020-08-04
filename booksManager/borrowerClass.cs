using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace booksManager
{
    class borrowerClass
    {
        public int userID { get; set; }

        public string name { get; set; }

        public string address { get; set; }

        public string phone { get; set; }

        public string note { get; set; }
        
        //---------------------------------------

        public List<borrowerClass> databaseToClass(string connectString)
        {
            SqlCeConnection connection = new SqlCeConnection(connectString);
            connection.Open();
            SqlCeCommand cmd = connection.CreateCommand();
            cmd.CommandText = "";
            cmd.CommandText = "SELECT * FROM borrower";

            List<borrowerClass> borrowerClasses = new List<borrowerClass>();
            borrowerClass borrowerClass = new borrowerClass();
            using (SqlCeDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    if (dataReader["userID"].ToString() != "")
                    {
                        borrowerClass.userID = Convert.ToInt32(dataReader["userID"]);
                    }
                    borrowerClass.name = dataReader["name"].ToString();
                    borrowerClass.address = dataReader["address"].ToString();
                    borrowerClass.phone = dataReader["phone"].ToString();
                    borrowerClass.note = dataReader["note"].ToString();
                    borrowerClasses.Add(borrowerClass);
                    borrowerClass = new borrowerClass();
                }
            }
            connection.Close();
            return borrowerClasses;
        }
    }
}
