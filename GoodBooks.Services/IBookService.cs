using GoodBooks.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GoodBooks.Services
{
    public interface IBookService
    {
        void AddBook(Book book);
        void DeleteBook(Book book);
        Task<bool> SaveAll();
        Task<Book> GetBook(int bookId);
        Task<IList<Book>> GetAllBooks();

    }
}
