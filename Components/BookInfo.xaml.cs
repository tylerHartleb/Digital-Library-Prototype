using System;
using System.Collections.Generic;
using System.Configuration;
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
                formatEntry.Margin = new Thickness(8);
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
            TextBlock title = new TextBlock();
            title.Text = "Next in the Series";
            title.HorizontalAlignment = HorizontalAlignment.Left;
            title.VerticalAlignment = VerticalAlignment.Center;
            title.FontSize = 24;
            title.FontWeight = FontWeights.Bold;
            title.TextAlignment = TextAlignment.Center;
            title.Margin = new Thickness(0, 0, 0, 8);
        }
    }
}
