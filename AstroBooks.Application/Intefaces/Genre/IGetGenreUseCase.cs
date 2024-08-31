using AstroBooks.Application.DTO;
using AstroBooks.Application.InputModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Application.Intefaces
{
    public interface IGetGenreUseCase
    {
        Task<GenreDTO> GetGenreNameAsync(string email);
        Task<IEnumerable<GenreDTO>> GetGenresAsync();
        Task<GenreDTO> GetGenreById(Guid id);
    }
}
