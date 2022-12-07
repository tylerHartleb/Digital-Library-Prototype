using CPSC_481_Digital_Library_Prototype.Classes;
using CPSC_481_Digital_Library_Prototype.Components;
using System.Diagnostics;
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
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Debug.WriteLine("hello");
            //Debug.WriteLine(SearchInput.Text);

            //If statement to make sure we dont get an error when it first starts it hasnt populated recs yet (Only needed if ur calling some Rec based function)
            if (Recs != null)
            {
                //Check if the search input is empty
                if (SearchInput.Text != "")
                {   //Need to watch for issues where the user potentially erases the text box before it renders?
                    var booksInstance = Books.Instance.GetBooks();
                    //Check if that book exists
                    if (booksInstance.ContainsKey(SearchInput.Text.ToLower()))
                    {
                        Recs.Children.Clear();
                        //Debug.WriteLine("hello");
                        //Display the Book
                        var bookResult = booksInstance[SearchInput.Text.ToLower()];
                        BookDetail bookDetail = new BookDetail(bookResult);
                        Recs.Children.Add(bookDetail);
                        //First category
                        var bookCategory = booksInstance[SearchInput.Text.ToLower()].GetCategories()[0];
                        //And display 2 books from the same category/author. 
                        var bookCategoryInstance = Books.Instance.getBookCategories();
                        //First book in that category
                        int bookIndex = 0;
                        if (bookCategoryInstance[bookCategory][bookIndex] == bookResult) bookIndex++;
                        var firstBook = bookCategoryInstance[bookCategory][bookIndex];
                        bookDetail = new BookDetail(firstBook);
                        Recs.Children.Add(bookDetail);
                        //Second book in that category
                        if (bookCategoryInstance[bookCategory][bookIndex] == bookResult) bookIndex++;
                        var secondBook = bookCategoryInstance[bookCategory][bookIndex + 1];
                        bookDetail = new BookDetail(secondBook);
                        Recs.Children.Add(bookDetail);
                    }


                }

                else
                {
                    Recs.Children.Clear();
                    AddRecs();
                }
            }
        }

        private void AddRecs()
        {

            // NOT FINAL THIS IS A TEST
            foreach(var entry in Books.Instance.GetBooks())
            {
                //var temp = Books.Instance.GetBooks();
                Debug.WriteLine(entry.Value.GetTitle());
            
                BookDetail bookDetail = new BookDetail(entry.Value);
                Recs.Children.Add(bookDetail);
            }
        }
    }
}
