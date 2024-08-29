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
        Task<IEnumerable<Book>> GetBooks();
        Task<Book> GetBookById(Guid id);
        Task<Book> CreateBook(Book book);
        Task<Book> UpdateBook(Guid id, Book book);
        Task<Book> DeleteBook(Guid id);
        Task<bool> BookIdExistsAsync(Guid id);

    }
}
