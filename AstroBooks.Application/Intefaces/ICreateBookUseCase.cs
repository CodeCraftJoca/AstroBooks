using AstroBooks.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Application.Intefaces
{
    public interface ICreateBookUseCase
    {
        Task<BookDTO> CreateBook(BookDTO book);

    }
}
