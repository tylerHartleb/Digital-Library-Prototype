using CPSC_481_Digital_Library_Prototype.Interfaces;
using CPSC_481_Digital_Library_Prototype.Classes;
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
using CPSC_481_Digital_Library_Prototype.Pages;

namespace CPSC_481_Digital_Library_Prototype.Components
{
    /// <summary>
    /// Interaction logic for MoreInfo.xaml
    /// </summary>
    public partial class MoreInfo : UserControl, IPage
    {
        private IBook[] _books;
        public IPage _prevPage { get; private set; }
        private string _title = "";
        private string _parentPage;

        public MoreInfo(IBook[] books, string name, string pageTitle, IPage prevPage, string parentPage)
        {
            InitializeComponent();
            Name = "Series";
            _title = name;
            _parentPage = parentPage;
            _books = books;
            _prevPage = prevPage;
            BackButtonText.Text = _title;
            Title.Text = pageTitle;
            RenderBooks();
        }

        public void ReDrawContent()
        {
            StackPanel SearchPage = Utils.FindElementInTree<StackPanel>(BooksInfo, "SearchPage");

            if (SearchPage != null)
            {
                SearchPage.Children[SearchPage.Children.Count - 1].Visibility = Visibility.Visible;
            }
        }

        private void RenderBooks()
        {
            PageScrollContent.Children.Clear();
            foreach (Book book in _books)
            {
                Grid grid = new Grid() { Margin = new Thickness(0, 8, 0, 8) };
                BookDetail details = new(book, this, _parentPage);
                grid.Children.Add(details);
                PageScrollContent.Children.Add(grid);
                Separator bookSep = new Separator() { Foreground = Brushes.LightGray, Margin = new Thickness(10, 8, 10, 8) };
                PageScrollContent.Children.Add(bookSep);
            }
            // Remove the last separator
            PageScrollContent.Children.RemoveAt(PageScrollContent.Children.Count - 1);
        }

        #region Handlers
        private void BackButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            StackPanel SearchPage = Utils.FindElementInTree<StackPanel>(BooksInfo, _parentPage);

            if (SearchPage != null)
            {
                // Remove the last element i.e. this one
                SearchPage.Children.RemoveAt(SearchPage.Children.Count - 1);
                _prevPage.ReDrawContent();
            }
        }
        #endregion
    }
}
