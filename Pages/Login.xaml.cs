using CPSC_481_Digital_Library_Prototype.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CPSC_481_Digital_Library_Prototype.Pages
{
 
    public partial class Login : UserControl
    {
        public Login()
        {
            InitializeComponent();
        }

        private void UserInput_MouseDown(object sender, MouseEventArgs e)
        {
            UsernameWarning.Text = "";
            UserNamePlaceHolder.Visibility = Visibility.Collapsed;
        }

        private void UserInput_LostFocus(Object sender, RoutedEventArgs e)
        {
            if (UsernameTextBox.Text == "")
            {
                UserNamePlaceHolder.Visibility = Visibility.Visible;
            } else if (UsernameTextBox.Text.Length != 14)
            {
                UsernameWarning.Text = "A Library card should be 14 digits long!";
            }
        }

        private void UserInput_PreviewTextChanged(Object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void PasswordInput_MouseDown(object sender, MouseEventArgs e)
        {
            PasswordWarning.Text = "";
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            Users instance = Users.Instance;
            string enteredId = UsernameTextBox.Text;
            string enteredPassword = PasswordTextBox.Password;

            if (enteredId != "" && enteredPassword != "")
            {
                long enteredIdFormated = Convert.ToInt64(enteredId);

                User user;
                if (instance.UserDataBase.TryGetValue(enteredIdFormated, out user))
                {
                    if (user.PasswordMatch(enteredPassword))
                    {
                        instance.signedInUser = user.name;
                        instance.IsLoggedIn = true;

                        //TODO go to account page
                    } else
                    {
                        UsernameWarning.Text = "";
                        PasswordWarning.Text = "Incorrect password entered!";
                    }
                } else
                {
                    UsernameWarning.Text = "Library card does not exist!";
                    PasswordWarning.Text = "";
                }
            }
        }
    }
}
