using AstroBooks.Application.InputModel;
using AstroBooks.Application.Intefaces;
using AstroBooks.Application.Intefaces.Publisher;
using AstroBooks.Application.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace AstroBooks.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GenreController: ControllerBase
    {
        private readonly ICreateGenreUseCase _createGenreUseCase;
        private readonly IGetGenreUseCase _getGenreUseCase;
        private readonly IUpdateGenreUseCase _updateGenreUseCase;

        public GenreController(ICreateGenreUseCase createGenreUseCase, IGetGenreUseCase getGenreUseCase, IUpdateGenreUseCase updateGenreUseCase)
        {
            _createGenreUseCase = createGenreUseCase;
            _getGenreUseCase = getGenreUseCase;
            _updateGenreUseCase = updateGenreUseCase;
        }
       
       
        [HttpPost]
        [Route("CreateGenre")]
        public async Task<IActionResult> CreateGenre([FromBody] CreateGenreRequestModel createGenre)
        {
            var genre = await _createGenreUseCase.CreateGenreAsync(createGenre);
            return CreatedAtAction(nameof(CreateGenre), new { id = genre.Id }, genre);
            
        }

        [HttpGet]
        [Route("GetGenreByName")]
        public async Task<IActionResult> GetGenreByName([FromQuery] string query)
        {
            var genre = await _getGenreUseCase.GetGenreNameAsync(query);
            return Ok(genre);
        }

        [HttpGet]
        [Route("GetGenreById")]
        public async Task<IActionResult> GetGenreById([FromQuery] Guid id)
        {
            var genre = await _getGenreUseCase.GetGenreById(id);
            return Ok(genre);
        }

        [HttpGet]
        [Route("GetGenres")]
        public async Task<IActionResult> GetGerens()
        {
            var genre = await _getGenreUseCase.GetGenresAsync();
            return Ok(genre);
        }

        [HttpPost]
        [Route("UpdateGenre")]
        public async Task<IActionResult> UpdateGenre([FromBody] GenreUpdateRequestModel genreUpdate)
        {
           var genre = await _updateGenreUseCase.UpdateGenreAsync(genreUpdate);
           return Ok(genre);
        }
    }
}
