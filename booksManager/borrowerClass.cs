using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        //public int userIDReturn()
        //{
        //    return userID;
        //}

        public List<borrowerClass> findData (List<borrowerClass> borrowerClasses, string type, string contents)
        {
            if (borrowerClasses != null)
            {
                List<borrowerClass> borrowers = new List<borrowerClass>();
                if (type == "name")
                {
                    foreach (borrowerClass borrowerClass in borrowerClasses)
                    {
                        if (borrowerClass.name == contents)
                        {
                            borrowers.Add(borrowerClass);
                        }
                    }
                    if (borrowers.Count() != 0)
                    {
                        return borrowers;
                    }
                    else
                    {
                        return null;
                    }
                }
                //else if (type == "phone")
                //{
                //    foreach (borrowerClass borrowerClass in borrowerClasses)
                //    {
                //        if (borrowerClass.phone == contents)
                //        {
                //            borrowers.Add(borrowerClass);
                //        }
                //    }
                //    if (borrowers.Count() != 0)
                //    {
                //        return borrowers;
                //    }
                //    else
                //    {
                //        return null;
                //    }
                //}
                else if (type == "address")
                {
                    foreach (borrowerClass borrowerClass in borrowerClasses)
                    {
                        if (borrowerClass.address == contents)
                        {
                            borrowers.Add(borrowerClass);
                        }
                    }
                    if (borrowers.Count() != 0)
                    {
                        return borrowers;
                    }
                    else
                    {
                        return null;
                    }
                }
                else return null;
            }
            else return null;
        }

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

        private int maxID(string connectString)
        {
            int ID = -1;
            SqlCeConnection connection = new SqlCeConnection(connectString);
            connection.Open();
            SqlCeCommand cmd = connection.CreateCommand();
            cmd.CommandText = "select max(userID) as maxID from borrower";

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

        public void classToDatabase(string connectString, string name, string phone, string address, string note)
        {
            int ID = maxID(connectString) + 1;

            SqlCeConnection connection = new SqlCeConnection(connectString);
            connection.Open();
            SqlCeCommand cmd = connection.CreateCommand();
            cmd.CommandText = "insert into borrower (userId, name, address, phone, note) " +
                "values(\'" + ID.ToString() +
                "\',\'" + name +
                "\',\'" + address +
                "\',\'" + phone +
                "\',\'" + note +
                "\'); ";
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void deleteDataInDatabase(string connectString, int userID)
        {
            SqlCeConnection connection = new SqlCeConnection(connectString);
            connection.Open();
            SqlCeCommand cmd = connection.CreateCommand();
            cmd.CommandText = "delete from borrower where userID = " + userID.ToString();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void updateDataInDatabase(string connectString, string name, string phone, string address, string note, int userID)
        {
            SqlCeConnection connection = new SqlCeConnection(connectString);
            connection.Open();
            SqlCeCommand cmd = connection.CreateCommand();
            cmd.CommandText = "update borrower set name = \'" + name+
                                "\', address = \'" + address+
                                "\', phone = \'" + phone+
                                "\', note = \'" + note +
                                "\' where userID = " + userID.ToString();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
