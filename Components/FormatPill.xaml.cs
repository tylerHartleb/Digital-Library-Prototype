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
    /// Interaction logic for FormatPill.xaml
    /// </summary>
    public partial class FormatPill : UserControl
    {
        private bool _selected = false;
        private int _numCopies = 0;
        public bool _available { get; private set; } = false;
        public string _format { get; private set; }

        public FormatPill(bool selected, int numCopies, bool available, String Format)
        {
            InitializeComponent();
            _selected = selected;
            _numCopies = numCopies;
            _available = available;
            _format = Format;

            FormatText.Text = Format;
            ChangePillState();
        }

        public void SetSelected(bool sel)
        {
            _selected = sel;
            ChangePillState();
        }

        private void ChangePillState()
        {
            ChangePillColor();
            ChangePillText();
        }

        private void ChangePillColor()
        {
            if (_selected)
            {
                if (_available)
                {
                    FormatBorder.BorderBrush = Brushes.Green;
                    FormatText.Foreground = Brushes.Green;
                } else
                {
                    FormatBorder.BorderBrush = Brushes.Red;
                    FormatText.Foreground = Brushes.Red;
                }
            }
            else
            {
                FormatBorder.BorderBrush = Brushes.Gray;
                FormatText.Foreground = Brushes.Gray;
            }
        }

        private void ChangePillText()
        {
            if (_available)
            {
                NumCopies.Text = _numCopies + " available";
                NumCopies.Foreground = Brushes.Green;
            } else
            {
                NumCopies.Text = "Not available";
                NumCopies.Foreground = Brushes.Red;
            }
        }
    }
}
