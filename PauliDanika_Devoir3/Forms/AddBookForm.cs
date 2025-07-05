using System;
using System.Windows.Forms;
using GererSystemeBiliotheque.Services;


namespace GererSystemeBiliotheque.Forms
{
    public partial class AddBookForm : Form
    {
        public AddBookForm()
        {
            InitializeComponent();
        }

        public void ResetFields()
        {
            txtTitle.Text = "";
            txtAuthor.Text = "";
            numQuantity.Value = 1;
            txtTitle.Focus();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text) ||
                string.IsNullOrWhiteSpace(txtAuthor.Text) ||
                numQuantity.Value < 1)
            {
                MessageBox.Show("Tous les champs sont obligatoires avec quantité > 0",
                               "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (BookService.AddBook(
                txtTitle.Text,
                txtAuthor.Text,
                (int)numQuantity.Value))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Erreur lors de l'ajout du livre",
                               "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
