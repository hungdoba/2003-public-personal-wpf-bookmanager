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
    public partial class newUser : Form
    {
        borrowerClass borrowerClass = new borrowerClass();
        List<borrowerClass> borrowerClasses = new List<borrowerClass>();
        public int userID = -1;
        public bool update = false;
        public string nameUser;
        public string phone;
        public string address;
        public string notes;
        private string connectionString = "Data Source = bookManagerDatabase.sdf; Password = ''";

        public newUser()
        {
            InitializeComponent();
        }

        private void newUser_Load(object sender, EventArgs e)
        {
            if(update == false)
            {
                btnEnter.Visible = true;
                btnUpdate.Visible = false;
            }
            else
            {
                btnEnter.Visible = false;
                btnUpdate.Visible = true;
            }

            txtName.Text = nameUser;
            txtPhone.Text = phone;
            txtAddress.Text = address;
            updateBorrower();
            txtSugget();
        }

        private void updateBorrower()
        {
            borrowerClasses = borrowerClass.databaseToClass(connectionString);
        }

        private void txtSugget()
        {
            txtAddress.AutoCompleteSource = AutoCompleteSource.AllSystemSources;
            txtAddress.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtAddress.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection data = new AutoCompleteStringCollection();
            foreach (borrowerClass borrower in borrowerClasses)
            {
                data.Add(borrower.address.ToString());
            }
            txtAddress.AutoCompleteCustomSource = data;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            borrowerClass borrower = new borrowerClass();
            if(txtName.Text!=null)
            {
                bool user = false, same = false;
                foreach(borrowerClass borrowerClass in borrowerClasses)
                {
                    if (borrowerClass.name == txtName.Text.ToString())
                    {
                        user = true;
                        if (borrowerClass.phone == txtPhone.Text.ToString())
                        {
                            same = false;
                            MessageBox.Show("Tên người này đã có trong danh sách nên không thể thêm được nữa");
                            this.Close();
                            break;
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Có người trùng tên đã tồn tại trong danh sách,\n " +
                                "Số điện thoại của người đó là: " + borrowerClass.phone.ToString() + "\n" +
                                "Địa chỉ là: " + borrowerClass.address.ToString() +
                                "\nNgười Chị muốn thêm vào có phải người này không?\n" +
                                "Nếu đúng thì nhấn YES, nếu không phải thì nhấn NO, quay lại nhấn Cancel ","Có người trùng tên",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Information);
                            if(result == DialogResult.No)
                            {
                                same = true;
                                //borrower.classToDatabase(connectionString, txtName.Text.ToString(), txtPhone.Text.ToString(), txtAddress.Text.ToString(), txtNotes.Text.ToString());
                                //Close();
                                //MessageBox.Show("Đã thêm người mới");
                            }
                            else if(result == DialogResult.Cancel)
                            {
                            }
                            else if(result == DialogResult.Yes)
                            {
                                this.Close();
                                break;
                            }
                        }
                    }
                }
                if(user==false||(user==true&&same==true))
                {
                    borrower.classToDatabase(connectionString, txtName.Text.ToString(), txtPhone.Text.ToString(), txtAddress.Text.ToString(), txtNotes.Text.ToString());
                    Close();
                    MessageBox.Show("Đã thêm người mới");
                }
            }
            else
            {
                MessageBox.Show("Chị chưa điền tên kìa");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("use id = " + userID.ToString());
            borrowerClass borrower = new borrowerClass();
            if (txtName.Text != null)
            {
                borrower.updateDataInDatabase(connectionString, txtName.Text.ToString(), txtPhone.Text.ToString(), txtAddress.Text.ToString(), txtNotes.Text.ToString(), userID);
                this.DialogResult = DialogResult.OK;
                Close();
                MessageBox.Show("Thành công");
            }
            else
            {
                MessageBox.Show("Chị chưa điền tên kìa");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
