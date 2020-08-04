namespace booksManager
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ngườiMượnSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.giáMượnSáchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.borrowerTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gridBorrowBook = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gridBorrower = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gridBooks = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.gridBookBorrowPrice = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.borrowerTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBorrowBook)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBorrower)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBooks)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBookBorrowPrice)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.thôngTinToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1155, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // thôngTinToolStripMenuItem
            // 
            this.thôngTinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sáchToolStripMenuItem,
            this.ngườiMượnSáchToolStripMenuItem,
            this.giáMượnSáchToolStripMenuItem});
            this.thôngTinToolStripMenuItem.Name = "thôngTinToolStripMenuItem";
            this.thôngTinToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.thôngTinToolStripMenuItem.Text = "Thông tin";
            // 
            // sáchToolStripMenuItem
            // 
            this.sáchToolStripMenuItem.Name = "sáchToolStripMenuItem";
            this.sáchToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.sáchToolStripMenuItem.Text = "Sách";
            // 
            // ngườiMượnSáchToolStripMenuItem
            // 
            this.ngườiMượnSáchToolStripMenuItem.Name = "ngườiMượnSáchToolStripMenuItem";
            this.ngườiMượnSáchToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.ngườiMượnSáchToolStripMenuItem.Text = "Người mượn sách";
            // 
            // giáMượnSáchToolStripMenuItem
            // 
            this.giáMượnSáchToolStripMenuItem.Name = "giáMượnSáchToolStripMenuItem";
            this.giáMượnSáchToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.giáMượnSáchToolStripMenuItem.Text = "Giá mượn sách";
            // 
            // borrowerTabControl
            // 
            this.borrowerTabControl.Controls.Add(this.tabPage1);
            this.borrowerTabControl.Controls.Add(this.tabPage2);
            this.borrowerTabControl.Controls.Add(this.tabPage3);
            this.borrowerTabControl.Controls.Add(this.tabPage4);
            this.borrowerTabControl.Controls.Add(this.tabPage5);
            this.borrowerTabControl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.borrowerTabControl.Location = new System.Drawing.Point(13, 28);
            this.borrowerTabControl.Name = "borrowerTabControl";
            this.borrowerTabControl.SelectedIndex = 0;
            this.borrowerTabControl.Size = new System.Drawing.Size(1130, 410);
            this.borrowerTabControl.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gridBorrowBook);
            this.tabPage1.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1122, 384);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Danh sách thuê sách";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gridBorrowBook
            // 
            this.gridBorrowBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBorrowBook.Location = new System.Drawing.Point(6, 6);
            this.gridBorrowBook.Name = "gridBorrowBook";
            this.gridBorrowBook.RowTemplate.Height = 21;
            this.gridBorrowBook.Size = new System.Drawing.Size(1110, 372);
            this.gridBorrowBook.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gridBorrower);
            this.tabPage2.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1122, 384);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Người mượn sách";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gridBorrower
            // 
            this.gridBorrower.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBorrower.Location = new System.Drawing.Point(6, 6);
            this.gridBorrower.Name = "gridBorrower";
            this.gridBorrower.RowTemplate.Height = 21;
            this.gridBorrower.Size = new System.Drawing.Size(1110, 372);
            this.gridBorrower.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.gridBooks);
            this.tabPage3.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1122, 384);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Kho sách";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gridBooks
            // 
            this.gridBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBooks.Location = new System.Drawing.Point(6, 6);
            this.gridBooks.Name = "gridBooks";
            this.gridBooks.RowTemplate.Height = 21;
            this.gridBooks.Size = new System.Drawing.Size(1110, 372);
            this.gridBooks.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.gridBookBorrowPrice);
            this.tabPage4.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1122, 384);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Thể loại sách";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // gridBookBorrowPrice
            // 
            this.gridBookBorrowPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBookBorrowPrice.Location = new System.Drawing.Point(3, 3);
            this.gridBookBorrowPrice.Name = "gridBookBorrowPrice";
            this.gridBookBorrowPrice.RowTemplate.Height = 21;
            this.gridBookBorrowPrice.Size = new System.Drawing.Size(1116, 378);
            this.gridBookBorrowPrice.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.LightSlateGray;
            this.tabPage5.Controls.Add(this.button1);
            this.tabPage5.Controls.Add(this.label1);
            this.tabPage5.Controls.Add(this.dataGridView1);
            this.tabPage5.Controls.Add(this.textBox4);
            this.tabPage5.Controls.Add(this.textBox3);
            this.tabPage5.Controls.Add(this.textBox2);
            this.tabPage5.Controls.Add(this.textBox1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1122, 384);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Tìm Kiếm";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(235, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Tìm kiếm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Người mượn";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(353, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(766, 378);
            this.dataGridView1.TabIndex = 4;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(24, 150);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 19);
            this.textBox4.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(24, 116);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 19);
            this.textBox3.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(24, 77);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 19);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(76, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(142, 19);
            this.textBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 678);
            this.Controls.Add(this.borrowerTabControl);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.borrowerTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBorrowBook)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBorrower)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBooks)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBookBorrowPrice)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngTinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sáchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ngườiMượnSáchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem giáMượnSáchToolStripMenuItem;
        private System.Windows.Forms.TabControl borrowerTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView gridBorrowBook;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView gridBorrower;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView gridBooks;
        private System.Windows.Forms.DataGridView gridBookBorrowPrice;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}

