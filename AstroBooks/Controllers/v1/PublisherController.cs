using AstroBooks.Application.InputModel;
using AstroBooks.Application.Intefaces;
using AstroBooks.Application.Intefaces.Publisher;
using AstroBooks.Application.RequestModel;
using Microsoft.AspNetCore.Mvc;

namespace AstroBooks.Controllers.v1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PublisherController: ControllerBase
    {
        private readonly ICreatePublisherUseCase _createPublisherUseCase;
        private readonly IGetPublisherUseCase _getPublisherUseCase;
        private readonly IUpdatePublisherUseCase _updatePublisherUseCase;

        public PublisherController(ICreatePublisherUseCase createPublisherUseCase, IGetPublisherUseCase getPublisherUseCase, IUpdatePublisherUseCase updatePublisherUseCase)
        {
            _createPublisherUseCase = createPublisherUseCase;
            _getPublisherUseCase = getPublisherUseCase;
            _updatePublisherUseCase = updatePublisherUseCase;
            
        }
       
        [HttpPost]
        [Route("CreatePublisher")]
        public async Task<IActionResult> CreatePublisher([FromBody] CreatePublisherRequestModel createPublisher)
        {
            var publisher = await _createPublisherUseCase.CreatePublisherAsync(createPublisher);
            return CreatedAtAction(nameof(CreatePublisher), new { id = publisher.Id }, publisher);
            
        }

        [HttpGet]
        [Route("GetPublisherByName")]
        public async Task<IActionResult> GetPublisherByName([FromQuery] string query)
        {
            var authors = await _getPublisherUseCase.GetPublisherNameAsync(query);
            return Ok(authors);
        }

        [HttpGet]
        [Route("GetPublisherById")]
        public async Task<IActionResult> GetAuthorById([FromQuery] Guid id)
        {
            var author = await _getPublisherUseCase.GetPublisherById(id);
            return Ok(author);
        }

        [HttpGet]
        [Route("GePublishers")]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await _getPublisherUseCase.GetPublishersAsync();
            return Ok(authors);
        }

        [HttpPost]
        [Route("UpdatePublisher")]
        public async Task<IActionResult> UpdateAuthor([FromBody] PublisherUpdateRequestModel publisherUpdate)
        {
           var author = await _updatePublisherUseCase.UpdatePublisherAsync(publisherUpdate);
           return Ok(author);
        }
    }
}
