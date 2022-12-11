using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace CPSC_481_Digital_Library_Prototype.Classes
{
    public class Users
    {
        public static Users Instance = new Users();
        public Dictionary<long, User> UserDataBase { get; private set; } = new Dictionary<long, User>();

        public event EventHandler LoginChange;

        private bool _isLoggedIn = false;
        public bool IsLoggedIn
        {
            get { return _isLoggedIn; }
            set
            {
                // Exit if online value isn't changed
                if (_isLoggedIn == value) return;

                _isLoggedIn = value;

                // Raise additional event only if there are any subscribers
                if (LoginChange != null)
                    LoginChange(this, null);
            }
        }
        public string signedInUser = "";

        private Users()
        {
            CreateUserDict();
            // TODO: Add held / checkout items
        }

        private void CreateUserDict()
        {
            User JohnDoe = new User("John Doe", 12345678910111, "password");
            User JaneDoe = new User("Jane Doe", 10020050060099, "ILoveUoC");
            User PeterJohnson = new User("Peter Johnson", 30051478900000, "password1");
            User AliceBlue = new User("Alice Blue", 00000000000000, "password");

            UserDataBase.Add(12345678910111, JohnDoe);
            UserDataBase.Add(10020050060099, JaneDoe);
            UserDataBase.Add(30051478900000, PeterJohnson);
            UserDataBase.Add(00000000000000, AliceBlue);
        }
    }
}
