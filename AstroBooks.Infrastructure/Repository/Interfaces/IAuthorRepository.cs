using AstroBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Infrastructure.Repository.Interfaces
{
    public interface IAuthorRepository
    {
        Task<Author> CreateAuthorAsync(Author author);
        Task<Author> GetAuthorByIdAsync(Guid id);
        Task<Author> GetAuthorByEmailOrNameAsync(string email);
        Task<List<Author>> GetAuthorsAsync();
        Task<Author> UpdateAuthorAsync(Author author);
        Task<bool> DeleteAuthorAsync(Guid id);
        Task<bool> AuthorIdExistsAsync(Guid id);

    }
}
