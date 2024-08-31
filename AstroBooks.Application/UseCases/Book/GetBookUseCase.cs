using AstroBooks.Application.DTO;
using AstroBooks.Application.Intefaces;
using AstroBooks.Infrastructure.Repository.Interfaces;
using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Application.UseCases
{
    public class GetBookUseCase : IGetBookUseCase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly IbookMapper _bookMapper;
        public GetBookUseCase(IBookRepository bookRepository, IMapper mapper, IbookMapper bookMapper)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
            _bookMapper = bookMapper;
        }
        public async Task<BookDTO> GetBookById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("ID cannot be empty", nameof(id));
            }

            var bookEntity = await _bookRepository.GetBookById(id);

            if (bookEntity == null)
            {
                throw new ValidationException($"Book with ID {id} not found");
            }

            return _bookMapper.MapToDto(bookEntity);
        }


        public async Task<List<BookDTO>> GetBookByNameAsync(string name)
        {
            
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be empty", nameof(name));
            }
            var bookyEntity = await _bookRepository.GetBooksByNameAsync(name);
            if (bookyEntity == null)
            {
                throw new ValidationException($"Book with Name {name} not found");
            }

            return _bookMapper.MapToDtoList(bookyEntity);

        }

        public async Task<List<BookDTO>> GetBooks()
        {
            var books = await _bookRepository.GetBooks();

            return _bookMapper.MapToDtoList(books);
        }
    }
}
