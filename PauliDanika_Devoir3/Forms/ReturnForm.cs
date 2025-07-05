using System;
using System.Windows.Forms;
using GererSystemeBiliotheque.Services;


namespace GererSystemeBiliotheque.Forms
{
    public partial class ReturnForm : Form
    {
        public ReturnForm()
        {
            InitializeComponent();
            LoadActiveBorrows();
        }


        private void LoadActiveBorrows()
        {
            dgvBorrows.DataSource = BorrowService.GetActiveBorrows();
            dgvBorrows.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Masquer les colonnes d'ID si nécessaire
            if (dgvBorrows.Columns.Contains("RecordId"))
                dgvBorrows.Columns["RecordId"].Visible = false;

            if (dgvBorrows.Columns.Contains("BookId"))
                dgvBorrows.Columns["BookId"].Visible = false;
        }


        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dgvBorrows.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un emprunt", "Erreur",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            DataGridViewRow selectedRow = dgvBorrows.SelectedRows[0];
            int recordId = Convert.ToInt32(selectedRow.Cells["RecordId"].Value);
            int bookId = Convert.ToInt32(selectedRow.Cells["BookId"].Value);


            if (BorrowService.ReturnBook(recordId, bookId))
            {
                MessageBox.Show("Retour enregistré avec succès", "Succès",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadActiveBorrows(); // Rafraîchir la liste
            }
            else
            {
                MessageBox.Show("Erreur lors du retour", "Erreur",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
