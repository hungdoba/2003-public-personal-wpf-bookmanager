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
    public partial class returnBookForm : Form
    {
        public string[] inputData = null;
        public int dayMoney = 0, borrowID = -1;
        string connectionString = "Data Source = bookManagerDatabase.sdf; Password = ''";

        public returnBookForm()
        {
            InitializeComponent();
        }

        private void returnBookForm_Load(object sender, EventArgs e)
        {
            if(inputData!=null)
            {
                gridReturnInfor.Rows.Insert(0, inputData);
                int.TryParse(inputData[5].ToString(), out int numberOfBook);
                Int32.TryParse(Math.Round((dateReturn.Value - Convert.ToDateTime(inputData[6])).TotalDays).ToString(),out int day);
                txtMoney.Text = (day * dayMoney * numberOfBook).ToString("###,###,###,###");
                txtNumOfDays.Text = day.ToString();
                txtMoneyDay.Text = dayMoney.ToString();
            } 
        }

        private void dateReturn_ValueChanged(object sender, EventArgs e)
        {
            Int32.TryParse(Math.Round((dateReturn.Value - Convert.ToDateTime(inputData[5])).TotalDays).ToString(), out int day);
            txtMoney.Text = (day * dayMoney).ToString("###,###,###,###");
            txtNumOfDays.Text = day.ToString();
            txtMoneyDay.Text = dayMoney.ToString();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            borrowBookClass borrowBookClass = new borrowBookClass();
            borrowBookClass.classToDatabaseReturn(connectionString, borrowID, dateReturn.Value.ToString("MM/dd/yyyy"),txtMoney.Text.ToString());
            Close();
            MessageBox.Show("Trả sách thành công");
            this.DialogResult = DialogResult.OK;
        }
    }
}
