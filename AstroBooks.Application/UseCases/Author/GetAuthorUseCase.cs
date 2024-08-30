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
    public class GetAuthorUseCase : IGetAuthorUseCase
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAuthorUseCase(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public async Task<AuthorDTO> GetAuthorByEmailOrNameAsync(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentNullException(nameof(query), "Query cannot be null or empty.");
            }

            var authorEntity = await _authorRepository.GetAuthorByEmailOrNameAsync(query);

            if (authorEntity == null)
            {
                throw new KeyNotFoundException("Author not found.");
            }

            return _mapper.Map<AuthorDTO>(authorEntity);
        }

        public Task<AuthorDTO> GetAuthorById(Guid id)
        {
            if(id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var authorEntity = _authorRepository.GetAuthorByIdAsync(id);

            if (authorEntity == null)
            {
                throw new KeyNotFoundException("Author not found.");
            }

           return Task.FromResult(_mapper.Map<AuthorDTO>(authorEntity.Result));
        }

        public async Task<IEnumerable<AuthorDTO>> GetAuthorsAsync()
        {
            var authors = await _authorRepository.GetAuthorsAsync();

            if (authors == null || !authors.Any())
            {
                throw new KeyNotFoundException("Authors not found.");
            }

            return _mapper.Map<IEnumerable<AuthorDTO>>(authors);
        }
    }
}
