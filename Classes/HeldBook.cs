using CPSC_481_Digital_Library_Prototype.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CPSC_481_Digital_Library_Prototype.Classes
{
    public class HeldBook : Book, IBook
    {
        public DateTime holdUntil = DateTime.Now;
        public string format;
        public string location = "";

        public HeldBook(Book obj, string format)
         : base(obj)
        {
            this.format = format;
        }

        public HeldBook(Author author, string[] categories, string imagePath, float rating, string format) : base(author, categories, imagePath, rating)
        {
            this.format = format;
        }

        new public string GetBookType()
        {
            return "heldBook";
        }

        public HeldBook SetHoldUntil(DateTime date)
        {
            holdUntil = date;
            return this;
        }

        public HeldBook SetLocation(string loc)
        {
            location = loc;
            return this;
        }
    }
}
