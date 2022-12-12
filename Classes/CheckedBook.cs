using CPSC_481_Digital_Library_Prototype.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC_481_Digital_Library_Prototype.Classes
{
    public class CheckedBook : Book, IBook
    {
        public DateTime due { get; private set; }
        public string format;
        public string location = "";

        public CheckedBook(Book obj, string format, DateTime due) : base(obj)
        {
            this.format = format;
            this.due = due;
        }

        public CheckedBook(Author author, string[] categories, string imagePath, float rating, string format, DateTime due) : base(author, categories, imagePath, rating)
        {
            this.format = format;
            this.due = due;
        }

        new public string GetBookType()
        {
            return "checkOutBook";
        }

        public CheckedBook SetLocation(string loc)
        {
            location = loc;
            return this;
        }

        public bool IsOverDue()
        {
            return DateTime.Now >= due;
        }

        public double GetFees()
        {
            return IsOverDue() ? 3.00 : 0.00;
        }
    }
}
