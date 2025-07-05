using System;
using System.Windows.Forms;
using GererSystemeBiliotheque.Services;


namespace GererSystemeBiliotheque.Forms
{
    public partial class BorrowForm : Form
    {
        public BorrowForm()
        {
            InitializeComponent();
            LoadBooks();
        }

        public void ResetFields()
        {
            txtStudent.Text = "";
            cmbBooks.SelectedIndex = -1;
            txtStudent.Focus();
        }

        private void LoadBooks()
        {
            cmbBooks.DataSource = BookService.GetAvailableBooks();
            cmbBooks.DisplayMember = "Title";
            cmbBooks.ValueMember = "BookId";
        }


        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (cmbBooks.SelectedItem == null || string.IsNullOrWhiteSpace(txtStudent.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs", "Erreur",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Book selectedBook = (Book)cmbBooks.SelectedItem;


            if (BorrowService.BorrowBook(selectedBook.BookId, txtStudent.Text))
            {
                MessageBox.Show("Emprunt enregistré avec succès", "Succès",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Erreur lors de l'emprunt ou quantité insuffisante", "Erreur",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
