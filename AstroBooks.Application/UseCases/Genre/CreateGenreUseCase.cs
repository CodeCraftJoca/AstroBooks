using AstroBooks.Application.DTO;
using AstroBooks.Application.Intefaces;
using AstroBooks.Application.RequestModel;
using AstroBooks.Domain.Entities;
using AstroBooks.Infrastructure.Repository.Interfaces;
using AutoMapper;
using FluentValidation;


namespace AstroBooks.Application.UseCases
{
    public class CreateGenreUseCase : ICreateGenreUseCase
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public CreateGenreUseCase(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public Task<GenreDTO> CreateGenreAsync(CreateGenreRequestModel createGenre)
        {
            var genreDto = _mapper.Map<GenreDTO>(createGenre);
            PublisherValidator(genreDto);
            var genreEntity = _genreRepository.CreateGenreAsync(_mapper.Map<Genre>(genreDto));
            return Task.FromResult(_mapper.Map<GenreDTO>(genreEntity.Result));

        }

        private void PublisherValidateData(GenreDTO genre)
        {
            var validator = new GenreDTOValidator();
            var validationResult = validator.Validate(genre);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Genre data is invalid", validationResult.Errors);
            }
        }


        private async Task<Guid> GenerateUniqueGenreId()
        {
            Guid newId;
            do
            {
                newId = Guid.NewGuid();
            } while (await _genreRepository.GenreIdExistsAsync(newId) == true);

            return newId;
        }

        private void PublisherValidator(GenreDTO genre)
        {
            genre.Id = GenerateUniqueGenreId().Result;

            PublisherValidateData(genre);
        }


    }
}
