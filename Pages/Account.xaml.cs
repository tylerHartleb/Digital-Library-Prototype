using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CPSC_481_Digital_Library_Prototype.Pages
{
 
    public partial class Account : UserControl
    {
        public Account()
        {
            InitializeComponent();
        }

        private void EmailPassword_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SignOut_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Fees_Click(object sender, RoutedEventArgs e)
        {
            Content = new Fees();
        }

        private void CheckedOut_Click(object sender, RoutedEventArgs e)
        {
            Content = new CheckedItems();
        }

        private void Held_Click(object sender, RoutedEventArgs e)
        {
            Content = new HoldItems();
        }

        private void ViewAccountInfo_Click(object sender, RoutedEventArgs e)
        {
            Content = new EmailPassword();
        }
    }
}
