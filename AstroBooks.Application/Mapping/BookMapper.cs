using AstroBooks.Application.DTO;
using AstroBooks.Application.Intefaces;
using AstroBooks.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Application.Mapping
{
    public class BookMapper : IbookMapper
    {
        public Book MapToEntity(BookDTO dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            var book = new Book
            {
                Id = dto.Id,
                Title = dto.Title,
                ISBN = dto.ISBN,
                Language = dto.Language,
                Genres = dto.Genres?.Select(g => new Genre
                {
                    Id = g.Id,
                    Description = g.Description
                }).ToList() ?? new List<Genre>(),
                Authors = dto.Authors?.Select(a => new Author
                {
                    Id = a.Id,
                    Name = a.Name,
                    Email = a.Email,
                    Bio = a.Bio
                }).ToList() ?? new List<Author>(),
                Publishers = dto.Publishers?.Select(p => new Publisher
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description
                }).ToList() ?? new List<Publisher>()
            };

            return book;
        }

        public BookDTO MapToDto(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));

            var dto = new BookDTO
            {
                Id = book.Id,
                Title = book.Title,
                ISBN = book.ISBN,
                Language = book.Language,
                Genres = (book.Genres?.Select(g => new Genre
                {
                    Id = g.Id,
                    Description = g.Description
                }).ToList() ?? new List<Genre>()),
                Authors = (book.Authors?.Select(a => new Author
                {
                    Id = a.Id,
                    Name = a.Name,
                    Email = a.Email,
                    Bio = a.Bio
                }).ToList() ?? new List<Author>()),
                Publishers = (book.Publishers?.Select(p => new Publisher
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description
                }).ToList() ?? new List<Publisher>())
            };

            return dto;
        }

        public List<BookDTO> MapToDtoList(List<Book> book)
        {

            var dto = book.Select(b => new BookDTO
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                Language = b.Language,
                Genres = (b.Genres?.Select(g => new Genre
                {
                    Id = g.Id,
                    Description = g.Description
                }).ToList() ?? new List<Genre>()),
                Authors = (b.Authors?.Select(a => new Author
                {
                    Id = a.Id,
                    Name = a.Name,
                    Email = a.Email,
                    Bio = a.Bio
                }).ToList() ?? new List<Author>()),
                Publishers = (b.Publishers?.Select(p => new Publisher
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description
                }).ToList() ?? new List<Publisher>())
            }).ToList();

            return dto;
            
        }

    }
}
