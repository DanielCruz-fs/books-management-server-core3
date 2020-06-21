using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoodBooks.Data.Models;
using GoodBooks.Dtos;
using GoodBooks.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GoodBooks.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching", "DANIEL"
        };

        private readonly ILogger<BooksController> _logger;
        private readonly IBookService bookService;

        public BooksController(ILogger<BooksController> logger, IBookService bookService)
        {
            _logger = logger;
            this.bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await this.bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await this.bookService.GetBook(id);
            return Ok(book);
        }

        [HttpPost("register")]
        public async Task<IActionResult> SaveBook(BookForCreation bookForCreation)
        {
            var book = new Book()
            {
                Title = bookForCreation.Title,
                Author = bookForCreation.Author,
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };

            this.bookService.AddBook(book);
            await this.bookService.SaveAll();

            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await this.bookService.GetBook(id);
            this.bookService.DeleteBook(book);
            await this.bookService.SaveAll();
            return Ok();
        }
    }
}
