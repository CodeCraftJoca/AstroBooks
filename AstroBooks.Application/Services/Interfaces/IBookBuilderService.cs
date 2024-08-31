using AstroBooks.Application.DTO;
using AstroBooks.Application.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Application.Services.Interfaces
{
    public interface IBookBuilderService
    {
        Task<BookDTO> CreateBook(CreateBookRequestModel book);
        Task<BookDTO> UpdateBook(UpdateBookRequestModel book);
    }
}
