using AstroBooks.Domain.Entities;
using AstroBooks.Infrastructure.Contexts;
using AstroBooks.Infrastructure.Repository.Interfaces;

namespace AstroBooks.Infrastructure.Repository.BookRepository
{
    public class BookRepository : IBookRepository
    {
        private readonly AstroBooksContext _context;
        public BookRepository(AstroBooksContext context)
        {
            _context = context;
        }
        public async Task<bool> BookIdExistsAsync(Guid id)
        {
            return await _context.Books.FindAsync(id) != null;
        }

        public Task<Book> CreateBook(Book book)
        {
           if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            _context.Books.Add(book);
            _context.SaveChanges();

            return Task.FromResult(book);
        }

        public Task<Book> DeleteBook(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Book> GetBookById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetBooks()
        {
            throw new NotImplementedException();
        }

        public Task<Book> UpdateBook(Guid id, Book book)
        {
            throw new NotImplementedException();
        }
    }
}
