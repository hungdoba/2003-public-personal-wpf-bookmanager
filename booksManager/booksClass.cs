using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlServerCe;

namespace booksManager
{
    class booksClass
    {
        public int bookID { get; set; }

        public string name { get; set; }

        public string author { get; set; }

        public string topic { get; set; }

        public int contentsID { get; set; }

        public string note { get; set; }

        public int numberOfBook { get; set; }

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
    }
}
