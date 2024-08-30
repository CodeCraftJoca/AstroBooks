using AstroBooks.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Application.DTO
{
    public class AuthorDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }

    public class ValidateAuthorDTO : AbstractValidator<AuthorDTO>
    {
        public ValidateAuthorDTO()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Bio).NotEmpty().WithMessage("Bio is required");
        }
    }   
}
