using AstroBooks.Domain.Entities;
using AstroBooks.Infrastructure.Contexts;
using AstroBooks.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AstroBooks.Infrastructure.Repository
{
    public class GenreRepository : IGenreRepository
    {
        private readonly AstroBooksContext _context;

        public GenreRepository(AstroBooksContext context)
        {
            _context = context;
        }
        public Task<Genre> CreateGenreAsync(Genre genre)
        {
            try
            {
                _context.Add(genre);
                _context.SaveChanges();
                return Task.FromResult(genre);
            }
            catch (Exception ex)
            {
                throw new Exception("Internal Server Error: " + ex.Message);
            }
        }

        public async Task<bool> GenreIdExistsAsync(Guid id)
        {
            try
            {
                return await _context.Genres.FindAsync(id) != null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Genre> GetGenreByNameAsync(string query)
        {
            return await _context.Genres.FirstOrDefaultAsync(u => u.Name == query);
        }

        public async Task<Genre> GetGenreByIdAsync(Guid id)
        {
            return await _context.Genres.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<Genre>> GetGenresAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public Task<Genre> UpdateGenreAsync(Genre genre)
        {
            _context.Genres.Update(genre);
            _context.SaveChanges();

            return Task.FromResult(genre);
        }

        public Task<bool> DeleteGenreAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
