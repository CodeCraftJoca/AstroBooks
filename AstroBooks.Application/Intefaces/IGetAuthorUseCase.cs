using AstroBooks.Application.DTO;
using AstroBooks.Application.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Application.Intefaces
{
    public interface IGetAuthorUseCase
    {
        Task<AuthorDTO> GetAuthorById(Guid id);
        Task<AuthorDTO> GetAuthorByEmailOrNameAsync(string email);
        Task<IEnumerable<AuthorDTO>> GetAuthorsAsync();
    }
}
