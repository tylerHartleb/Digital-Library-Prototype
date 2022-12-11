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
    /// Interaction logic for Location.xaml
    /// </summary>
    public partial class Location : UserControl
    {
        public string _book { get; private set; }
        public string _location { get; private set; }
        public bool _selected = false;

        public Location(string location, string book, bool selected = false)
        {
            InitializeComponent();
            _location = location;
            _book = book;
            _selected = selected;

            SetLocationDetails();
            SetLocationState();
        }

        private void SetLocationDetails()
        {
            Books instance = Books.Instance;
            Library location = instance.GetLibraries().locations[_location];
            LocationTitle.Text = location.Name;
            int numAval = location.AvailableCopies(_book);
            int numHeld = location.HeldCopies(_book);
            LocationInventory.Text = numAval + " Available, " + numHeld + " on hold";
        }

        public void SetSelected(bool sel)
        {
            _selected = sel;
            SetLocationState();
        }

        private void SetLocationState()
        {
            if (_selected)
            {
                LocationBorder.BorderBrush = Brushes.Green;
                LocationSelect.Visibility = Visibility.Collapsed;
                LocationSelected.Visibility = Visibility.Visible;
            } else
            {
                LocationBorder.BorderBrush = Brushes.Transparent;
                LocationSelect.Visibility = Visibility.Visible;
                LocationSelected.Visibility = Visibility.Collapsed;
            }
        }
    }
}
