using AstroBooks.Domain.Entities;
using AstroBooks.Infrastructure.Contexts;
using AstroBooks.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AstroBooks.Infrastructure.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AstroBooksContext _context;
        public AuthorRepository(AstroBooksContext context)
        {
            _context = context;
        }
        public async Task<bool> AuthorIdExistsAsync(Guid id)
        {
            try
            {
                return await _context.Authors.FindAsync(id) != null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<Author> CreateAuthorAsync(Author author)
        {
           if(author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            _context.Authors.Add(author);
            _context.SaveChanges();

            return Task.FromResult(author);
        }

        public Task<bool> DeleteAuthorAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Author> GetAuthorByEmailOrNameAsync(string query)
        {
            return await _context.Authors
            .FirstOrDefaultAsync(u => u.Email == query || u.Name == query);
        }

        public async Task<Author> GetAuthorByIdAsync(Guid id)
        {
            return await _context.Authors.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<Author>> GetAuthorsAsync()
        {
           return await _context.Authors.ToListAsync();
        }

        public Task<Author> UpdateAuthorAsync(Author author)
        {
            _context.Authors.Update(author);
            _context.SaveChanges();

            return Task.FromResult(author);
        }
    }
}
