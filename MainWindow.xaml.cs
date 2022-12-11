using CPSC_481_Digital_Library_Prototype.Classes;
using CPSC_481_Digital_Library_Prototype.Components;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CPSC_481_Digital_Library_Prototype
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _book = "";
        private string _format = "";
        private Location? _location;

        public MainWindow()
        {
            InitializeComponent();
        }

        #region Handler
        public void Info_FlowControl(Object? sender, FlowControlEventArgs e)
        {
            Books instance = Books.Instance;
            string title = e.book;
            _book = title;
            string format = e.format;
            _format = format;
            Book book = instance.GetBooks()[title];

            int availability = 0;
            instance.GetLibraries().formatAvailability[title].TryGetValue(format, out availability);
            SetModalTitle(availability > 0, format);
            string flow = (format != "book" && availability > 0) ? "checkout" : "hold";
            SetModalContent(book, flow);
            SetModalActions(flow);

            Storyboard sb = FindResource("ExpandModal") as Storyboard;
            sb.Begin();
        }

        private void ModalClose_MouseDown(Object sender, MouseButtonEventArgs e)
        {
            ContentSize.Height = 275;
            ModalContent.Children.Clear();
            ModalActions.Children.Clear();
        }

        private void More_MouseDown(Object sender, MouseButtonEventArgs e)
        {
            ModalContent.Children.Clear();
            ModalActions.Children.Clear();

            ContentSize.Height = 548;

            Books instance = Books.Instance;
            Book book = instance.GetBooks()[_book];

            TextBlock title = CreateTitleBlock("Locations", 20, FontWeights.Medium);
            title.Margin = new Thickness(0, 0, 0, 6);
            ModalContent.Children.Add(title);

            // Create ScrollViewer
            ScrollViewer scrollView = new ScrollViewer() { VerticalScrollBarVisibility = ScrollBarVisibility.Hidden, HorizontalScrollBarVisibility = ScrollBarVisibility.Disabled, Height = 325 };
            StackPanel innerView = new StackPanel() { };

            // TODO - Get actual preferred location
            string preferredLocation = "fish creek";
            Location preferedLibrary = new Location(preferredLocation, book.GetTitle().ToLower(), true);
            preferedLibrary.PreviewMouseDown += Loc_MouseDown;
            _location = preferedLibrary;
            innerView.Children.Add(preferedLibrary);
            Separator bookSep = new Separator() { Foreground = Brushes.LightGray, Margin = new Thickness(10, 8, 10, 8) };
            innerView.Children.Add(bookSep);

            foreach (string loc in instance.GetLibraries().locations.Keys)
            {
                if (loc != preferredLocation)
                {
                    Location locDetails = new Location(loc, book.GetTitle().ToLower(), false);
                    locDetails.PreviewMouseDown += Loc_MouseDown;
                    innerView.Children.Add(locDetails);
                    Separator tmp_sep = new Separator() { Foreground = Brushes.LightGray, Margin = new Thickness(10, 8, 10, 8) };
                    innerView.Children.Add(tmp_sep);
                }
            }
            innerView.Children.RemoveAt(innerView.Children.Count - 1);

            scrollView.Content = innerView;
            ModalContent.Children.Add(scrollView);

            ModalActions.Margin = new Thickness(0, 0, 0, 16);
            Button confHold = CreatePrimaryButton("Confirm Hold", 250);
            ModalActions.Children.Add(confHold);

            Storyboard sb = FindResource("MoveModal") as Storyboard;
            sb.Begin();
        }

        private void Loc_MouseDown(Object sender, MouseButtonEventArgs e)
        {
            Location? clickLoc = sender as Location;

            if (clickLoc != null)
            {
                _location?.SetSelected(false);

                // Set clicked true
                clickLoc.SetSelected(true);
                _location = clickLoc;
            }
        }
        #endregion

        private void SetModalTitle(bool available, string format)
        {
            if (available && format != "book")
            {
                ModalTitle.Text = "Checkout";
            }
            else
            {
                ModalTitle.Text = "Place Hold";
            }
        }

        private void SetModalContent(Book book, string flow)
        {
            if (flow == "checkout")
            {
                TextBlock title = CreateTitleBlock(book.GetTitle(), 20, FontWeights.Medium);
                title.Margin = new Thickness(0, 0, 0, 6);
                TextBlock subTitle = CreateTitleBlock(book.GetAuthor().GetName(), 16, FontWeights.Normal);
                TextBlock date = CreateTitleBlock("10/10/23", 12, FontWeights.Normal);
                subTitle.Margin = new Thickness(0, 0, 0, 6);

                ModalContent.Children.Add(title);
                ModalContent.Children.Add(subTitle);
                ModalContent.Children.Add(date);
            } else
            {
                TextBlock title = CreateTitleBlock("Preferred Location", 20, FontWeights.Medium);
                title.Margin = new Thickness(0, 0, 0, 6);

                // TODO - Get actual preferred location
                string preferredLocation = "fish creek";
                Location preferedLibrary = new Location(preferredLocation, book.GetTitle().ToLower(), true);
                _location = preferedLibrary;

                ModalContent.Children.Add(title);
                ModalContent.Children.Add(preferedLibrary);
            }      
        }

        private void SetModalActions(string flow)
        {
            // TODO Add actions
            if (flow == "checkout")
            {
                ModalActions.Margin = new Thickness(0, 0, 0, 16);
                Button checkoutBtn = CreatePrimaryButton("Confirm Check Out", 250);
                ModalActions.Children.Add(checkoutBtn);
            } else
            {
                ModalActions.Margin = new Thickness(0, 0, 0, 8);
                Button holdBtn = CreatePrimaryButton("Place Hold", 175);
                holdBtn.Margin = new Thickness(4, 0, 4, 4);
                Button moreBtn = CreateSecondaryButton("More Locations", 171);
                moreBtn.Margin = new Thickness(4, 0, 4, 4);
                moreBtn.PreviewMouseDown += More_MouseDown;
                ModalActions.Children.Add(holdBtn);
                ModalActions.Children.Add(moreBtn);
            }
        }

        private TextBlock CreateTitleBlock(string title, int fontSize, FontWeight fontWeight)
        {
            return new TextBlock()
            {
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                TextAlignment = TextAlignment.Center,
                FontSize = fontSize,
                FontWeight = fontWeight,
                Text = title,
            };
        }

        private Button CreatePrimaryButton(string text, int width)
        {
            Style? primaryStyle = Application.Current.Resources["styleBtnPrimary"] as Style;
            return new Button() { 
                Height = 50,
                Width = width,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Left,
                Style = primaryStyle,
                Content=text
            };
        }

        private Button CreateSecondaryButton(string text, int width)
        {
            Style? primaryStyle = Application.Current.Resources["styleBtnSecondary"] as Style;
            return new Button()
            {
                Height = 50,
                Width = width,
                VerticalAlignment = VerticalAlignment.Bottom,
                HorizontalAlignment = HorizontalAlignment.Left,
                Style = primaryStyle,
                Content = text
            };
        }
    }
}
