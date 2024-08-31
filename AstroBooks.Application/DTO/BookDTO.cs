using AstroBooks.Domain.Entities;
using FluentValidation;

namespace AstroBooks.Application.DTO
{
    public class BookDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Publisher> Publishers { get; set; }
        public ICollection<Genre> Genres { get; set; }


        public string ISBN { get; set; }
        public string Language { get; set; }
    }

    public class BookDtoValidator: AbstractValidator<BookDTO>
    {
        public BookDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Title is required");
            RuleFor(x => x.Authors).NotEmpty().WithMessage("Author is required");
            RuleFor(x => x.Publishers).NotEmpty().WithMessage("Publisher is required");
            RuleFor(x => x.ISBN).NotEmpty().WithMessage("ISBN is required");
            RuleFor(x => x.Language).NotEmpty().WithMessage("Language is required");
            RuleFor(x => x.Genres).NotEmpty().WithMessage("Genre is required");
        }

        private bool IsValidISBN(string isbn)
        {
            // Implement your ISBN validation logic here (e.g., regex check)
            return true; // Simplification for example purposes
        }
    }   
}
