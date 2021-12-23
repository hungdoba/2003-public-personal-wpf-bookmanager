namespace booksManager
{
    partial class returnBookForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridReturnInfor = new System.Windows.Forms.DataGridView();
            this.dateReturn = new System.Windows.Forms.DateTimePicker();
            this.txtMoney = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.txtNumOfDays = new System.Windows.Forms.TextBox();
            this.txtMoneyDay = new System.Windows.Forms.TextBox();
            this.order = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numBookBorrored = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeBorrow = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.borrowBookClassBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridReturnInfor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.borrowBookClassBindingSource)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.gridReturnInfor, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1460, 85);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gridReturnInfor
            // 
            this.gridReturnInfor.AllowUserToAddRows = false;
            this.gridReturnInfor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridReturnInfor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridReturnInfor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridReturnInfor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.order,
            this.name,
            this.phone,
            this.address,
            this.bookName,
            this.numBookBorrored,
            this.timeBorrow,
            this.note});
            this.gridReturnInfor.Location = new System.Drawing.Point(3, 3);
            this.gridReturnInfor.Name = "gridReturnInfor";
            this.gridReturnInfor.RowHeadersVisible = false;
            this.gridReturnInfor.RowTemplate.Height = 21;
            this.gridReturnInfor.Size = new System.Drawing.Size(1454, 79);
            this.gridReturnInfor.TabIndex = 0;
            // 
            // dateReturn
            // 
            this.dateReturn.Location = new System.Drawing.Point(246, 3);
            this.dateReturn.Name = "dateReturn";
            this.dateReturn.Size = new System.Drawing.Size(200, 19);
            this.dateReturn.TabIndex = 1;
            this.dateReturn.ValueChanged += new System.EventHandler(this.dateReturn_ValueChanged);
            // 
            // txtMoney
            // 
            this.txtMoney.Location = new System.Drawing.Point(115, 3);
            this.txtMoney.Name = "txtMoney";
            this.txtMoney.Size = new System.Drawing.Size(200, 19);
            this.txtMoney.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "Thời gian Trả sách";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Số tiền phải trả";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(395, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "(Đồng)";
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(476, 3);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(75, 21);
            this.btnEnter.TabIndex = 6;
            this.btnEnter.Text = "Xác nhận";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // txtNumOfDays
            // 
            this.txtNumOfDays.Location = new System.Drawing.Point(732, 3);
            this.txtNumOfDays.Name = "txtNumOfDays";
            this.txtNumOfDays.Size = new System.Drawing.Size(200, 19);
            this.txtNumOfDays.TabIndex = 7;
            // 
            // txtMoneyDay
            // 
            this.txtMoneyDay.Location = new System.Drawing.Point(1218, 3);
            this.txtMoneyDay.Name = "txtMoneyDay";
            this.txtMoneyDay.Size = new System.Drawing.Size(200, 19);
            this.txtMoneyDay.TabIndex = 8;
            // 
            // order
            // 
            this.order.HeaderText = "Số thứ tự";
            this.order.Name = "order";
            // 
            // name
            // 
            this.name.HeaderText = "Tên";
            this.name.Name = "name";
            // 
            // phone
            // 
            this.phone.HeaderText = "Số điện thoại";
            this.phone.Name = "phone";
            // 
            // address
            // 
            this.address.HeaderText = "Địa chỉ";
            this.address.Name = "address";
            // 
            // bookName
            // 
            this.bookName.HeaderText = "Tên sách";
            this.bookName.Name = "bookName";
            // 
            // numBookBorrored
            // 
            this.numBookBorrored.HeaderText = "Số Lượng";
            this.numBookBorrored.Name = "numBookBorrored";
            // 
            // timeBorrow
            // 
            this.timeBorrow.HeaderText = "Thời gian mượn";
            this.timeBorrow.Name = "timeBorrow";
            // 
            // note
            // 
            this.note.HeaderText = "Ghi chú";
            this.note.Name = "note";
            // 
            // borrowBookClassBindingSource
            // 
            this.borrowBookClassBindingSource.DataSource = typeof(booksManager.borrowBookClass);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(975, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Giá tiền mượn trong 1 ngày";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(489, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "Số ngày đã mượn";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtMoneyDay, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.dateReturn, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtNumOfDays, 3, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 118);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1460, 33);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.52465F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.36662F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.07586F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtMoney, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnEnter, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(12, 182);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(791, 27);
            this.tableLayoutPanel3.TabIndex = 12;
            // 
            // returnBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(1484, 222);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "returnBookForm";
            this.Text = "returnBookForm";
            this.Load += new System.EventHandler(this.returnBookForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridReturnInfor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.borrowBookClassBindingSource)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView gridReturnInfor;
        private System.Windows.Forms.BindingSource borrowBookClassBindingSource;
        private System.Windows.Forms.DateTimePicker dateReturn;
        private System.Windows.Forms.TextBox txtMoney;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.TextBox txtNumOfDays;
        private System.Windows.Forms.TextBox txtMoneyDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn order;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn address;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookName;
        private System.Windows.Forms.DataGridViewTextBoxColumn numBookBorrored;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeBorrow;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
    }
}