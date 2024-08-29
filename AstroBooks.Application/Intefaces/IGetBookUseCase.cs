﻿using AstroBooks.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Application.Intefaces
{
    public interface IGetBookUseCase
    {
        Task<BookDTO> GetBookById(Guid id);
        Task<BookDTO> GetBookByName(string name);
        Task<IEnumerable<BookDTO>> GetBooks();

    }
}
