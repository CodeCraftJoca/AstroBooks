using AstroBooks.Domain.Entities;
using FluentValidation;

namespace AstroBooks.Application.DTO
{
    public class PublisherDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();

    }

    public class PublisherDTOValidator : AbstractValidator<PublisherDTO>
    {
        public PublisherDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
        }
    }
}
