using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CPSC_481_Digital_Library_Prototype.Components
{
    /// <summary>
    /// Interaction logic for TabIcon.xaml
    /// </summary>
    public partial class TabIcon : UserControl
    {
        string _TabName = "";
        public static readonly DependencyProperty _ImagePath = DependencyProperty.Register("bgImage", typeof(ImageSource), typeof(TabIcon), new PropertyMetadata(null));

        public TabIcon()
        {
            InitializeComponent();
        }

        #region Getters and Setters

        public string TabName { get { return _TabName; } set { _TabName = value; } }

        public ImageSource ImagePath { 
            get { 
                return (ImageSource)GetValue(_ImagePath); 
            } 
            set {
                Trace.WriteLine(value);
                SetValue(_ImagePath, value);
            } 
        }

        #endregion
    }
}
