using AstroBooks.Application.DTO;
using AstroBooks.Application.Intefaces;
using AstroBooks.Application.RequestModel;
using AstroBooks.Application.Services.Interfaces;
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
        private readonly IBookBuilderService _bookBuilderService;
        private readonly IMapper _mapper;
        private readonly IbookMapper _bookMapper;


        public CreateBookUseCase(IBookRepository bookRepository, IMapper mapper, IBookBuilderService bookBuilderService, IbookMapper bookMapper)
        {
            _bookBuilderService = bookBuilderService;
            _IBookRepository = bookRepository;
            _mapper = mapper;
            _bookMapper = bookMapper;
        }
        public async Task<BookDTO> CreateBook(CreateBookRequestModel newBook)
        {
            try
            {
                var newBookDto = await _bookBuilderService.CreateBook(newBook);
                BookValidation(newBookDto);
                var BookEntity = await _IBookRepository.CreateBookAsync(_bookMapper.MapToEntity(newBookDto));

                return _bookMapper.MapToDto(BookEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<Guid> GenerateUniqueBookId()
        {
            Guid newId;
            do
            {
                newId = Guid.NewGuid();
            } while (await _IBookRepository.BookIdExistsAsync(newId) == true);

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

        private async void BookValidation(BookDTO bookDTO)
        {
            // Gera um ID único para o livro
            bookDTO.Id = await GenerateUniqueBookId();

            // Valida os dados do livro
            ValidateBookData(bookDTO);
        }


    }
}
