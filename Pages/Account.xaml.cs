using CPSC_481_Digital_Library_Prototype.Classes;
using CPSC_481_Digital_Library_Prototype.Components;
using CPSC_481_Digital_Library_Prototype.Interfaces;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CPSC_481_Digital_Library_Prototype.Pages
{
 
    public partial class Account : UserControl, IPage
    {
        public Account()
        {
            InitializeComponent();
            Users instance = Users.Instance;
            instance.LoginChange += AccountState_PropertyChanged;

            SetAccountDetails();
            SetAccountInfo();
        }

        private void SetAccountDetails()
        {
            Users instance = Users.Instance;

            User user;
            if (instance.UserDataBase.TryGetValue(instance.signedInUser, out user))
            {
                AccountName.Content = user.name;
                AccountCard.Content = "Library Card: " + user.id;
                AccountPrefLib.Content = "Preferred Location: " + user.location + " Library";

                user.GetCheckedOutBooks().CollectionChanged += Account_CollectionChanged;
                user.GetHeldBooks().CollectionChanged += Account_CollectionChanged;

                // Check if overdue
                bool hasCheck = user.GetCheckedOutBooks().Count > 0;
                if (hasCheck)
                {
                    double fees = 0;
                    foreach(CheckedBook book in user.GetCheckedOutBooks())
                    {
                        if (book.IsOverDue())
                        {
                            fees += book.GetFees();
                        }
                    } 
                    if (fees > 0)
                    {
                        Fees.Visibility = Visibility.Visible;
                        FeesText.Content = "Fees ($" + fees + ")";
                    }
                }
            }
        }

        private void Account_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            SetAccountInfo();
        }

        private void SetAccountInfo()
        {
            Users instance = Users.Instance;

            User user;
            if (instance.UserDataBase.TryGetValue(instance.signedInUser, out user))
            {
                
                bool hasCheck = user.GetCheckedOutBooks().Count > 0;
                bool hasHeld = user.GetHeldBooks().Count > 0;
                if (hasHeld || hasCheck) AccountContent.Visibility = Visibility.Visible;

                if (hasCheck)
                {
                    CheckText.Content = "Checked Out (" + user.GetCheckedOutBooks().Count + ")";
                    CheckedOut.Visibility = Visibility.Visible;
                } else
                {
                    CheckedOut.Visibility = Visibility.Collapsed;
                }

                if (hasHeld)
                {
                    HeldText.Content = "Held Items (" + user.GetHeldBooks().Count + ")";
                    Held.Visibility = Visibility.Visible;
                } else
                {
                    Held.Visibility = Visibility.Collapsed;
                }

                if (hasHeld && hasCheck) HeldSep.Visibility = Visibility.Visible;
            }
        }

        void AccountState_PropertyChanged(object sender, EventArgs e)
        {
            SetAccountDetails();
            SetAccountInfo();
        }

        private void SignOut_Button_Click(object sender, MouseButtonEventArgs e)
        {
            Users instance = Users.Instance;
            instance.signedInUser = 0;
            instance.IsLoggedIn = false;
        }

        private void Fees_Click(object sender, RoutedEventArgs e)
        {
            Content = new Fees();
        }

        private void CheckedOut_Click(object sender, RoutedEventArgs e)
        {
            Users instance = Users.Instance;

            User user;
            if (instance.UserDataBase.TryGetValue(instance.signedInUser, out user))
            {
                AccountName.Content = user.name;
                AccountCard.Content = "Library Card: " + user.id;
                AccountPrefLib.Content = "Preferred Location: " + user.location + " Library";

                AccountInfo.Visibility = Visibility.Collapsed;
                MoreInfo checkedItems = new MoreInfo(user.GetCheckedOutBooks().ToArray(), "Account", "Checked Out Books", this, "AccountPage", "Books");
                AccountPage.Children.Add(checkedItems);
            }
        }

        private void Held_Click(object sender, RoutedEventArgs e)
        {
            Users instance = Users.Instance;

            User user;
            if (instance.UserDataBase.TryGetValue(instance.signedInUser, out user))
            {
                AccountName.Content = user.name;
                AccountCard.Content = "Library Card: " + user.id;
                AccountPrefLib.Content = "Preferred Location: " + user.location + " Library";

                AccountInfo.Visibility = Visibility.Collapsed;
                MoreInfo heldItems = new MoreInfo(user.GetHeldBooks().ToArray(), "Account", "Books on Hold", this, "AccountPage", "Books");
                AccountPage.Children.Add(heldItems);
            }
        }

        public void ReDrawContent()
        {
            AccountInfo.Visibility = Visibility.Visible;
        }
    }
}
