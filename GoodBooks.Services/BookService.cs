using GoodBooks.Data;
using GoodBooks.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoodBooks.Services
{
    public class BookService : IBookService
    {
        private readonly GoodBooksDbContext context;

        public BookService(GoodBooksDbContext context)
        {
            this.context = context;
        }
        public void AddBook(Book book)
        {
            this.context.Add(book);
        }

        public void DeleteBook(Book book)
        {
            this.context.Remove(book);
        }

        public async Task<IList<Book>> GetAllBooks()
        {
            return await this.context.Books.ToListAsync();
        }

        public async Task<Book> GetBook(int bookId)
        {
            // Other options
            //var book = this.context.Books.First(b => b.Id == bookId);
            //var book = this.context.Books.Find(bookId); Cannot use INCLUDE with this approach
            return await this.context.Books.Include(b => b.BookReviews).FirstOrDefaultAsync(b => b.Id == bookId);
        }

        public async Task<bool> SaveAll()
        {
            return await this.context.SaveChangesAsync() > 0;
        }
    }
}
