namespace GererSystemeBiliotheque.Forms
{
    partial class BorrowForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblBook;
        private System.Windows.Forms.ComboBox cmbBooks;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.TextBox txtStudent;
        private System.Windows.Forms.Button btnBorrow;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            this.lblBook = new System.Windows.Forms.Label();
            this.cmbBooks = new System.Windows.Forms.ComboBox();
            this.lblStudent = new System.Windows.Forms.Label();
            this.txtStudent = new System.Windows.Forms.TextBox();
            this.btnBorrow = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBook
            // 
            this.lblBook.AutoSize = true;
            this.lblBook.Location = new System.Drawing.Point(20, 20);
            this.lblBook.Name = "lblBook";
            this.lblBook.Size = new System.Drawing.Size(34, 13);
            this.lblBook.TabIndex = 0;
            this.lblBook.Text = "Livre:";
            // 
            // cmbBooks
            // 
            this.cmbBooks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBooks.FormattingEnabled = true;
            this.cmbBooks.Location = new System.Drawing.Point(120, 17);
            this.cmbBooks.Name = "cmbBooks";
            this.cmbBooks.Size = new System.Drawing.Size(300, 21);
            this.cmbBooks.TabIndex = 1;
            // 
            // lblStudent
            // 
            this.lblStudent.AutoSize = true;
            this.lblStudent.Location = new System.Drawing.Point(20, 60);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(87, 13);
            this.lblStudent.TabIndex = 2;
            this.lblStudent.Text = "Nom étudiant:";
            // 
            // txtStudent
            // 
            this.txtStudent.Location = new System.Drawing.Point(120, 57);
            this.txtStudent.Name = "txtStudent";
            this.txtStudent.Size = new System.Drawing.Size(300, 20);
            this.txtStudent.TabIndex = 2;
            // 
            // btnBorrow
            // 
            this.btnBorrow.Location = new System.Drawing.Point(170, 100);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new System.Drawing.Size(100, 30);
            this.btnBorrow.TabIndex = 3;
            this.btnBorrow.Text = "Emprunter";
            this.btnBorrow.UseVisualStyleBackColor = true;
            this.btnBorrow.Click += new System.EventHandler(this.btnBorrow_Click);
            // 
            // BorrowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 150);
            this.Controls.Add(this.btnBorrow);
            this.Controls.Add(this.txtStudent);
            this.Controls.Add(this.lblStudent);
            this.Controls.Add(this.cmbBooks);
            this.Controls.Add(this.lblBook);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BorrowForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nouvel Emprunt";
            this.ResumeLayout(false);
            this.PerformLayout();


        }
    }
}
