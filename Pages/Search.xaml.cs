using CPSC_481_Digital_Library_Prototype.Classes;
using CPSC_481_Digital_Library_Prototype.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
            //AddRecs();
            //TestSomething();
        }

        private void SearchInput_MouseDown(Object sender, MouseButtonEventArgs e)
        {
            SearchPlaceHolder.Visibility = Visibility.Collapsed;
        }

        private void SearchInput_LostFocus(Object sender, RoutedEventArgs e)
        {
            if (SearchInput.Text == "") SearchPlaceHolder.Visibility = Visibility.Visible;
        }

        private void SearchInput_OnKeyDown(Object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return && SearchInput.Text != "")
            {
                var booksInstance = Books.Instance.GetBooks();
                // Check for a match
                IEnumerable<KeyValuePair<string, Book>> results = booksInstance.Where(kvp => kvp.Key.Contains(SearchInput.Text.ToLower()));
                Book[] bookResults = Flattened(results.Take(6).ToArray());

                if (bookResults.Length > 0)
                {
                    Recs.Children.Clear();
                    Rec_Heading.Text = "Results";
                    Discover.Visibility = Visibility.Collapsed;
                    foreach (Book book in bookResults)
                    {
                        Grid grid = new Grid() { Margin = new Thickness(0,8,0,8) };
                        BookDetail details = new(book);
                        grid.Children.Add(details);
                        Recs.Children.Add(grid);
                    }
                }
            }
        }

        private void TextBox_TextChanged(Object sender, TextChangedEventArgs e)
        {
            //If statement to make sure we dont get an error when it first starts it hasnt populated recs yet (Only needed if ur calling some Rec based function)
            if (Recs != null)
            {
                //Debug.WriteLine("hello");
                //Display the Book
                //var bookResult = booksInstance[SearchInput.Text.ToLower()];
                //BookDetail bookDetail = new BookDetail(bookResult);
                //Recs.Children.Add(bookDetail);
                //First category
                //var bookCategory = booksInstance[SearchInput.Text.ToLower()].GetCategories()[0];
                //And display 2 books from the same category/author. 
                //var bookCategoryInstance = Books.Instance.getBookCategories();
                //First book in that category
                //int bookIndex = 0;
                //if (bookCategoryInstance[bookCategory][bookIndex] == bookResult) bookIndex++;
                //var firstBook = bookCategoryInstance[bookCategory][bookIndex];
                //bookDetail = new BookDetail(firstBook);
                //Recs.Children.Add(bookDetail);
                //Second book in that category
                //if (bookCategoryInstance[bookCategory][bookIndex] == bookResult) bookIndex++;
                //var secondBook = bookCategoryInstance[bookCategory][bookIndex + 1];
                //bookDetail = new BookDetail(secondBook);
                //Recs.Children.Add(bookDetail);
                /*
                else
                {
                    Recs.Children.Clear();
                    AddRecs();
                }
                */
            }
        }

        private void AddRecs()
        {
            Rec_Heading.Text = "Reccommended";
            foreach (var entry in Books.Instance.GetBooks())
            {
                //var temp = Books.Instance.GetBooks();
                Debug.WriteLine(entry.Value.GetTitle());
            
                //BookDetail bookDetail = new BookDetail(entry.Value);
                //Recs.Children.Add(bookDetail);
            }
        }

        //private void TestSomething()
        //{
        //var instance = Books.Instance.GetBooks();
        //Book titan = instance["the titan's curse"];
        //BookInfo bookInfo = new BookInfo(titan);
        //SearchPage.Children.Clear();
        //SearchPage.Children.Add(bookInfo);
        //}

        public Book[] Flattened(KeyValuePair<string, Book>[] keyValueArray)
        {
            Book[] books = new Book[keyValueArray.Length];
            for (int index = 0; index < keyValueArray.Length; index++)
            {
                books[index] = keyValueArray.ElementAt(index).Value;
            }
            return books;
        }
    }
}
