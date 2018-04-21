using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryWebApp.Models;
using LibraryWebApp.Repository;
using LibraryWebApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApp.Controllers
{
    [Route("api/Books")]
    public class BooksController : Controller
    {
        private readonly BookRepository _bookRepository;
        public BooksController(LibraryDbContext dbContext)
        {
            _bookRepository = new BookRepository(dbContext);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookRepository.GetAll().Select(BookViewModel.ToViewModel));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(long id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(BookViewModel.ToViewModel(book));
        }

        [HttpPost]
        public IActionResult Add([FromBody]BookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var book = BookViewModel.ToModel(viewModel);
                book.Id = 0;
                _bookRepository.Add(book);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Edit(long id, [FromBody]BookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var oldBook = _bookRepository.GetById(id);
                if (oldBook == null)
                {
                    return NotFound();
                }
                var book = BookViewModel.ToModel(viewModel);
                book.Id = id;
                _bookRepository.Edit(book);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            _bookRepository.Delete(book);
            return Ok();
        }
    }
}