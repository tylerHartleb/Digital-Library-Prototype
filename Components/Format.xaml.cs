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
    /// Interaction logic for Format.xaml
    /// </summary>
    public partial class Format : UserControl
    {
        public Format(bool available, string imagePath)
        {
            InitializeComponent();
            SetFill(available);
            SetImagePath(imagePath); 
        }

        private void SetFill(bool aval)
        {
            if (aval)
            {
                RecFill.Fill = new SolidColorBrush(Colors.Green);
            } else
            {
                RecFill.Fill= new SolidColorBrush(Colors.Red);
            }
        }

        private void SetImagePath(string path)
        {
            Uri imageUri = new Uri(path, UriKind.Relative);
            BitmapImage imageBitmap = new BitmapImage(imageUri);
            FormatImage.Source = imageBitmap;
        }
    }
}
