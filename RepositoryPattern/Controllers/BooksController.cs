using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.DAL;
using RepositoryPattern.Interfaces;
using RepositoryPattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookRepository _books;
        public BooksController(IBookRepository books)
        {
            _books = books;
        }
        public async Task<IActionResult> GetAllBooks()
        {
            return Ok(await _books.GetAllBooksAsync());
        }

        [Route("{id}")]
        public async Task<IActionResult> GetBookById(int id)
        {
            return Ok(await _books.GetBookByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] Book book)
        {
            return Ok(await _books.CreateBookAsync(book));
        }
    }
}
