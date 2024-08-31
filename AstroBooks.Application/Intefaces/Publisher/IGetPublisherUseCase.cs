using AstroBooks.Application.DTO;
using AstroBooks.Application.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Application.Intefaces
{
    public interface IGetPublisherUseCase
    {
        Task<PublisherDTO> GetPublisherById(Guid id);
        Task<PublisherDTO> GetPublisherNameAsync(string email);
        Task<IEnumerable<PublisherDTO>> GetPublishersAsync();
    }
}
