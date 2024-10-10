using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalManagementSystem
{
    public class BookRepository
    {
        private string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=BookRentalManagement;Trusted_Connection=True";

        public void CreateBook(Book book)
        {
            string query = "INSERT INTO Books (Title, Author, RentalPrice) VALUES (@Title, @Author, @RentalPrice)";
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Title", CapitalizeBrand(book.Title));
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@RentalPrice", book.RentalPrice);
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Book Added Succefully");
                }
            }
        }

        public List<Book> ReadBooks()
        {
            List<Book> books = new List<Book>();
            string query = "SELECT * FROM Books";
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            books.Add(new Book(
                                reader.GetInt32(0),
                                reader.GetString(1),
                                reader.GetString(2),
                                reader.GetDecimal(3)
                            ));
                        }
                    }
                }
            }
            return books;
        }

        public void UpdateBook(int bookId, Book book)
        {
            string query = "UPDATE Books SET Title = @Title, Author = @Author, RentalPrice = @RentalPrice WHERE BookId = @BookId";
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookId", bookId);
                    command.Parameters.AddWithValue("@Title", book.Title);
                    command.Parameters.AddWithValue("@Author", book.Author);
                    command.Parameters.AddWithValue("@RentalPrice", book.RentalPrice);
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Book Update Succefully");
                }
            }
        }

        public void DeleteBook(int bookId)
        {
            string query = "DELETE FROM Books WHERE BookId = @BookId";
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@BookId", bookId);
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Book Deleted Succefully");
                }
            }
        }

        public string CapitalizeBrand(string brand)
        {
            // Capitalize the first letter of each word
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(brand.ToLower());
        }
    }
}
