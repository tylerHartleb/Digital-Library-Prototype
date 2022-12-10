using CPSC_481_Digital_Library_Prototype.Classes;
using CPSC_481_Digital_Library_Prototype.Components;
using CPSC_481_Digital_Library_Prototype.Interfaces;
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
    public partial class Search : UserControl, IPage
    {

        Object[] prevChildren = { };
    
        public Search()
        {
            InitializeComponent();
            Name = "Search";
            //AddRecs();
            //TestSomething();
        }

        #region Overrides
        public void ReDrawContent()
        {
            Debug.WriteLine("Creating self");
            SearchPage.Children[0].Visibility = Visibility.Visible;
            SearchPage.Children[1].Visibility = Visibility.Visible;
        }
        #endregion

        #region Handlers
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
                    AddResults(bookResults);
                }
            }
        }
        #endregion

        private void AddRecs()
        {
            Rec_Heading.Text = "Reccommended";
            foreach (var entry in Books.Instance.GetBooks())
            {
                Debug.WriteLine(entry.Value.GetTitle());
            }
        }
       
        private void AddResults(Book[] results)
        {
            Rec_Heading.Text = "Results";
            Discover.Visibility = Visibility.Collapsed;

            // Add results to scroll viewer
            SearchPageScrollContent.Children.Clear();
            foreach (Book book in results)
            {
                Grid grid = new Grid() { Margin = new Thickness(0, 8, 0, 8) };
                BookDetail details = new(book, this);
                grid.Children.Add(details);
                SearchPageScrollContent.Children.Add(grid);
                Separator bookSep = new Separator() { Foreground = Brushes.LightGray, Margin = new Thickness(10, 8, 10, 8)  };
                SearchPageScrollContent.Children.Add(bookSep);
            }
            // Remove the last separator
            SearchPageScrollContent.Children.RemoveAt(SearchPageScrollContent.Children.Count - 1);
        }

        private TextBlock CreateTitleBlock(String title)
        {
            return new TextBlock() {
                Text = title,
                Margin = new Thickness(0,0,0,16),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top, 
                FontSize = 24, 
                FontWeight = FontWeights.Bold 
            };
        }

        /**
         * Flattens a Key value pair to a list of books 
        **/
        public static Book[] Flattened(KeyValuePair<string, Book>[] keyValueArray)
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
