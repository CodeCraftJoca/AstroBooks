using AstroBooks.Application.DTO;
using AstroBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Application.Intefaces
{
    public interface IbookMapper
    {
        Book MapToEntity(BookDTO dto);
        BookDTO MapToDto(Book book);
        List<BookDTO> MapToDtoList(List<Book> book);
    }
}
