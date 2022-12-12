using CPSC_481_Digital_Library_Prototype.Classes;
using CPSC_481_Digital_Library_Prototype.Interfaces;
using CPSC_481_Digital_Library_Prototype.Pages;
using Microsoft.VisualBasic;
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
        public IBook _book { get; set; }
        //private string _callingPage = "Search";
        private bool _showFormat = true;

        private IPage _callingPage;
        private string _parentPage;

        public BookDetail(IBook book, IPage callingPage, string parentPage, bool showformat = true)
        {
            InitializeComponent();
            _book = book;
            _callingPage = callingPage;
            _showFormat = showformat;
            _parentPage = parentPage;

            // Set values programatically
            SetBookAuthor();
            SetBookCover();
            if (_showFormat && book.GetBookType() == "book") SetBookFormats();
            SetBookRating();
            SetBookTitle();

            SetBookSpecific();

            
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
            Books instance = Books.Instance;
            StackPanel formats = new StackPanel() { Orientation = Orientation.Horizontal, VerticalAlignment = VerticalAlignment.Bottom };
            formats.SetValue(Grid.RowProperty, 1);
            formats.SetValue(Grid.ColumnProperty, 1);
            
            // Add aval formats
            foreach(var entry in instance.GetLibraries().formatAvailability[_book.GetTitle().ToLower()])
            {
                string imagePath = "/icons/" + entry.Key + ".png";
                Format formatEntry = new Format(entry.Value > 0, imagePath);
                formats.Children.Add(formatEntry);
            }

            BookDetails.Children.Add(formats);
        }

        private void SetBookSpecific()
        {
            string type = _book.GetBookType();

            if (type.Equals("heldBook"))
            {
                Bookmark.Visibility = Visibility.Collapsed;
                HeldBook heldBook = _book as HeldBook;
                TextBlock heldUntil = new TextBlock() { HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Margin = new Thickness(0, 0, 4, 0), FontSize = 12, FontWeight = FontWeights.Light };
                heldUntil.Text = "Due date: " + heldBook.holdUntil.ToString("yyyy/MM/dd");
                BookInfos.Children.Add(heldUntil);
                if (!heldBook.location.Equals(""))
                {
                    TextBlock loc = new TextBlock() { HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Margin = new Thickness(0, 0, 4, 0), FontSize = 12, FontWeight = FontWeights.Light };
                    loc.Text = "Library " + heldBook.location;
                    BookInfos.Children.Add(loc);
                }
            } else if (type.Equals("checkOutBook"))
            {
                Bookmark.Visibility = Visibility.Collapsed;
                CheckedBook checkBook = _book as CheckedBook;
                TextBlock dueDate = new TextBlock() { HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Margin = new Thickness(0,0,4,0), FontSize = 12, FontWeight = FontWeights.Light };
                dueDate.Text = "Due date: " + checkBook.due.ToString("yyyy/MM/dd");
                BookInfos.Children.Add(dueDate);
                if (DateTime.Now > checkBook.due)
                {
                    TextBlock overdue = new TextBlock() { HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Margin = new Thickness(0, 0, 4, 0), FontSize = 12, FontWeight = FontWeights.Medium, Foreground = Brushes.Red };
                    overdue.Text = "Overdue";
                    BookInfos.Children.Add(overdue);
                }
                if (!checkBook.location.Equals(""))
                {
                    TextBlock loc = new TextBlock() { HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top, Margin = new Thickness(0, 0, 4, 0), FontSize = 12, FontWeight = FontWeights.Light };
                    loc.Text = "Library " + checkBook.location;
                    BookInfos.Children.Add(loc);
                }
            }
        }
        #endregion

        #region Handlers
        private void BookDetail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StackPanel SearchPage = Utils.FindElementInTree<StackPanel>(BookDetails, _parentPage);

            if (SearchPage != null)
            {
                SearchPage.Children[0].Visibility = Visibility.Collapsed;
                SearchPage.Children[SearchPage.Children.Count - 1].Visibility = Visibility.Collapsed;
                BookInfo bookInfo = new BookInfo(_book, _callingPage, _parentPage);

                // Add event capturing
                MainWindow mainWin = (MainWindow) Application.Current.MainWindow;
                bookInfo.FlowControl += mainWin.Info_FlowControl;
                
                SearchPage.Children.Add(bookInfo);
            }
        }
        #endregion
    }
}
