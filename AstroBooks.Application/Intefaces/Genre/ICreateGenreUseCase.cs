using AstroBooks.Application.DTO;
using AstroBooks.Application.RequestModel;


namespace AstroBooks.Application.Intefaces
{
    public interface ICreateGenreUseCase
    {
        Task<GenreDTO> CreateGenreAsync(CreateGenreRequestModel createGenre);
    }
}
