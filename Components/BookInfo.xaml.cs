using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
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
using CPSC_481_Digital_Library_Prototype.Classes;
using CPSC_481_Digital_Library_Prototype.Interfaces;

namespace CPSC_481_Digital_Library_Prototype.Components
{
    /// <summary>
    /// Interaction logic for BookInfo.xaml
    /// </summary>
    public partial class BookInfo : UserControl, IPage
    {
        public IBook _book { get; private set; }
        public IPage _prevPage { get; private set; }

        private FormatPill[] _formatPills = { };
        private string _selectedFormat = "";
        private string _parentPage;

        public BookInfo(IBook book, IPage prevPage, string parentPage)
        {
            InitializeComponent();
            Name = "Details";
            _book = book;
            _prevPage = prevPage;
            _parentPage = parentPage;

            InitializeBookComponent();

            Users instance = Users.Instance;
            User user;
            if (instance.UserDataBase.TryGetValue(instance.signedInUser, out user))
            {
                user.GetCheckedOutBooks().CollectionChanged += Account_CollectionChanged;
                user.GetHeldBooks().CollectionChanged += Account_CollectionChanged;

                ShouldHideButton();
            }
        }

        private void Account_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            ShouldHideButton();
        }

        public void ReDrawContent()
        {
            StackPanel SearchPage = Utils.FindElementInTree<StackPanel>(BookInfomation, "SearchPage");

            if (SearchPage != null)
            {
                SearchPage.Children[SearchPage.Children.Count - 1].Visibility = Visibility.Visible;
            }
        }

        public void InitializeBookComponent()
        {
            BackButtonText.Text = _prevPage.Name;
            AddMainBook();
            AddFormats();
            AddSynopsis();
            AddNextInSeries();
            AddMoreByThisAuthor();
            AddRelatedBooks();
        }

        #region Set Component Info
        private void AddMainBook()
        {
            BookDetail mainDetail = new BookDetail(_book, this, _parentPage);
            MainBook.Children.Add(mainDetail);
        }

        private void AddFormats()
        {
            Books instance = Books.Instance;
            StackPanel formats = new StackPanel() { Orientation = Orientation.Horizontal, VerticalAlignment = VerticalAlignment.Bottom, HorizontalAlignment = HorizontalAlignment.Center };
            formats.SetValue(Grid.RowProperty, 1);
            formats.SetValue(Grid.ColumnProperty, 1);

            // Add aval formats
            foreach (var entry in instance.GetLibraries().formatAvailability[_book.GetTitle().ToLower()])
            {
                int index = instance.GetLibraries().formatAvailability[_book.GetTitle().ToLower()].ToList().IndexOf(entry);
                bool selected = false;
                if (index == 0)
                {
                    selected = true;
                    _selectedFormat = entry.Key;
                }
                FormatPill formatEntry = new FormatPill(selected, entry.Value, entry.Value > 0, entry.Key);
                _formatPills.Append(formatEntry);
                formatEntry.PreviewMouseDown += Format_MouseDown;
                formatEntry.Margin = new Thickness(8, 0, 8, 0);
                formats.Children.Add(formatEntry);
            }

            Formats.Children.Add(formats);
        }

        private void AddSynopsis()
        {
            Synopsis.Text = _book.GetDescription();
        }

        private void AddNextInSeries()
        {
            var booksInstance = Books.Instance.GetBooks();

            if (_book.GetSeries() != "")
            {
                if (_book.GetNextInSeries() != "")
                {
                    TextBlock nextInSeriesTextBlock = CreateTitleBlock("Next in the Series");
                    Book nextInSeries = booksInstance[_book.GetNextInSeries().ToLower()];
                    BookDetail nextDetails = new BookDetail(nextInSeries, this, _parentPage);// "Details");
                    NextInSeries.Children.Add(nextInSeriesTextBlock);
                    NextInSeries.Children.Add(nextDetails);
                    SeeAllButton seeAll = new SeeAllButton() { HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(0, 0, 8, 0) };
                    seeAll.PreviewMouseDown += SeeAllNext_MouseDown;
                    NextInSeries.Children.Add(seeAll);
                }
            }
        }

        private void AddMoreByThisAuthor()
        {
            var bookAuthor = _book.GetAuthor();
            List<Book> writtenBooks = bookAuthor.GetBooks();
            ScrollViewer scrollViewer = new ScrollViewer() { VerticalScrollBarVisibility = ScrollBarVisibility.Disabled, HorizontalScrollBarVisibility = ScrollBarVisibility.Auto, Width = 393 };
            scrollViewer.PreviewMouseWheel += ScrollViewer_PreviewMouseWheel;
            StackPanel bookPanel = new StackPanel() { Orientation = Orientation.Horizontal };

            if (writtenBooks.Count() != 1)
            {
                TextBlock moreByThisAuthor = CreateTitleBlock("More by this Author");
                MoreByAuthor.Children.Add(moreByThisAuthor);
                foreach (Book writtenBook in writtenBooks)
                {
                    if (writtenBook != _book)
                    {
                        BookDetailCompact bookDetail = new BookDetailCompact(writtenBook, this, _parentPage);
                        bookPanel.Children.Add(bookDetail);
                    }
                }
                scrollViewer.Content = bookPanel;
                MoreByAuthor.Children.Add(scrollViewer);
            }
        }

