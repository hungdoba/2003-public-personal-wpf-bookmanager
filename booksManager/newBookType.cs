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
    public partial class newBookType : Form
    {
        List<bookBorrowPriceClass> bookBorrowPriceClasses = new List<bookBorrowPriceClass>();
        bookBorrowPriceClass bookBorrowPriceClass = new bookBorrowPriceClass();
        private string connectionString = "Data Source = bookManagerDatabase.sdf; Password = ''";
        public bool update = false;
        public int contentsID;
        public string name;
        public string prices;

        public newBookType()
        {
            InitializeComponent();
        }

        private void newBookType_Load(object sender, EventArgs e)
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
            txtTypeName.Text = name;
            txtPrices.Text = prices;

            bookBorrowPriceClasses = bookBorrowPriceClass.databaseToClass(connectionString);
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            bool typeNameExist = false;
            if(txtTypeName.Text.Length.ToString()!=""&&txtPrices.Text.ToString()!="")
            {
                foreach(bookBorrowPriceClass bookBorrowPrice in bookBorrowPriceClasses)
                {
                    if(txtTypeName.Text.ToString()==bookBorrowPrice.name)
                    {
                        MessageBox.Show("Chủ đề này đã có rồi mà, Chị không cần nhập nữa");
                        typeNameExist = true;
                        break;
                    }
                }
                if(typeNameExist == false)
                {
                    // insert to database
                    try
                    {
                        int price = int.Parse(txtPrices.Text);
                        bookBorrowPriceClass.classToDatabase(connectionString, txtTypeName.Text.ToString(), price);
                        Close();
                        MessageBox.Show("Thêm thể loại sách mới thành công");
                    }
                    catch
                    {
                        MessageBox.Show("Chỉ nhập số vào ô giá");
                    } 
                }
            }
            else
            {
                MessageBox.Show("Chị chưa điền đầy đủ thông tin kìa");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bookBorrowPriceClass bookBorrowPriceClass = new bookBorrowPriceClass();
            if (txtPrices.Text != null && txtTypeName.Text != null)
            {
                bookBorrowPriceClass.updateDataInDatabase(connectionString, contentsID, txtTypeName.Text.ToString(), txtPrices.Text.ToString());
                MessageBox.Show("Thành công");
                Close();
            }
            else
            {
                MessageBox.Show("Chị chưa điền tên kìa");
            }
        }
    }
}
