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
        private int id;
        private string password;

        public static Dictionary<long, string> UserDataBase = new Dictionary<long, string>() {
            {12345678910111, "password" },
            {10020050060099, "ILoveUoC" },
            {30051478900000, "AlyKnowsYou" }
        };

        public User(int Id, string Password){ 
            this.id = Id;
            this.password = Password;
            UserDataBase[this.id] = (this.password);
        }



        
    }
}
