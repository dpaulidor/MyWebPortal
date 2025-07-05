using System;
using System.Collections.Generic;
using System.Data;


namespace GererSystemeBiliotheque.Services
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedDate { get; set; }
    }


    public static class BookService
    {
        public static List<Book> GetAvailableBooks()
        {
            var books = new List<Book>();
            string query = "SELECT bookId, title, author, quantity FROM books WHERE quantity > 0";
            DataTable dt = DatabaseHelper.ExecuteQuery(query);


            foreach (DataRow row in dt.Rows)
            {
                books.Add(new Book()
                {
                    BookId = Convert.ToInt32(row["bookId"]),
                    Title = row["title"].ToString(),
                    Author = row["author"].ToString(),
                    Quantity = Convert.ToInt32(row["quantity"])
                });
            }
            return books;
        }


        public static bool AddBook(string title, string author, int quantity)
        {
            string query = $"INSERT INTO books (title, author, quantity, addedDate) VALUES ('{title}', '{author}', {quantity}, CURDATE())";
            int result = DatabaseHelper.ExecuteNonQuery(query);
            return result > 0;
        }


        public static bool UpdateBookQuantity(int bookId, int change)
        {
            string query = $"UPDATE books SET quantity = quantity + {change} WHERE bookId = {bookId}";
            int result = DatabaseHelper.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
