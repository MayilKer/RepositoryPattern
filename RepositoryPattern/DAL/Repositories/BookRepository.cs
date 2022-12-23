using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Interfaces;
using RepositoryPattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _ctx;
        public BookRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<Book> CreateBookAsync(Book book)
        {
            _ctx.Add(book);
            await _ctx.SaveChangesAsync();
            return book;
        }

        public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _ctx.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _ctx.Books.FirstOrDefaultAsync(book => book.Id == id);
        }
    }
}
