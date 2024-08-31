using AstroBooks.Domain.Entities;
using AstroBooks.Infrastructure.Contexts;
using AstroBooks.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Net;

namespace AstroBooks.Infrastructure.Repository
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
            try
            {
                return await _context.Books.FindAsync(id) != null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Book> CreateBookAsync(Book bookDTO)
        {
            if (bookDTO == null)
            {
                throw new ArgumentNullException(nameof(bookDTO));
            }

            try
            {
                // Obter os objetos de autores, publicadores e gêneros a partir do DTO
                var authorsDTO = bookDTO.Authors ?? new List<Author>();
                var publishersDTO = bookDTO.Publishers ?? new List<Publisher>();
                var genresDTO = bookDTO.Genres ?? new List<Genre>();

                // Obter os IDs dos autores, publicadores e gêneros a partir dos objetos
                var authorIds = authorsDTO.Select(a => a.Id).ToList();
                var publisherIds = publishersDTO.Select(p => p.Id).ToList();
                var genreIds = genresDTO.Select(g => g.Id).ToList();

                // Verificar se há IDs e buscar as entidades correspondentes
                var authors = authorIds.Any()
                    ? await _context.Authors
                        .Where(a => authorIds.Contains(a.Id))
                        .ToArrayAsync()
                    : Array.Empty<Author>();

                var publishers = publisherIds.Any()
                    ? await _context.Publishers
                        .Where(p => publisherIds.Contains(p.Id))
                        .ToListAsync()
                    : new List<Publisher>();

                var genres = genreIds.Any()
                    ? await _context.Genres
                        .Where(g => genreIds.Contains(g.Id))
                        .ToListAsync()
                    : new List<Genre>();

                // Criar a nova instância do livro e associar as entidades obtidas
                var book = new Book
                {
                    Title = bookDTO.Title,
                    ISBN = bookDTO.ISBN,
                    Language = bookDTO.Language,
                    Authors = authors,      // Associar os autores
                    Publishers = publishers, // Associar os publicadores
                    Genres = genres         // Associar os gêneros
                };

                // Adicionar o livro ao contexto
                _context.Books.Add(book);

                // Salvar as alterações no banco de dados
                await _context.SaveChangesAsync();

                return book;
            }
            catch (Exception ex)
            {
                // Registrar a exceção ou tratar de forma apropriada
                // Por exemplo: _logger.LogError(ex, "Erro ao criar o livro.");
                throw;
            }
        }




        public async Task DeleteBookSync(Guid id)
        {
            var existingBook = await _context.Books
                         .Include(b => b.Authors)
                         .Include(b => b.Publishers)
                         .Include(b => b.Genres)
                         .FirstOrDefaultAsync(b => b.Id == id);

            if (existingBook == null)
            {
                throw new KeyNotFoundException("Book not found.");
            }

            // Limpa as relações do livro
            existingBook.Authors.Clear();
            existingBook.Publishers.Clear();
            existingBook.Genres.Clear();

            // Remove o livro do contexto
            _context.Books.Remove(existingBook);

            // Salva as mudanças no banco de dados
            await _context.SaveChangesAsync();
        }

        public async Task<Book> GetBookById(Guid id)
        {
            return await _context.Books
                    .Include(b => b.Authors)       // Inclui autores
                    .Include(b => b.Publishers)    // Inclui publicadores
                    .Include(b => b.Genres)        // Inclui gêneros
                    .FirstOrDefaultAsync(b => b.Id == id); // Obtém o livro pelo ID
                    }

        public async Task<List<Book>> GetBooksByNameAsync(string name)
        {
            return await _context.Books
                .Include(b => b.Authors)       // Inclui autores
                .Include(b => b.Publishers)    // Inclui publicadores
                .Include(b => b.Genres)        // Inclui gêneros
                .Where(b => b.Title.Contains(name)) // Filtra os livros pelo nome
                .ToListAsync();                // Retorna uma lista de livros
        }

        public Task<List<Book>> GetBooks()
        {
            return _context.Books
                .Include(b => b.Authors)       // Inclui autores
                .Include(b => b.Publishers)    // Inclui publicadores
                .Include(b => b.Genres)        // Inclui gêneros
                .ToListAsync();                // Retorna uma lista de livros
        }

        public async Task<Book> UpdateBookAsync(Book updatedBook)
        {
            // Carrega o livro existente com os autores, publicadores e gêneros atuais
            var existingBook = await _context.Books
                .Include(b => b.Authors)
                .Include(b => b.Publishers)
                .Include(b => b.Genres)
                .FirstOrDefaultAsync(b => b.Id == updatedBook.Id);

            if (existingBook == null)
            {
                throw new KeyNotFoundException("Book not found.");
            }

            // Atualiza autores: carrega os autores existentes do banco de dados
            existingBook.Authors.Clear();
            foreach (var author in updatedBook.Authors)
            {
                var existingAuthor = await _context.Authors.FindAsync(author.Id);
                if (existingAuthor != null)
                {
                    existingBook.Authors.Add(existingAuthor);
                }
            }

            // Atualiza publicadores: carrega os publicadores existentes do banco de dados
            existingBook.Publishers.Clear();
            foreach (var publisher in updatedBook.Publishers)
            {
                var existingPublisher = await _context.Publishers.FindAsync(publisher.Id);
                if (existingPublisher != null)
                {
                    existingBook.Publishers.Add(existingPublisher);
                }
            }

            // Atualiza gêneros: carrega os gêneros existentes do banco de dados
            existingBook.Genres.Clear();
            foreach (var genre in updatedBook.Genres)
            {
                var existingGenre = await _context.Genres.FindAsync(genre.Id);
                if (existingGenre != null)
                {
                    existingBook.Genres.Add(existingGenre);
                }
            }

            // Atualiza outras propriedades do livro, se necessário
            existingBook.Title = updatedBook.Title;
            existingBook.ISBN = updatedBook.ISBN;
            existingBook.Language = updatedBook.Language;

            // Marca o livro como modificado e salva as alterações no banco de dados
            _context.Books.Update(existingBook);
            await _context.SaveChangesAsync();

            return existingBook;
        }



    }
}
