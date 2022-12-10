using System;
using System.Collections.Generic;
using System.Configuration;
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
using CPSC_481_Digital_Library_Prototype.Classes;
using CPSC_481_Digital_Library_Prototype.Interfaces;

namespace CPSC_481_Digital_Library_Prototype.Components
{
    /// <summary>
    /// Interaction logic for BookInfo.xaml
    /// </summary>
    public partial class BookInfo : UserControl, IPage
    {
        public Book _book { get; private set; }
        public IPage _prevPage { get; private set; }

        private FormatPill[] _formatPills = { };

        public BookInfo(Book book, IPage prevPage)
        {
            InitializeComponent();
            Name = "Details";
            _book = book;
            _prevPage = prevPage;

            InitializeBookComponent();
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
            AddMainBook(_book);
            AddFormats(_book);
            AddSynopsis(_book);
            AddNextInSeries(_book);
            AddMoreByThisAuthor(_book);
        }

        #region Set Component Info
        private void AddMainBook(Book book)
        {
            BookDetail mainDetail = new BookDetail(book, this);// "Details", false);
            MainBook.Children.Add(mainDetail);
        }

        private void AddFormats(Book book)
        {
            StackPanel formats = new StackPanel() { Orientation = Orientation.Horizontal, VerticalAlignment = VerticalAlignment.Bottom, HorizontalAlignment = HorizontalAlignment.Center };
            formats.SetValue(Grid.RowProperty, 1);
            formats.SetValue(Grid.ColumnProperty, 1);

            // Add aval formats
            foreach (var entry in _book.GetFormatAvailabilities())
            {
                int index = _book.GetFormatAvailabilities().ToList().IndexOf(entry);
                bool selected = false;
                if (index == 0) selected = true;
                FormatPill formatEntry = new FormatPill(selected, 0, entry.Value, entry.Key);
                _formatPills.Append(formatEntry);
                formatEntry.PreviewMouseDown += Format_MouseDown;
                formatEntry.Margin = new Thickness(8, 0, 8, 0);
                formats.Children.Add(formatEntry);
            }

            Formats.Children.Add(formats);
        }

        private void AddSynopsis(Book book)
        {
            Synopsis.Text = book.GetDescription();
        }

        private void AddNextInSeries(Book book)
        {
            var booksInstance = Books.Instance.GetBooks();

            if (book.GetSeries() != "")
            {
                if (book.GetNextInSeries() != "")
                {
                    TextBlock nextInSeriesTextBlock = CreateTitleBlock("Next in the Series");
                    Book nextInSeries = booksInstance[book.GetNextInSeries().ToLower()];
                    BookDetail nextDetails = new BookDetail(nextInSeries, this);// "Details");
                    NextInSeries.Children.Add(nextInSeriesTextBlock);
                    NextInSeries.Children.Add(nextDetails);
                    SeeAllButton seeAll = new SeeAllButton() { HorizontalAlignment = HorizontalAlignment.Right, Margin = new Thickness(0, 0, 8, 0) };
                    seeAll.PreviewMouseDown += SeeAllNext_MouseDown;
                    NextInSeries.Children.Add(seeAll);
                }
            }
        }

        private void AddMoreByThisAuthor(Book book)
        {
            var bookAuthor = book.GetAuthor();
            List<Book> writtenBooks = bookAuthor.GetBooks();
            ScrollViewer scrollViewer = new ScrollViewer() { VerticalScrollBarVisibility = ScrollBarVisibility.Disabled, HorizontalScrollBarVisibility = ScrollBarVisibility.Auto, Width = 393 };
            StackPanel bookPanel = new StackPanel() { Orientation = Orientation.Horizontal };

            if (writtenBooks.Count() != 1)
            {
                TextBlock moreByThisAuthor = CreateTitleBlock("More by this Author");
                MoreByAuthor.Children.Add(moreByThisAuthor);
                foreach (Book writtenBook in writtenBooks)
                {
                    if (writtenBook != book)
                    {
                        BookDetailCompact bookDetail = new BookDetailCompact(writtenBook);
                        bookPanel.Children.Add(bookDetail);
                    }
                }
                scrollViewer.Content = bookPanel;
                MoreByAuthor.Children.Add(scrollViewer);
            }
        }

        private void AddRelatedBooks(Book book)
        {
            var bookAuthor = book.GetAuthor();
            List<Book> writtenBooks = bookAuthor.GetBooks();
            ScrollViewer scrollViewer = new ScrollViewer() { VerticalScrollBarVisibility = ScrollBarVisibility.Disabled, HorizontalScrollBarVisibility = ScrollBarVisibility.Auto, Width = 393 };
            StackPanel bookPanel = new StackPanel() { Orientation = Orientation.Horizontal };

            if (writtenBooks.Count() != 1)
            {
                TextBlock moreByThisAuthor = CreateTitleBlock("More by this Author");
                MoreByAuthor.Children.Add(moreByThisAuthor);
                foreach (Book writtenBook in writtenBooks)
                {
                    if (writtenBook != book)
                    {
                        BookDetailCompact bookDetail = new BookDetailCompact(writtenBook);
                        bookPanel.Children.Add(bookDetail);
                    }
                }
                scrollViewer.Content = bookPanel;
                MoreByAuthor.Children.Add(scrollViewer);
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
            }
        }

        private void SeeAllNext_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StackPanel SearchPage = Utils.FindElementInTree<StackPanel>(BookInfomation, "SearchPage");

            if (SearchPage != null)
            {
                // Remove the last element i.e. this one
                SearchPage.Children[SearchPage.Children.Count - 1].Visibility = Visibility.Collapsed;
                Books instance = Books.Instance;
                string series = _book.GetSeries();
                if (instance.GetBookSeries().ContainsKey(series))
                {
                    MoreInfo moreInfo = new MoreInfo(Books.Instance.GetBookSeries()[series].ToArray(), "Details", this);
                    SearchPage.Children.Add(moreInfo);
                }
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
    }
}
