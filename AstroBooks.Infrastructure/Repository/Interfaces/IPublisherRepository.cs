using AstroBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Infrastructure.Repository.Interfaces
{
    public interface IPublisherRepository
    {
        Task<Publisher> CreatePublisherAsync(Publisher publisher);
        Task<bool> PublisherIdExistsAsync(Guid id);
        Task<Publisher> GetPublisherByIdAsync(Guid id);
        Task<Publisher> GetPublisherByNameAsync(string email);
        Task<List<Publisher>> GetPublishersAsync();
        Task<Publisher> UpdatePublisherAsync(Publisher author);
        Task<bool> DeletePublisherAsync(Guid id);

    }
}
