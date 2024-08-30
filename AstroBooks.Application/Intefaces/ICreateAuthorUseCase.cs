using AstroBooks.Application.DTO;
using AstroBooks.Application.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Application.Intefaces
{
    public interface ICreateAuthorUseCase
    {
        Task<AuthorDTO> CreateAuthor(AuthorRequestModel author);
    }
}
