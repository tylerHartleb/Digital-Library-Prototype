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

namespace CPSC_481_Digital_Library_Prototype.Components
{
    /// <summary>
    /// Interaction logic for BookInfo.xaml
    /// </summary>
    public partial class BookInfo : UserControl
    {
        public Book _book { get; set; }

        public BookInfo(Book book)
        {
            InitializeComponent();
            _book = book;
            InitializeInfo();
        }

        private void InitializeInfo()
        {
            AddMainBook(_book);
            AddFormats(_book);
            AddSynopsis(_book);
            AddNextInSeries(_book);
            AddMoreByThisAuthor(_book);
        }

        private void AddMainBook(Book book)
        {
            BookDetail mainDetail = new BookDetail(book, false);
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
                    Debug.WriteLine("Series: " + book.GetSeries() + " Book: " + book.GetTitle() + " Next: " + book.GetNextInSeries());
                    Book nextInSeries = booksInstance[book.GetNextInSeries().ToLower()];
                    BookDetail nextDetails = new BookDetail(nextInSeries);
                    NextInSeries.Children.Add(nextInSeriesTextBlock);
                    NextInSeries.Children.Add(nextDetails);
                }
                // TODO: Add see all button.
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
