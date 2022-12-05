using CPSC_481_Digital_Library_Prototype.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CPSC_481_Digital_Library_Prototype.Pages
{
 
    public partial class Login : UserControl
    {
        Dictionary<long, string> udb = User.UserDataBase;
        string enteredId = string.Empty;
        string enteredPassword = string.Empty;
        long enteredIdFormated = 0;
        public Login()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            enteredId = UsernameTextBox.Text;
            enteredPassword = PasswordTextBox.Text;
            enteredIdFormated = (long)Convert.ToDouble(enteredPassword);
            if(udb.ContainsKey(enteredIdFormated) == true)
            {
                if(String.Equals(enteredPassword, udb.GetValueOrDefault(enteredIdFormated))){
                    //This is where we'd send them to the next page since the username exists
                    //and the password is correct for said username.
                }
                else
                {
                    //the username exists but the password was wrong.
                }
            }
            else
            {
                //The username/id does not exist.
            }
            Console.WriteLine("Button clicked");
        }
    }
}
