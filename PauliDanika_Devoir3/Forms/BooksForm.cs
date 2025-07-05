using System;
using System.Windows.Forms;
using GererSystemeBiliotheque.Services;


namespace GererSystemeBiliotheque.Forms
{
    public partial class BooksForm : Form
    {
        public BooksForm()
        {
            InitializeComponent();
            LoadBooks();
        }


        private void LoadBooks()
        {
            dgvBooks.DataSource = BookService.GetAvailableBooks();
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void btnAddBook_Click(object sender, EventArgs e)
        {
            using (AddBookForm addForm = new AddBookForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadBooks();
                }
            }
        }
    }
}
