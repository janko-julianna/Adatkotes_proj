using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace menhely
{
    public class Book
    {
        public string Author { get; private set; }
        public string Title { get; private set; }
        public int Year { get; private set; }
        public Book(string Author, string Title, int Year)
        {
            this.Author = Author;
            this.Title = Title;
            this.Year = Year;
        }

        public Book()
        {
            this.Author = "";
            this.Title = "";
            this.Year = -1;
        }

    }
}