        private void AddRelatedBooks()
        {
            Books instance = Books.Instance;
            string[] categories = _book.GetCategories();
            List<Book> relatedBooks = new List<Book>() { };
            foreach(string category in categories)
            {
                List<Book> tmp_books;
                if(instance.getBookCategories().TryGetValue(category, out tmp_books))
                {
                    foreach(Book cat_book in tmp_books)
                    {
                        bool inSeries = false;

                        if (!cat_book.GetSeries().Equals(""))
                        {
                            inSeries = cat_book.GetSeries() == _book.GetSeries();
                        }

                        if (!relatedBooks.Contains(cat_book) && !inSeries)
                        {
                            relatedBooks.Add(cat_book);
                        }
                    }
                }
            }

            ScrollViewer scrollViewer = new ScrollViewer() { VerticalScrollBarVisibility = ScrollBarVisibility.Disabled, HorizontalScrollBarVisibility = ScrollBarVisibility.Auto, Width = 393 };
            scrollViewer.PreviewMouseWheel += ScrollViewer_PreviewMouseWheel;
            StackPanel bookPanel = new StackPanel() { Orientation = Orientation.Horizontal };

            if (relatedBooks.Count() != 1)
            {
                TextBlock moreByThisAuthor = CreateTitleBlock("Related Books");
                MoreByAuthor.Children.Add(moreByThisAuthor);
                foreach (Book writtenBook in relatedBooks)
                {
                    if (writtenBook != _book)
                    {
                        BookDetailCompact bookDetail = new BookDetailCompact(writtenBook, this, _parentPage);
                        bookPanel.Children.Add(bookDetail);
                    }
                }
                scrollViewer.Content = bookPanel;
                RelatedBooks.Children.Add(scrollViewer);
            }
        }
        #endregion

        #region Handlers
        private void BackButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StackPanel SearchPage = Utils.FindElementInTree<StackPanel>(BookInfomation, "SearchPage");

            if (SearchPage != null)
            {
                // Remove the last element i.e. this one
                SearchPage.Children.RemoveAt(SearchPage.Children.Count - 1);
                _prevPage.ReDrawContent();
            }
        }

        private void Format_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FormatPill? clickedFormat = sender as FormatPill;

            if (clickedFormat != null)
            {
                // Set all false
                StackPanel? formats = Formats.Children[0] as StackPanel;

                foreach(UIElement format in formats.Children)
                {
                    FormatPill? selFormat = format as FormatPill;
                    selFormat?.SetSelected(false);
                }

                // Set clicked true
                clickedFormat.SetSelected(true);
                _selectedFormat = clickedFormat._format;

                updateGetButtonText(clickedFormat._available, clickedFormat._format);
            }
        }

        private void SeeAllNext_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StackPanel SearchPage = Utils.FindElementInTree<StackPanel>(BookInfomation, _parentPage);

            if (SearchPage != null)
            {
                // Remove the last element i.e. this one
                SearchPage.Children[SearchPage.Children.Count - 1].Visibility = Visibility.Collapsed;
                Books instance = Books.Instance;
                string series = _book.GetSeries().ToLower();
                if (instance.GetBookSeries().ContainsKey(series))
                {
                    MoreInfo moreInfo = new MoreInfo(Books.Instance.GetBookSeries()[series].ToArray(), "Details", _book.GetSeries(), this, _parentPage);
                    SearchPage.Children.Add(moreInfo);
                }
            }
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var mouseWheelEventArgs = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
            mouseWheelEventArgs.RoutedEvent = MouseWheelEvent;
            mouseWheelEventArgs.Source = sender;
            BookInfoContent.RaiseEvent(mouseWheelEventArgs);
        }


        #region Flow Control Handler
        public event EventHandler<FlowControlEventArgs>? FlowControl;

        private void GetBook_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FlowControlEventArgs args = new FlowControlEventArgs();
            args.book = _book.GetTitle().ToLower();
            args.format = _selectedFormat;
            OnFlowControl(args);
        }

        protected virtual void OnFlowControl(FlowControlEventArgs e)
        {
            EventHandler<FlowControlEventArgs> handler = FlowControl;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        #endregion
        #endregion

        #region Helpers
        private void updateGetButtonText(bool available, string format)
        {
            if (available && format != "book")
            {
                GetBook.Content = "Checkout";
            }
            else
            {
                GetBook.Content = "Place Hold";
            }
        }
        #endregion

        private TextBlock CreateTitleBlock(string titleText)
        {
            TextBlock title = new TextBlock();
            title.Text = titleText;
            title.HorizontalAlignment = HorizontalAlignment.Left;
            title.VerticalAlignment = VerticalAlignment.Center;
            title.FontSize = 24;
            title.FontWeight = FontWeights.Bold;
            title.TextAlignment = TextAlignment.Center;
            title.Margin = new Thickness(0, 8, 0, 8);
            return title;
        }

        private void ShouldHideButton()
        {
            Users instance = Users.Instance;

            User user;
            if (instance.UserDataBase.TryGetValue(instance.signedInUser, out user))
            {
                foreach (HeldBook book in user.GetHeldBooks())
                {
                    if ((book.GetTitle() == _book.GetTitle()))
                    {
                        GetBook.Visibility = Visibility.Collapsed;
                    }
                }

                foreach (CheckedBook book in user.GetCheckedOutBooks())
                {
                    if ((book.GetTitle() == _book.GetTitle()))
                    {
                        GetBook.Visibility = Visibility.Collapsed;
                    }
                }
            }
        }
    }
}
