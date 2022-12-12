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
    
        public Search()
        {
            InitializeComponent();
            Name = "Search";
            RenderReccommended();
        }

        #region Overrides
        public void ReDrawContent()
        {
            SearchPage.Children[0].Visibility = Visibility.Visible;
        }
        #endregion

        #region Handlers

        private void DiscoverHistory_MouseDown(Object sender, MouseButtonEventArgs e)
        {
            SearchInput.Text = "History";
            CancelSearch.Visibility = Visibility.Visible;
            SearchBooks("history");
        }

        private void DiscoverAdventure_MouseDown(Object sender, MouseButtonEventArgs e)
        {
            SearchInput.Text = "Adventure";
            CancelSearch.Visibility = Visibility.Visible;
            SearchBooks("adventure");
        }

        private void DiscoverMystery_MouseDown(Object sender, MouseButtonEventArgs e)
        {
            SearchInput.Text = "Mystery";
            CancelSearch.Visibility = Visibility.Visible;
            SearchBooks("mystery");
        }

        private void SearchInput_MouseDown(Object sender, MouseButtonEventArgs e)
        {
            SearchPlaceHolder.Visibility = Visibility.Collapsed;
            CancelSearch.Visibility = Visibility.Visible;
        }

        private void SearchInput_LostFocus(Object sender, RoutedEventArgs e)
        {
            if (SearchInput.Text == "")
            {
                SearchPlaceHolder.Visibility = Visibility.Visible;
                CancelSearch.Visibility = Visibility.Collapsed;
            }   
        }

        // Handles Search
        private void SearchInput_OnKeyDown(Object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return && SearchInput.Text != "")
            {
                SearchBooks(SearchInput.Text.ToLower());
            }
        }

        private void SearchInput_OnTextChanged(Object sender, EventArgs e)
        {
            if (SearchInput.Text.Equals(""))
            {
                ClearSearchInput.Visibility = Visibility.Collapsed;
            } else
            {
                ClearSearchInput.Visibility = Visibility.Visible;
            }
        }

        private void ClearSearchInput_MouseDown(Object sender, MouseButtonEventArgs e)
        {
            SearchInput.Text = "";
        }

        private void CancelSearch_MouseDown(Object sender, MouseButtonEventArgs e)
        {
            Discover.Visibility = Visibility.Visible;
            CancelSearch.Visibility = Visibility.Collapsed;
            SearchInput.Text = "";
            RenderReccommended();
        }

        private void SearchBooks(string searchString)
        {
            Books instance = Books.Instance; 
            Dictionary<string, int> levenshteinDistances = new Dictionary<string, int>();

            // Search through books
            foreach (string key in instance.GetBooks().Keys)
            {
                int distance = Utils.ComputeLevenshteinDistance(searchString, key);
                levenshteinDistances.TryAdd(key, distance);
            }

            // Search through series
            foreach (string key in instance.GetBookSeries().Keys)
            {
                int distance = Utils.ComputeLevenshteinDistance(searchString, key);
                levenshteinDistances.TryAdd(key, distance);
            }

            // Search through categories
            foreach (string key in instance.getBookCategories().Keys)
            {
                int distance = Utils.ComputeLevenshteinDistance(searchString, key);
                levenshteinDistances.TryAdd(key, distance);
            }

            // Search through authors
            foreach (string key in instance.GetAuthors().Keys)
            {
                int distance = Utils.ComputeLevenshteinDistance(searchString, key);
                levenshteinDistances.TryAdd(key, distance);
            }

            SortedDictionary<string, int> sortedMatches = new SortedDictionary<string, int>(
                Comparer<string>.Create(
                    (x, y) =>
                    {
                        int vx = levenshteinDistances[x];
                        int vy = levenshteinDistances[y];

                        // If values are the same then compare keys.
                        if (vx == vy)
                            return x.CompareTo(y);

                        // Otherwise - compare values.
                        return vx.CompareTo(vy);
                    }));

            foreach (var pair in levenshteinDistances)
            {
                sortedMatches.Add(pair.Key, pair.Value);
            }

            // Get the first 15 matches
            int closestMatch = sortedMatches.First().Value;
            int offset = 5;

            IEnumerable<KeyValuePair<string, int>> closestMatches = sortedMatches.Where(kvp => kvp.Value < closestMatch + offset);
            Book[] results = GetBookResults(closestMatches.ToArray());

            if (results.Length > 0)
            {
                AddResults(results);
            }
        }
        #endregion

        private void RenderReccommended()
        {
            Rec_Heading.Text = "Reccommended";
            SearchPageScrollContent.Children.Clear();
            ResScroller.Height = 410;

            foreach (Book book in Books.Instance.getBookCategories()["fantasy"])
            {
                Grid grid = new Grid() { Margin = new Thickness(0, 8, 0, 8) };
                BookDetail details = new(book, this, "SearchPage");
                grid.Children.Add(details);
                SearchPageScrollContent.Children.Add(grid);
                Separator bookSep = new Separator() { Foreground = Brushes.LightGray, Margin = new Thickness(10, 8, 10, 8) };
                SearchPageScrollContent.Children.Add(bookSep);
            }
            // Remove the last separator
            SearchPageScrollContent.Children.RemoveAt(SearchPageScrollContent.Children.Count - 1);
        }
       
        private void AddResults(Book[] results)
        {
            Rec_Heading.Text = "Results";
            Discover.Visibility = Visibility.Collapsed;
            ResScroller.Height = 500;

            // Add results to scroll viewer
            SearchPageScrollContent.Children.Clear();
            foreach (Book book in results)
            {
                Grid grid = new Grid() { Margin = new Thickness(0, 8, 0, 8) };
                BookDetail details = new(book, this, "SearchPage");
                grid.Children.Add(details);
                SearchPageScrollContent.Children.Add(grid);
                Separator bookSep = new Separator() { Foreground = Brushes.LightGray, Margin = new Thickness(10, 8, 10, 8)  };
                SearchPageScrollContent.Children.Add(bookSep);
            }
            // Remove the last separator
            SearchPageScrollContent.Children.RemoveAt(SearchPageScrollContent.Children.Count - 1);
        }

        /**
         * Flattens a Key value pair to a list of books 
        **/

        public static Book[] GetBookResults(KeyValuePair<string, int>[] kvps)
        {
            Books instance = Books.Instance;

            List<Book> result = new List<Book>();
            foreach (KeyValuePair<string, int> kvp in kvps)
            {
                string match = kvp.Key;

                Book tmp_book;
                List<Book> tmp_series;
                List<Book> tmp_cat;
                Author tmp_author;

                if (instance.GetBooks().TryGetValue(match, out tmp_book))
                {
                    if (!result.Contains(tmp_book))
                    {
                        result.Add(tmp_book);
                    }
                } else if (instance.GetBookSeries().TryGetValue(match, out tmp_series))
                {
                    foreach (Book book in tmp_series)
                    {
                        if (!result.Contains(book))
                        {
                            result.Add(book);
                        }
                    }
                } else if (instance.getBookCategories().TryGetValue(match, out tmp_cat))
                {
                    foreach (Book book in tmp_cat)
                    {
                        if (!result.Contains(book))
                        {
                            result.Add(book);
                        }
                    }
                }else if (instance.GetAuthors().TryGetValue(match, out tmp_author))
                {
                    foreach (Book book in tmp_author.GetBooks())
                    {
                        if (!result.Contains(book))
                        {
                            result.Add(book);
                        }
                    }
                }
            }

            return result.ToArray();
        }

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
