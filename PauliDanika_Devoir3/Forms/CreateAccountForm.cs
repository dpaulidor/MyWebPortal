using System;
using System.Windows.Forms;
using GererSystemeBiliotheque.Services;


namespace GererSystemeBiliotheque.Forms
{
    public partial class CreateAccountForm : Form
    {
        public CreateAccountForm()
        {
            InitializeComponent();
        }

        public void ResetFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtFirstName.Focus();
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Tous les champs sont obligatoires", "Erreur",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (AuthService.CreateUser(
                txtFirstName.Text,
                txtLastName.Text,
                txtUsername.Text,
                txtPassword.Text))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur déjà utilisé", "Erreur",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
