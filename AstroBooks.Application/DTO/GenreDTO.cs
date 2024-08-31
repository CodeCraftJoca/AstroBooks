using AstroBooks.Domain.Entities;
using FluentValidation;

namespace AstroBooks.Application.DTO
{
    public class GenreDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();

    }

    public class GenreDTOValidator : AbstractValidator<GenreDTO>
    {
        public GenreDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        }
    }
}
