using AstroBooks.Application.DTO;
using AstroBooks.Application.InputModel;
using AstroBooks.Application.Intefaces;
using AstroBooks.Domain.Entities;
using AstroBooks.Infrastructure.Repository.Interfaces;
using AutoMapper;
using FluentValidation;


namespace AstroBooks.Application.UseCases
{
    public class CreateAuthorUseCase : ICreateAuthorUseCase
    {
        private readonly IAuthorRepository _AuthorRepository;
        private readonly IMapper _mapper;
        public CreateAuthorUseCase(IAuthorRepository IAuthorRepository, IMapper mapper)
        {
            _AuthorRepository = IAuthorRepository;
            _mapper = mapper;
        }
        public Task<AuthorDTO> CreateAuthor(AuthorRequestModel author)
        {
            try
            {
                var authorDto = _mapper.Map<AuthorDTO>(author);
                AuthorValidator(authorDto);
                var authorEntity = _AuthorRepository.CreateAuthorAsync(_mapper.Map<Author>(authorDto));
                return Task.FromResult(_mapper.Map<AuthorDTO>(authorEntity.Result));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void AuthorValidateData(AuthorDTO author)
        {
            var validator = new ValidatePublisherDTO();
            var validationResult = validator.Validate(author);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Author data is invalid", validationResult.Errors);
            }
        }


        private async Task<Guid> GenerateUniqueAuthorId()
        {
            Guid newId;
            do
            {
                newId = Guid.NewGuid();
            } while (await _AuthorRepository.AuthorIdExistsAsync(newId) == true);

            return newId;
        }

        private void AuthorValidator(AuthorDTO author)
        {
            author.Id = GenerateUniqueAuthorId().Result;

            AuthorValidateData(author);
        }

    }
}
