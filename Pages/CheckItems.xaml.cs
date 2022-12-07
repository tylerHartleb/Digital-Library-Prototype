using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CPSC_481_Digital_Library_Prototype.Pages
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class CheckedItems : UserControl
    {
        public CheckedItems()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Content = new Account();
        }
    }
}
