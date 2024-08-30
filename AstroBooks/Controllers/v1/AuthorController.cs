using AstroBooks.Application.DTO;
using AstroBooks.Application.InputModel;
using AstroBooks.Application.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace AstroBooks.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly ICreateAuthorUseCase _createAuthorUseCase;
        private readonly IGetAuthorUseCase _getAuthorUseCase;
        private readonly IUpdateAuthorUseCase _updateAuthorUseCase;
        public AuthorController(ICreateAuthorUseCase createAuthorUseCase, IGetAuthorUseCase getAuthorUseCase, IUpdateAuthorUseCase updateAuthorUseCase)
        {
            _createAuthorUseCase = createAuthorUseCase;
            _getAuthorUseCase = getAuthorUseCase;
            _updateAuthorUseCase = updateAuthorUseCase;
        }

        [HttpPost]
        [Route("CreateAuthor")]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorRequestModel authorRequest)
        {
            var author = await _createAuthorUseCase.CreateAuthor(authorRequest);
            return CreatedAtAction(nameof(CreateAuthor), new { id = author.Id }, author);
        }

        [HttpGet]
        [Route("GetAuthorsByNameOrEmail")]
        public async Task<IActionResult> GetAuthorsByNameOrEmail([FromQuery]string query)
        {
            var authors = await _getAuthorUseCase.GetAuthorByEmailOrNameAsync(query);
            return Ok(authors);
        }

        [HttpGet]
        [Route("GetAuthorById")]
        public async Task<IActionResult> GetAuthorById([FromQuery]Guid id)
        {
            var author = await _getAuthorUseCase.GetAuthorById(id);
            return Ok(author);
        }

        [HttpGet]
        [Route("GetAuthors")]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _getAuthorUseCase.GetAuthorsAsync();
            return Ok(authors);
        }

        [HttpPost]
        [Route("UpdateAuthor")]
        public async Task<IActionResult> UpdateAuthor([FromBody] AuthorUpdateRequestModel authorRequest)
        {
            var author = await _updateAuthorUseCase.UpdateAuthorAsync(authorRequest);
            return Ok(author);
        }



    }
}
