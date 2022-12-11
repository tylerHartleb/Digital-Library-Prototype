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
using System.Configuration;
using System.Diagnostics;

namespace CPSC_481_Digital_Library_Prototype.Classes
{
    public class Utils
    {
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

        public static int ComputeLevenshteinDistance(string a, string b)
        {
            int a_length = a.Length;
            int b_length = b.Length;
            int[,] distance = new int[a_length + 1, b_length + 1];

            // Guards
            if (a_length == 0) return b_length;
            if (b_length == 0) return b_length;

            // We must init arrays
            for (int i = 0; i <= a_length; distance[i, 0] = i++)
            {
                distance[i, 0] = 0;
            }
            for (int j = 0; j <= b_length; j++)
            {
                distance[0, j] = 0;
            }


            for (int i = 1; i <= a_length; i++)
            {
                for (int j = 1; j <= b_length; j++)
                {
                    int cost = (b[j -1] == a[i - 1]) ? 0 : 1;
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j -1] + 1), distance[i - 1, j - 1] + cost);
                }
            }

            int min = int.MaxValue;
            for (int j = 0; j < b_length; j++)
            {
                if (distance[a_length, j] < min) min = distance[a_length, j];
            }

            return min;
        }
    }
}
