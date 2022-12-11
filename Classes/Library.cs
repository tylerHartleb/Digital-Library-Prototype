using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC_481_Digital_Library_Prototype.Classes
{
    public class Library
    {
        public string Name { get; set; }
        public Dictionary<string, int> allBooks = new Dictionary<string, int>();
        public Dictionary<string, int> onHoldBooks = new Dictionary<string, int>();

        public Library(string name)
        {
            Name = name;
        }

        public Library SetTotalBooks(Dictionary<string, int> books)
        {
            allBooks = books;
            return this;
        }

        public Library SetHeldBooks(Dictionary<string, int> books)
        {
            onHoldBooks = books;
            return this;
        }

        public int AvailableCopies(string book)
        {
            return allBooks.ContainsKey(book) ? allBooks[book] : 0;
        }

        public int HeldCopies(string book)
        {
            return onHoldBooks.ContainsKey(book) ? allBooks[book] : 0;
        }
    }
}
