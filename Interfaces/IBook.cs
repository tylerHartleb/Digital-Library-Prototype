using CPSC_481_Digital_Library_Prototype.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CPSC_481_Digital_Library_Prototype.Interfaces
{
    public interface IBook
    {
        public abstract string GetBookType();
        public abstract Author GetAuthor();


        public abstract string GetDescription();


        public abstract string GetImagePath();


        public abstract string GetNextInSeries();


        public abstract float GetRating();


        public abstract string GetSeries();


        public abstract string GetTitle();


        public abstract string[] GetCategories();

    }
}
