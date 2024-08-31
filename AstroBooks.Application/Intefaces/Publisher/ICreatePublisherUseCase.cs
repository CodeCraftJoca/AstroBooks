using AstroBooks.Application.DTO;
using AstroBooks.Application.RequestModel;


namespace AstroBooks.Application.Intefaces.Publisher
{
    public interface ICreatePublisherUseCase
    {
        Task<PublisherDTO> CreatePublisherAsync(CreatePublisherRequestModel createPublisher);
    }
}
