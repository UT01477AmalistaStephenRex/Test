
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRentalManagementSystem
{
    public class DVDBook: Book
    {
          
        public string DiscWeight { get; set; }
        public string Duration { get; set; }

        public DVDBook(int bookId, string title, string author, decimal rentalPrice, string discWeight, string duration)
            : base(bookId, title, author, rentalPrice)
        {
            DiscWeight = discWeight;
            Duration = duration;
        }

        // Override DisplayBikeInfo
        public override string DisplayBookInfo()
        {
            return base.DisplayBookInfo() + $", DiscWeight: {DiscWeight}, Duration: {Duration}";
        }
    }
}

