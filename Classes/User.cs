using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CPSC_481_Digital_Library_Prototype.Classes
{
    public class User
    {
        public long id { get; private set; }
        public string name { get; private set; }


        private string _password;

        private List<Book> _books = new List<Book>();
        private List<Book> _heldBooks = new List<Book>();


        public User(string userName, long userId, string pword) { 
            name = userName;
            id = userId;
            _password = pword;
        }

        public bool PasswordMatch(string password)
        {
            return _password.Equals(password);
        } 
    }
}
