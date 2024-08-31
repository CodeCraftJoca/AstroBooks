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
            var Publishers = await _getPublisherUseCase.GetPublisherNameAsync(query);
            return Ok(Publishers);
        }

        [HttpGet]
        [Route("GetPublisherById")]
        public async Task<IActionResult> GetPublisherById([FromQuery] Guid id)
        {
            var Publisher = await _getPublisherUseCase.GetPublisherById(id);
            return Ok(Publisher);
        }

        [HttpGet]
        [Route("GetPublishers")]
        public async Task<IActionResult> GetPublishers()
        {
            var Publishers = await _getPublisherUseCase.GetPublishersAsync();
            return Ok(Publishers);
        }

        [HttpPost]
        [Route("UpdatePublisher")]
        public async Task<IActionResult> UpdatePublisher([FromBody] PublisherUpdateRequestModel publisherUpdate)
        {
           var Publisher = await _updatePublisherUseCase.UpdatePublisherAsync(publisherUpdate);
           return Ok(Publisher);
        }
    }
}
