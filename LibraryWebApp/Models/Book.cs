using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.Models
{
    public class Book
    {
        public long Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }
    }
}