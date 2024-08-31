using AstroBooks.Application.DTO;
using AstroBooks.Application.InputModel;
using AstroBooks.Application.Intefaces;
using AstroBooks.Domain.Entities;
using AstroBooks.Infrastructure.Repository.Interfaces;
using AutoMapper;
using FluentValidation;

namespace AstroBooks.Application.UseCases
{
    public class UpdateGenreUseCase : IUpdateGenreUseCase
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public UpdateGenreUseCase(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }
        public async Task<GenreDTO> UpdateGenreAsync(GenreUpdateRequestModel genreUpdateRequestModel)
        {
            if (genreUpdateRequestModel == null)
            {
                throw new ArgumentNullException(nameof(genreUpdateRequestModel), "Update request model cannot be null.");
            }

            var genreDTO = _mapper.Map<GenreDTO>(genreUpdateRequestModel);
            ValidateGenre(genreDTO);

            var authorEntity = await _genreRepository.UpdateGenreAsync(_mapper.Map<Genre>(genreDTO));

            if (authorEntity == null)
            {
                throw new KeyNotFoundException("Genre not found.");
            }

            return _mapper.Map<GenreDTO>(authorEntity);
        }

        private void ValidateGenre(GenreDTO genre)
        {
            var validator = new GenreDTOValidator();
            var validationResult = validator.Validate(genre);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Genre data is invalid", validationResult.Errors);
            }
        }
       
    }
}
