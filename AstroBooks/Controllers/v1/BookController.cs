using AstroBooks.Application.DTO;
using AstroBooks.Application.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace AstroBooks.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ICreateBookUseCase _bookUseCase;
        public BookController(ICreateBookUseCase bookUseCase)
        {
            _bookUseCase = bookUseCase;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateBook([FromBody] BookDTO book)
        {
            var createdBook = await _bookUseCase.CreateBook(book);

            return CreatedAtAction(nameof(createdBook), new { id = createdBook.Id }, createdBook);
        }
    }
}
