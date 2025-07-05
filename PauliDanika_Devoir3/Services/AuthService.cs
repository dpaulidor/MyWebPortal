// AuthService.cs
using GererSystemeBiliotheque.Services;
using MySql.Data.MySqlClient;
using System;

namespace GererSystemeBiliotheque.Services
{
    public static class AuthService
    {
        public static bool Authenticate(string username, string password)
        {
            string query = $"SELECT password FROM user WHERE username = '{username}'";
            var hashedPassword = DatabaseHelper.ExecuteScalar(query)?.ToString();

            return hashedPassword != null && BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        public static bool CreateUser(string firstName, string lastName, string username, string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            string query = $"INSERT INTO user (firstName, lastName, username, password) VALUES ('{firstName}', '{lastName}', '{username}', '{hashedPassword}')";

            try
            {
                int result = DatabaseHelper.ExecuteNonQuery(query);
                return result > 0;
            }
            catch (MySqlException)
            {
                return false;
            }
        }
    }
}