using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC_481_Digital_Library_Prototype.Classes
{
    public class Book
    {
        private string _imagePath;
        private Dictionary<string, bool> _formatAvailability;

        // Book details
        private Author _author;
        private string[] _categories;
        private string _description = "";
        private float _rating;
        private string _title = ""; 

        public Book(Author author, string[] categories, Dictionary<string, bool> formats, string imagePath, float rating)
        {
            _author = author;
            _imagePath = imagePath;
            _formatAvailability = formats;
            _rating = rating;
            _categories = categories;
        }

        #region Setters
        public Book SetDescription(string description)
        {
            _description = description;
            return this;
        }

        public Book SetTitle(string title)
        {
            _title = title;
            return this;
        }
        #endregion

        #region Getters
        public Author GetAuthor()
        {
            return _author;
        }
        public string GetImagePath()
        {
            return _imagePath;
        }

        public Dictionary<string, bool> GetFormatAvailabilities()
        {
            return _formatAvailability;
        }

        public float GetRating()
        {
            return _rating;
        }

        public string GetTitle()
        {
            return _title;
        }
        #endregion
    }
}
