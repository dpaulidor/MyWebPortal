namespace GererSystemeBiliotheque.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


//       private void InitializeComponent()
{
    // Couleurs de fond
    this.BackColor = Color.FromArgb(240, 245, 249);
    
    // Style des labels
    this.lblUsername.ForeColor = Color.FromArgb(59, 89, 152);
    this.lblUsername.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
    this.lblUsername.BackColor = Color.Transparent;
    
    this.lblPassword.ForeColor = Color.FromArgb(59, 89, 152);
    this.lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
    this.lblPassword.BackColor = Color.Transparent;
    
    // Style des zones de texte
    this.txtUsername.BackColor = Color.White;
    this.txtUsername.BorderStyle = BorderStyle.FixedSingle;
    this.txtUsername.ForeColor = Color.FromArgb(64, 64, 64);
    
    this.txtPassword.BackColor = Color.White;
    this.txtPassword.BorderStyle = BorderStyle.FixedSingle;
    this.txtPassword.ForeColor = Color.FromArgb(64, 64, 64);
    
    // Style des boutons
    this.btnLogin.BackColor = Color.FromArgb(59, 89, 152);
    this.btnLogin.ForeColor = Color.White;
    this.btnLogin.FlatStyle = FlatStyle.Flat;
    this.btnLogin.FlatAppearance.BorderSize = 0;
    this.btnLogin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
    
    this.btnClear.BackColor = Color.FromArgb(120, 140, 180);
    this.btnClear.ForeColor = Color.White;
    this.btnClear.FlatStyle = FlatStyle.Flat;
    this.btnClear.FlatAppearance.BorderSize = 0;
    
    // Ajouter des coins arrondis
    ApplyRoundedCorners();
}

private void ApplyRoundedCorners()
{
    int radius = 10;
    txtUsername.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtUsername.Width, txtUsername.Height, radius, radius));
    txtPassword.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, txtPassword.Width, txtPassword.Height, radius, radius));
    btnLogin.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnLogin.Width, btnLogin.Height, radius, radius));
    btnClear.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnClear.Width, btnClear.Height, radius, radius));
}

[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
private static extern IntPtr CreateRoundRectRgn(
    int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);