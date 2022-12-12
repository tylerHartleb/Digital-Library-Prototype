using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
        public string location { get; private set; }


        private string _password;

        private ObservableCollection<CheckedBook> _books = new ObservableCollection<CheckedBook>();
        private ObservableCollection<HeldBook> _heldBooks = new ObservableCollection<HeldBook>();

        // Event Handlers

        private void CollectionChangedMethod(object sender, NotifyCollectionChangedEventArgs e)
        {
            
        }

        public User(string userName, string prefLoc, long userId, string pword) { 
            name = userName;
            id = userId;
            location = prefLoc;
            _password = pword;
        }

        public bool PasswordMatch(string password)
        {
            return _password.Equals(password);
        }

        public ObservableCollection<CheckedBook> GetCheckedOutBooks()
        {
            return _books;
        }

        public ObservableCollection<HeldBook> GetHeldBooks()
        {
            return _heldBooks;
        }
    }
}
