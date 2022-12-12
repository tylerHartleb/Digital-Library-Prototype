using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using CPSC_481_Digital_Library_Prototype.Classes;

namespace CPSC_481_Digital_Library_Prototype.Pages
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class HoldItems : UserControl
    {
        public HoldItems(HeldBook[] heldBooks)
        {
            InitializeComponent();
        }

        private void AddHeldBooks()
        {

        }


        private void BackButton_MouseDown(object sender, RoutedEventArgs e)
        {
            Content = new Account();
        }
    }
}
