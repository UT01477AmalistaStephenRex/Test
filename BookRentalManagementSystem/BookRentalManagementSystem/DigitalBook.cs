using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalManagementSystem
{
    internal class DigitalBook : Book
    {
        public string FileSize { get; set; }
        public string Format { get; set; }

        public DigitalBook(int bookId, string title, string author, decimal rentalPrice, string fileSize, string format)
            : base(bookId, title, author, rentalPrice)
        {
            FileSize = fileSize;
            Format = format;
        }

        // Override DisplayBikeInfo
        public override string DisplayBookInfo()
        {
            return base.DisplayBookInfo() + $", FileSize: {FileSize}, Format: {Format}";
        }
    }
}
