using System;
using System.Windows.Forms;
using GererSystemeBiliotheque.Services;
using GererSystemeBiliotheque.Forms;


namespace GererSystemeBiliotheque.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        public void ResetFields()
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;


            if (AuthService.Authenticate(username, password))
            {
                this.Hide();
                using (MainForm mainForm = new MainForm())
                {
                    mainForm.ShowDialog();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Identifiants incorrects", "Erreur",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void lnkCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (CreateAccountForm createForm = new CreateAccountForm())
            {
                if (createForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Compte créé avec succès !", "Information",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
