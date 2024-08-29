using AstroBooks.Application.DTO;
using AstroBooks.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Application.Mapping
{
    public class BookMapping: Profile
    {
        public BookMapping()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();
              

        }
    }
}
