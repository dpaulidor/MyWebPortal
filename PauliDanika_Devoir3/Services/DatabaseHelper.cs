using MySql.Data.MySqlClient;
using System.Data;


namespace GererSystemeBiliotheque.Services
{
    public class DatabaseHelper
    {
        private static readonly string connectionString = "Server=localhost;Port=3306;Database=uelibrary;Uid=root;Pwd=Jesus_123!!;";


        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }


        public static DataTable ExecuteQuery(string query)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }


        public static int ExecuteNonQuery(string query)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
        }


        public static object ExecuteScalar(string query)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}
