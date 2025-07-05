using System;
using System.Windows.Forms;
using GererSystemeBiliotheque.Forms;


namespace GererSystemeBiliotheque
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
