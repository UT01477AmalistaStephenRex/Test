using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalManagementSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace BookRentalManagementSystem
    {
        public class BookManager
        {
            private List<Book> books = new List<Book>();

            // Method to add a new bike
            public void CreateBook(Book book)
            {
                if (ValidateBookRentalPrice(book.RentalPrice))
                {
                    books.Add(book);
                    Console.WriteLine("Book added successfully.");
                }
            }

            // Method to list all books
            public void ReadBooks()
            {
                if (books.Count == 0)
                {
                    Console.WriteLine("No Books available.");
                }
                else
                {
                    foreach (var book in books)
                    {
                        Console.WriteLine(book);
                    }
                }
            }

            // Method to update bike details
            public void Updatebook(int id, string title, string author, decimal rentalPrice)
            {
                var book = books.FirstOrDefault(b => b.BookId == id);
                if (book != null && ValidateBookRentalPrice(rentalPrice))
                {
                    book.BookId = id;
                    book.Title = title;
                    book.Author = author;
                    book.RentalPrice = rentalPrice;
                    Console.WriteLine("book updated successfully.");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }

            // Method to delete a bike
            public void DeleteBook(int id)
            {
                var book = books.FirstOrDefault(b => b.BookId == id);
                if (book != null)
                {
                    books.Remove(book);
                    Console.WriteLine("Book deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Book not found.");
                }
            }

            // Method to validate rental price
            public bool ValidateBookRentalPrice(decimal rentalPrice)
            {
                if (rentalPrice <= 0)
                {
                    Console.WriteLine("Rental price must be positive.");
                    return false;
                }
                return true;
            }



            // Method to validate the rental price of a bike
            public static decimal ValidateBookRentalPrice()
            {
                decimal rentalPrice;

                // Loop until a valid rental price is entered
                while (true)
                {
                    Console.Write("Enter the rental price for the book: ");
                    string input = Console.ReadLine();

                    // Check if the input is a valid decimal number and greater than zero
                    if (decimal.TryParse(input, out rentalPrice) && rentalPrice > 0)
                    {
                        return rentalPrice; // Valid price, return it
                    }
                    else
                    {
                        // Display error message and ask for input again
                        Console.WriteLine("Error: Rental price must be a positive number. Please try again.");
                    }
                }
            }
        }
    }

}

