using AstroBooks.Application.DTO;
using AstroBooks.Application.Intefaces;
using AstroBooks.Infrastructure.Repository.Interfaces;
using AutoMapper;
using System;
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
        public GetBookUseCase(IBookRepository bookRepository, IMapper mapper)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }
        public async Task<BookDTO> GetBookById(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new ArgumentException("ID cannot be empty", nameof(id));
            }

            var book = await _bookRepository.GetBookById(id);

            if (book == null)
            {
                throw new ValidationException($"Book with ID {id} not found");
            }

            return _mapper.Map<BookDTO>(book);
        }


        public Task<BookDTO> GetBookByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookDTO>> GetBooks()
        {
            throw new NotImplementedException();
        }
    }
}
