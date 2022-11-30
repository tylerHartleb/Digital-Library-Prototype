using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC_481_Digital_Library_Prototype.Classes
{
    public class Books
    {
        private static Books _instance = new Books();

        private Dictionary<string, Book> _books = new Dictionary<string, Book>();

        private Books() {
            CreateBookDict();
        }

        public static Books Instance { get { return _instance; } }

        public Dictionary<string, Book> GetBooks()
        {
            return _books;
        }

        private void CreateBookDict()
        {
            // Add Authors here

            // Rick Riordan
            Author rickRiordan = new Author("Rick Riordan");

            // Add books here

            // Titan's Curse
            Dictionary<string, bool> titanFormats = new Dictionary<string, bool>() {
                { "book", true },
                { "smartphone", true },
                { "headphone", false }
            };
            Book titanCurse = new Book(rickRiordan, new string[1] { "adventure" }, titanFormats, "/Book covers/the-titans-curse.jpg", 4.9f)
                .SetTitle("The Titan's Curse")
                .SetDescription("");
            _books.Add("The Titan's Curse", titanCurse);
        }
    }
}
