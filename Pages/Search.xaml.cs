using CPSC_481_Digital_Library_Prototype.Classes;
using CPSC_481_Digital_Library_Prototype.Components;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CPSC_481_Digital_Library_Prototype.Pages
{
    /// <summary>
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : UserControl
    {
        public Search()
        {
            InitializeComponent();
            AddRecs();
            TestSomething();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddRecs()
        {
            // NOT FINAL THIS IS A TEST
            foreach(var entry in Books.Instance.GetBooks())
            {
                BookDetail bookDetail = new BookDetail(entry.Value);
                Recs.Children.Add(bookDetail);
            }
        }

        private void TestSomething()
        {
            foreach (var entry in Books.Instance.GetBooks())
            {
                BookInfo bookInfo = new BookInfo(entry.Value);
                SearchPage.Children.Clear();
                SearchPage.Children.Add(bookInfo);
            }
        }
    }
}
