using AstroBooks.Application.DTO;
using AstroBooks.Application.InputModel;
using AstroBooks.Application.Intefaces;
using AstroBooks.Domain.Entities;
using AstroBooks.Infrastructure.Repository.Interfaces;
using AutoMapper;
using FluentValidation;

namespace AstroBooks.Application.UseCases
{
    public class UpdateAuthorUseCase : IUpdateAuthorUseCase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public UpdateAuthorUseCase(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task<AuthorDTO> UpdateAuthorAsync(AuthorUpdateRequestModel authorUpdateRequestModel)
        {
            if (authorUpdateRequestModel == null)
            {
                throw new ArgumentNullException(nameof(authorUpdateRequestModel), "Update request model cannot be null.");
            }

            var authorDTO = _mapper.Map<AuthorDTO>(authorUpdateRequestModel);
            ValidateAuthor(authorDTO);

            var authorEntity = await _authorRepository.UpdateAuthorAsync(_mapper.Map<Author>(authorDTO));

            if (authorEntity == null)
            {
                throw new KeyNotFoundException("Author not found.");
            }

            return _mapper.Map<AuthorDTO>(authorEntity);
        }

        private void ValidateAuthor(AuthorDTO authorDTO)
        {
            var validator = new ValidateAuthorDTO();
            var validationResult = validator.Validate(authorDTO);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Author data is invalid", validationResult.Errors);
            }
        }
       
    }
}
