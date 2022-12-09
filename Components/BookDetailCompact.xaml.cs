using CPSC_481_Digital_Library_Prototype.Classes;
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

        public BookDetailCompact(Book book)
        {
            InitializeComponent();
            _book = book;

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
    }
}
