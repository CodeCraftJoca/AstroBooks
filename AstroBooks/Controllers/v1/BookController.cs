using AstroBooks.Application.DTO;
using AstroBooks.Application.Intefaces;
using AstroBooks.Application.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace AstroBooks.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ICreateBookUseCase _createBookUseCase;
        private readonly IGetBookUseCase _getBookUseCase;
        private readonly IUpdateBookUseCase _updateBookUseCase;
        private readonly IDeleteBookUseCase _deleteBookUseCase; 
        
        public BookController(ICreateBookUseCase createBookUseCase, IGetBookUseCase getBookUseCase, IUpdateBookUseCase updateBookUseCase, IDeleteBookUseCase deleteBookUseCase)
        {
            _createBookUseCase = createBookUseCase;
            _getBookUseCase = getBookUseCase;
            _updateBookUseCase = updateBookUseCase;
            _deleteBookUseCase = deleteBookUseCase;
        }

        [HttpPost]
        [Route("createBook")]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookRequestModel book)
        {
            var createdBook = await _createBookUseCase.CreateBook(book);

            return CreatedAtAction(nameof(CreateBook), new { id = createdBook.Id }, createdBook);
        }
        [HttpGet]
        [Route("getBookById")]
        public async Task<IActionResult> GetBook([FromQuery] Guid id)
        {
            var book = await _getBookUseCase.GetBookById(id);

            return Ok(book);
        }

        [HttpGet]
        [Route("getBookByName")]
        public async Task<IActionResult> GetBookByName([FromQuery] string name)
        {
            var book = await _getBookUseCase.GetBookByNameAsync(name);

            return Ok(book);
        }

        [HttpGet]
        [Route("getBooks")]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _getBookUseCase.GetBooks();

            return Ok(books);
        }
        [HttpPost]
        [Route("updateBook")]
        public async Task<IActionResult> UpdateBook([FromBody] UpdateBookRequestModel book)
        {
             var updatedBook = await _updateBookUseCase.UpdateBook(book);

             return Ok(updatedBook);
        }

        [HttpDelete]
        [Route("deleteBook")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            try
            {
                await _deleteBookUseCase.DeleteBook(id);
                return NoContent(); 
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                // Registrar o erro
                return StatusCode(500, "An error occurred while deleting the book."); // Status code 500: Internal Server Error
            }
        }
    }
}
