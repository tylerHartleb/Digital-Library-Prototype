using CPSC_481_Digital_Library_Prototype.Classes;
using CPSC_481_Digital_Library_Prototype.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Xml.Linq;

namespace CPSC_481_Digital_Library_Prototype.Components
{
    /// <summary>
    /// Interaction logic for BookDetail.xaml
    /// </summary>
    public partial class BookDetail : UserControl
    {
        public Book _book { get; set; }
        //private string _callingPage = "Search";
        private bool _showFormat = true;

        private IPage _callingPage; 

        public BookDetail(Book book, IPage callingPage) //string callingPage = "Search", bool showFormat = true)
        {
            InitializeComponent();
            _book = book;
            _callingPage = callingPage;
            //_showFormat = showFormat;

            // Set values programatically
            SetBookAuthor();
            SetBookCover();
            if (_showFormat) SetBookFormats();
            SetBookRating();
            SetBookTitle();
        }

        #region Set component infomation
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

        private void SetBookRating()
        {
            BookRating.Text = _book.GetRating().ToString();
        }

        private void SetBookTitle()
        {
            Title.Text = _book.GetTitle();
        }

        private void SetBookFormats()
        {
            StackPanel formats = new StackPanel() { Orientation = Orientation.Horizontal, VerticalAlignment = VerticalAlignment.Bottom };
            formats.SetValue(Grid.RowProperty, 1);
            formats.SetValue(Grid.ColumnProperty, 1);
            
            // Add aval formats
            foreach(var entry in _book.GetFormatAvailabilities())
            {
                string imagePath = "/icons/" + entry.Key + ".png";
                Format formatEntry = new Format(entry.Value, imagePath);
                formats.Children.Add(formatEntry);
            }

            BookDetails.Children.Add(formats);
        }
        #endregion

        #region Handlers
        private void BookDetail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StackPanel SearchPage = Utils.FindElementInTree<StackPanel>(BookDetails, "SearchPage");

            if (SearchPage != null)
            {
                SearchPage.Children[0].Visibility = Visibility.Collapsed;
                SearchPage.Children[1].Visibility = Visibility.Collapsed;
                SearchPage.Children[SearchPage.Children.Count - 1].Visibility = Visibility.Collapsed;
                BookInfo bookInfo = new BookInfo(_book, _callingPage);
                SearchPage.Children.Add(bookInfo);
            }
        }

        #endregion
    }
}
