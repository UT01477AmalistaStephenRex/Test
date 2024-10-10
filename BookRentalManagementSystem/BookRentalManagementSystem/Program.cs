
using BookRentalManagementSystem.BookRentalManagementSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
            Console.ReadLine();
        }
       
        public static void Menu()
        {
            var books = new Book(1, "Book", "Author", 2000);
            Console.WriteLine(books.ToString());

            BookManager bookManager = new BookManager();
            BookRepository bookRepository = new BookRepository();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nBook Rental Management System:");
                Console.WriteLine("1. Add a Book");
                Console.WriteLine("2. View All Books");
                Console.WriteLine("3. Update a Book");
                Console.WriteLine("4. Delete a Book");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        // Adding a bike
                        Console.WriteLine("Select the type of Book:");
                        Console.WriteLine("1. Digital Book");
                        Console.WriteLine("2. DVD Book");
                        string bookType = Console.ReadLine();

                        Console.Write("Enter the Book title: ");
                        string title = Console.ReadLine();
                        Console.Write("Enter the Book author: ");
                        string author = Console.ReadLine();
                        decimal rentalPrice = BookManager.ValidateBookRentalPrice();

                        if (bookType == "1") // Electric Bike
                        {
                            Console.Write("Enter the FileSize: ");
                            string fileSize = Console.ReadLine();
                            Console.Write("Enter the Format: ");
                            string format = Console.ReadLine();

                            DigitalBook digitalBook = new DigitalBook(0, title, author, rentalPrice, fileSize, format);
                            bookRepository.CreateBook(digitalBook);
                        }
                        else if (bookType == "2") // Petrol Bike
                        {
                            Console.Write("Enter the DiscWeight: ");
                            string discWeight = Console.ReadLine();
                            Console.Write("Enter the Duration: ");
                            string duration = Console.ReadLine();

                            DVDBook dVDBook = new DVDBook(0, title, author, rentalPrice, discWeight, duration);
                            bookRepository.CreateBook(dVDBook);
                        }
                        else
                        {
                            Console.WriteLine("Invalid book type selected.");
                        }
                        break;

                    case "2":
                        // Viewing all bikes
                        var booksList = bookRepository.ReadBooks();
                        foreach (var book in booksList)
                        {
                            Console.WriteLine(book.DisplayBookInfo());
                        }
                        break;

                    case "3":
                        // Updating a bike
                        Console.Write("Enter the Book ID to update: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.Write("Enter the new book brand: ");
                        string newBrand = Console.ReadLine();
                        Console.Write("Enter the new book model: ");
                        string newModel = Console.ReadLine();
                        decimal newRentalPrice = BookManager.ValidateBookRentalPrice();

                        Console.WriteLine("Select the type of book:");
                        Console.WriteLine("1. Digital Book");
                        Console.WriteLine("2. DVD Book");
                        string updateBookType = Console.ReadLine();

                        if (updateBookType == "1") // Electric Bike
                        {
                            Console.Write("Enter the new FileSize: ");
                            string newFileSize = Console.ReadLine();
                            Console.Write("Enter the new Format: ");
                            string newFormat = Console.ReadLine();

                            DigitalBook updatedDigitalBook = new DigitalBook(updateId, newBrand, newModel, newRentalPrice, newFileSize, newFormat);
                            bookRepository.UpdateBook(updateId, updatedDigitalBook);
                        }
                        else if (updateBookType == "2") // Petrol Bike
                        {
                            Console.Write("Enter the new Disc Weight: ");
                            string newDiscWeight = Console.ReadLine();
                            Console.Write("Enter the new FileSize: ");
                            string newDuration = Console.ReadLine();

                            DVDBook updatedDVDBook = new DVDBook(updateId, newBrand, newModel, newRentalPrice, newDiscWeight, newDuration);
                            bookRepository.UpdateBook(updateId, updatedDVDBook);
                        }
                        else
                        {
                            Console.WriteLine("Invalid book type selected.");
                        }
                        break;

                    case "4":
                        // Deleting a bike
                        Console.Write("Enter the Book ID to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        bookRepository.DeleteBook(deleteId);
                        break;

                    case "5":
                        // Exit the program
                        exit = true;
                        Console.WriteLine("Exiting the Book Rental Management System.");
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
           
                        
