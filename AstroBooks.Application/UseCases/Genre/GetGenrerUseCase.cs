using AstroBooks.Application.DTO;
using AstroBooks.Application.InputModel;
using AstroBooks.Application.Intefaces;
using AstroBooks.Domain.Entities;
using AstroBooks.Infrastructure.Repository.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Application.UseCases
{
    public class GetGenreUseCase : IGetGenreUseCase
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GetGenreUseCase(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }
        public async Task<GenreDTO> GetGenreNameAsync(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentNullException(nameof(query), "Query cannot be null or empty.");
            }

            var GenreEntity = await _genreRepository.GetGenreByNameAsync(query);

            if (GenreEntity == null)
            {
                throw new KeyNotFoundException("Genre not found.");
            }

            return _mapper.Map<GenreDTO>(GenreEntity);
        }

        public Task<GenreDTO> GetGenreById(Guid id)
        {
            if(id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var GenreEntity = _genreRepository.GetGenreByIdAsync(id);

            if (GenreEntity == null)
            {
                throw new KeyNotFoundException("Genre not found.");
            }

           return Task.FromResult(_mapper.Map<GenreDTO>(GenreEntity.Result));
        }

        public async Task<IEnumerable<GenreDTO>> GetGenresAsync()
        {
            var Genres = await _genreRepository.GetGenresAsync();

            if (Genres == null || !Genres.Any())
            {
                throw new KeyNotFoundException("Genre not found.");
            }

            return _mapper.Map<IEnumerable<GenreDTO>>(Genres);
        }
    }
}
