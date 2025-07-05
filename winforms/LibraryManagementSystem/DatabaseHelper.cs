using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace LibraryManagementSystem
{
    public static class DatabaseHelper
    {
        private static readonly string connectionString =
            "Server=localhost;Port=3306;Database=uelibrary;Uid=root;Pwd=Jesus_123!!;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de connexion: " + ex.Message);
                return false;
            }
        }
    }
}