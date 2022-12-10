using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows;
using System.IO;
using System.Xml;

namespace CPSC_481_Digital_Library_Prototype.Classes
{
    public class Utils
    {
        public static T Clone<T>(T source)
        {
            string savedObject = XamlWriter.Save(source);

            // Load the XamlObject
            StringReader stringReader = new StringReader(savedObject);
            XmlReader xmlReader = XmlReader.Create(stringReader);
            T target = (T) XamlReader.Load(xmlReader);

            return target;
        }

        public static T FindElementInTree<T>(DependencyObject child, string parentName)
            where T : DependencyObject
            {
                if (child == null) return null;

                T foundParent = null;
                var currentParent = VisualTreeHelper.GetParent(child);

                do
                {
                    var frameworkElement = currentParent as FrameworkElement;
                    if (frameworkElement.Name == parentName && frameworkElement is T)
                    {
                        foundParent = (T) currentParent;
                        break;
                    }

                    currentParent = VisualTreeHelper.GetParent(currentParent);

                } while (currentParent != null);

                return foundParent;
            }
    }
}
