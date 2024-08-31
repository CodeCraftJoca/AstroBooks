using AstroBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Infrastructure.Repository.Interfaces
{
    public interface IGenreRepository
    {
        Task<Genre> CreateGenreAsync(Genre genre);
        Task<bool> GenreIdExistsAsync(Guid id);
        Task<Genre> GetGenreByIdAsync(Guid id);
        Task<Genre> GetGenreByNameAsync(string email);
        Task<List<Genre>> GetGenresAsync();
        Task<Genre> UpdateGenreAsync(Genre genre);
        Task<bool> DeleteGenreAsync(Guid id);

    }
}
