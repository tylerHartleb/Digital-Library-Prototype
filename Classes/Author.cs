using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC_481_Digital_Library_Prototype.Classes
{
    public class Author
    {
        private string _name;

        public Author(string name)
        {
            _name = name;
        }

        #region Setters

        #endregion

        #region Getters
        public string GetName()
        {
            return _name;
        }
        #endregion
    }
}
