using System;
using System.Windows.Forms;


namespace GererSystemeBiliotheque.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnManageBooks_Click(object sender, EventArgs e)
        {
            using (var form = new BookManagementForm())
            {
                form.ShowDialog();
                form.ResetFields(); // Réinitialiser après fermeture
            }
        }


        private void btnManageBooks_Click(object sender, EventArgs e)
        {
            using (BooksForm booksForm = new BooksForm())
            {
                booksForm.ShowDialog();
            }
        }


        private void btnBorrow_Click(object sender, EventArgs e)
        {
            using (BorrowForm borrowForm = new BorrowForm())
            {
                borrowForm.ShowDialog();
            }
        }


        private void btnReturn_Click(object sender, EventArgs e)
        {
            using (ReturnForm returnForm = new ReturnForm())
            {
                returnForm.ShowDialog();
            }
        }
    }
}
