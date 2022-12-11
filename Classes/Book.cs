﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPSC_481_Digital_Library_Prototype.Classes
{
    public class Book
    {
        private string _imagePath;

        // Book details
        private Author _author;
        private string[] _categories;
        private string _description = "";
        private float _rating;
        private string _title = "";
        private string _series = "";
        private string _nextinseries = "";

        public Book(Author author, string[] categories, string imagePath, float rating)
        {
            _author = author;
            _imagePath = imagePath;
            _rating = rating;
            _categories = categories;
        }

        #region Setters
        public Book SetDescription(string description)
        {
            _description = description;
            return this;
        }

        public Book SetNextInSeries(string next)
        {
            _nextinseries = next;
            return this;
        }

        public Book SetSeries(string series)
        {
            _series = series;
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

        public string GetDescription()
        {
            return _description;
        }

        public string GetImagePath()
        {
            return _imagePath;
        }

        public string GetNextInSeries()
        {
            return _nextinseries;
        }

        public float GetRating()
        {
            return _rating;
        }

        public string GetSeries()
        {
            return _series;
        }

        public string GetTitle()
        {
            return _title;
        }

        public string[] GetCategories() {
            return _categories;
        }
        #endregion

    }
}
