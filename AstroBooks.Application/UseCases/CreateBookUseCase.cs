using AstroBooks.Application.DTO;
using AstroBooks.Application.Intefaces;
using AstroBooks.Domain.Entities;
using AstroBooks.Infrastructure.Repository.Interfaces;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Application.UseCases
{
    public class CreateBookUseCase : ICreateBookUseCase
    {
        private readonly IBookRepository _IBookRepository;
        private readonly IMapper _mapper;
        public CreateBookUseCase(IBookRepository bookRepository, IMapper mapper)
        {

            _IBookRepository = bookRepository;
            _mapper = mapper;
        }
        public Task<BookDTO> CreateBook(BookDTO newBook)
        {
            BookValidation(newBook);
            var BookEntity = _IBookRepository.CreateBook(_mapper.Map<Book>(newBook));
            return Task.FromResult(_mapper.Map<BookDTO>(BookEntity));

        }

        private Guid GenerateUniqueBookId()
        {
            Guid newId;
            do
            {
                newId = Guid.NewGuid();
            } while (_IBookRepository.BookIdExistsAsync(newId) != null);

            return newId;
        }

        private void ValidateBookData(BookDTO bookDTO)
        {
            var validator = new BookDtoValidator();
            var validationResult = validator.Validate(bookDTO);

            if (!validationResult.IsValid)
            {
                throw new ValidationException("Book data is invalid", validationResult.Errors);
            }
        }

        private void BookValidation(BookDTO bookDTO)
        {
            // Gera um ID único para o livro
            bookDTO.Id = GenerateUniqueBookId();

            // Valida os dados do livro
            ValidateBookData(bookDTO);
        }


    }
}
