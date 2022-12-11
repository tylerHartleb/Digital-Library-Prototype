using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC_481_Digital_Library_Prototype.Classes
{
    public class Author
    {
        private string _name;
        private List<Book> _books;

        public Author(string name)
        {
            _name = name;
            _books = new List<Book>();
        }

        #region Setters
        public Author AddBook(Book book)
        {
            _books.Add(book);
            return this;
        }

        public Author SetBooks(List<Book> books)
        {
            _books = books;
            return this;
        }
        #endregion

        #region Getters
        public List<Book> GetBooks()
        {
            return _books;
        }

        public string GetName()
        {
            return _name;
        }
        #endregion
    }
}
