using LibraryWebApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryWebApp.ViewModels
{
    public class BookViewModel
    {
        public long Id { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        public static Book ToModel(BookViewModel viewModel)
        {
            var book = new Book
            {
                Author = viewModel.Author,
                Id = viewModel.Id,
                Title = viewModel.Title,
                Year = viewModel.Year
            };
            return book;
        }

        public static BookViewModel ToViewModel(Book book)
        {
            var bookViewModel = new BookViewModel
            {
                Year = book.Year,
                Author = book.Author,
                Id = book.Id,
                Title = book.Title
            };
            return bookViewModel;
        }
    }
}