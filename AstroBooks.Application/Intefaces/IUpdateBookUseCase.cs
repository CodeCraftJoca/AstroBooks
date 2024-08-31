using AstroBooks.Application.DTO;
using AstroBooks.Application.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Application.Intefaces
{
    public interface IUpdateBookUseCase
    {
        Task<BookDTO> UpdateBook(UpdateBookRequestModel updateBookRequestModel);
    }
}
