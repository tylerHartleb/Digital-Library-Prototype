using CPSC_481_Digital_Library_Prototype.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CPSC_481_Digital_Library_Prototype
{
    [ContentProperty("ConditionalContent")]
    public partial class If : ContentControl
    {
        Users instance = Users.Instance;

        public If()
        {
            Loaded += OnLoad;
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            instance.LoginChange += AccountState_PropertyChanged;
            update();
        }

        private void update()
        {
            Content = instance.IsLoggedIn == Condition ? ConditionalContent : null;
        }

        void AccountState_PropertyChanged(object sender, EventArgs e)
        {
            update();
        }

        // === component properties
        public bool Condition
        {
            get { return (bool) GetValue(ConditionProperty); }
            set { SetValue(ConditionProperty, value); }
        }

        public static readonly DependencyProperty ConditionProperty = DependencyProperty.Register("Condition", typeof(bool), typeof(If), new PropertyMetadata(OnConditionChangedCallback));

        private static void OnConditionChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is If s)
            {
                s.update();
            }
        }

        public object ConditionalContent
        {
            get { return (object)GetValue(ConditionalContentProperty); }
            set { SetValue(ConditionalContentProperty, value); }
        }

        public static readonly DependencyProperty ConditionalContentProperty =
            DependencyProperty.Register("ConditionalContent", typeof(object), typeof(If), new PropertyMetadata(null, OnConditionChangedCallback));
    }
}
