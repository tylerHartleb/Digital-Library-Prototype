using CPSC_481_Digital_Library_Prototype.Classes;
using CPSC_481_Digital_Library_Prototype.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CPSC_481_Digital_Library_Prototype.Components
{
    /// <summary>
    /// Interaction logic for BookDetailCompact.xaml
    /// </summary>
    public partial class BookDetailCompact : UserControl
    {
        Book _book;
        private IPage _callingPage;
        private string _parentPage;

        public BookDetailCompact(Book book, IPage callingPage, string parentPage)
        {
            InitializeComponent();
            _book = book;
            _callingPage = callingPage;
            _parentPage = parentPage;

            SetBookAuthor();
            SetBookCover();
            SetBookTitle();
        }

        private void SetBookAuthor()
        {
            Author.Text = _book.GetAuthor().GetName();
        }

        private void SetBookCover()
        {
            string stringPath = _book.GetImagePath();
            Uri imageUri = new Uri(stringPath, UriKind.Relative);
            BitmapImage imageBitmap = new BitmapImage(imageUri);
            BookCover.Source = imageBitmap;
        }

        private void SetBookTitle()
        {
            Title.Text = _book.GetTitle();
        }

        #region Handlers
        private void BookDetail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StackPanel SearchPage = Utils.FindElementInTree<StackPanel>(CompactDetails, "SearchPage");

            if (SearchPage != null)
            {
                SearchPage.Children[0].Visibility = Visibility.Collapsed;
                SearchPage.Children[SearchPage.Children.Count - 1].Visibility = Visibility.Collapsed;
                BookInfo bookInfo = new BookInfo(_book, _callingPage, _parentPage);
                SearchPage.Children.Add(bookInfo);
            }
        }
        #endregion
    }
}
