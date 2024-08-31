using AstroBooks.Domain.Entities;
using AstroBooks.Infrastructure.Contexts;
using AstroBooks.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Infrastructure.Repository
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly AstroBooksContext _context;

        public PublisherRepository(AstroBooksContext context)
        {
            _context = context;
        }
        public Task<Publisher> CreatePublisherAsync(Publisher publisher)
        {
            try
            {
                _context.Add(publisher);
                _context.SaveChanges();
                return Task.FromResult(publisher);
            }
            catch (Exception ex)
            {
                throw new Exception("Internal Server Error: " + ex.Message);
            }
        }

        public async Task<bool> PublisherIdExistsAsync(Guid id)
        {
            try
            {
                return await _context.Publishers.FindAsync(id) != null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Publisher> GetPublisherByNameAsync(string query)
        {
            return await _context.Publishers.FirstOrDefaultAsync(u => u.Name == query);
        }

        public async Task<Publisher> GetPublisherByIdAsync(Guid id)
        {
            return await _context.Publishers.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<Publisher>> GetPublishersAsync()
        {
            return await _context.Publishers.ToListAsync();
        }

        public Task<Publisher> UpdatePublisherAsync(Publisher publisher)
        {
            _context.Publishers.Update(publisher);
            _context.SaveChanges();

            return Task.FromResult(publisher);
        }

        public Task<bool> DeletePublisherAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
