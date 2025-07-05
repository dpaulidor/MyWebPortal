using System;
using System.Collections.Generic;
using System.Data;


namespace GererSystemeBiliotheque.Services
{
    public class BorrowRecord
    {
        public int RecordId { get; set; }
        public int BookId { get; set; }
        public string Title { get; set; }
        public string BorrowerName { get; set; }
        public DateTime BorrowDate { get; set; }
    }


    public static class BorrowService
    {
        public static bool BorrowBook(int bookId, string borrowerName)
        {
            string checkQuery = $"SELECT quantity FROM books WHERE bookId = {bookId}";
            int quantity = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery));


            if (quantity < 1) return false;


            string borrowQuery = $"INSERT INTO borrow_records (bookId, borrowerName, borrowDate) VALUES ({bookId}, '{borrowerName}', CURDATE())";
            string updateQuery = $"UPDATE books SET quantity = quantity - 1 WHERE bookId = {bookId}";


            try
            {
                DatabaseHelper.ExecuteNonQuery(borrowQuery);
                DatabaseHelper.ExecuteNonQuery(updateQuery);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static List<BorrowRecord> GetActiveBorrows()
        {
            var records = new List<BorrowRecord>();
            string query = "SELECT r.recordId, r.bookId, b.title, r.borrowerName, r.borrowDate " +
                           "FROM borrow_records r JOIN books b ON r.bookId = b.bookId " +
                           "WHERE r.returnDate IS NULL";


            DataTable dt = DatabaseHelper.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                records.Add(new BorrowRecord()
                {
                    RecordId = Convert.ToInt32(row["recordId"]),
                    BookId = Convert.ToInt32(row["bookId"]),
                    Title = row["title"].ToString(),
                    BorrowerName = row["borrowerName"].ToString(),
                    BorrowDate = Convert.ToDateTime(row["borrowDate"])
                });
            }
            return records;
        }


        public static bool ReturnBook(int recordId, int bookId)
        {
            string returnQuery = $"UPDATE borrow_records SET returnDate = CURDATE() WHERE recordId = {recordId}";
            string updateQuery = $"UPDATE books SET quantity = quantity + 1 WHERE bookId = {bookId}";


            try
            {
                DatabaseHelper.ExecuteNonQuery(returnQuery);
                DatabaseHelper.ExecuteNonQuery(updateQuery);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
