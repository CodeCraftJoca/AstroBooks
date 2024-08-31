using AstroBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Infrastructure.Repository.Interfaces
{
    public interface IBookRepository
    {
        Task<List<Book>> GetBooks();
        Task<Book> GetBookById(Guid id);
        Task<Book> CreateBookAsync(Book book);
        Task<Book> UpdateBookAsync(Book book);
        Task DeleteBookSync(Guid id);
        Task<bool> BookIdExistsAsync(Guid id);
        Task<List<Book>> GetBooksByNameAsync(string name);
        

    }
}
