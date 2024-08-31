using AstroBooks.Application.DTO;
using AstroBooks.Application.RequestModel;
using AstroBooks.Application.Services.Interfaces;
using AstroBooks.Domain.Entities;
using AstroBooks.Infrastructure.Repository;
using AstroBooks.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Infrastructure.Services
{
    public class BookBuilderService : IBookBuilderService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IGenreRepository _genreRepository;

        public BookBuilderService(IAuthorRepository authorRepository, IPublisherRepository publisherRepository, IGenreRepository genreRepository)
        {
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
            _genreRepository = genreRepository;
        }

        public async Task<BookDTO> CreateBook(CreateBookRequestModel book)
        {
            var authors = await GetAuthorsByIdsAsync(book.BookAuthor);
            var publishers = await GetPublishersByIdsAsync(book.Publisher);
            var genres = await GetGenresByIdsAsync(book.BookGenre);

            var newbook = new BookDTO
            {
                Authors = authors,
                Genres = genres,
                Publishers = publishers,
                ISBN = book.ISBN,
                Language = book.Language,
                Title = book.Title
            };

            return newbook;
        }

        public async Task<BookDTO> UpdateBook(UpdateBookRequestModel book)
        {
            var authors = await GetAuthorsByIdsAsync(book.BookAuthor);
            var publishers = await GetPublishersByIdsAsync(book.Publisher);
            var genres = await GetGenresByIdsAsync(book.BookGenre);

            var newbook = new BookDTO
            {
                Id = book.Id,
                Authors = authors,
                Genres = genres,
                Publishers = publishers,
                ISBN = book.ISBN,
                Language = book.Language,
                Title = book.Title
            };

            return newbook;
        }   

        private async Task<List<Author>> GetAuthorsByIdsAsync(IEnumerable<Guid> authorIds)
        {
            var authors = new List<Author>();
            foreach (var id in authorIds)
            {
                var author = await _authorRepository.GetAuthorByIdAsync(id);
                authors.Add(author);
            }
            return authors;
        }

        private async Task<List<Publisher>> GetPublishersByIdsAsync(IEnumerable<Guid> publisherIds)
        {
            var publishers = new List<Publisher>();
            foreach (var id in publisherIds)
            {
                var publisher = await _publisherRepository.GetPublisherByIdAsync(id);
                publishers.Add(publisher);
            }
            return publishers;
        }

        private async Task<List<Genre>> GetGenresByIdsAsync(IEnumerable<Guid> genreIds)
        {
            var genres = new List<Genre>();
            foreach (var id in genreIds)
            {
                var genre = await _genreRepository.GetGenreByIdAsync(id);
                genres.Add(genre);
            }
            return genres;
        }
    }

}
