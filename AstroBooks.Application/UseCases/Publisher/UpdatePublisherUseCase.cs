using AstroBooks.Application.DTO;
using AstroBooks.Application.InputModel;
using AstroBooks.Application.Intefaces;
using AstroBooks.Domain.Entities;
using AstroBooks.Infrastructure.Repository;
using AstroBooks.Infrastructure.Repository.Interfaces;
using AutoMapper;
using FluentValidation;

namespace AstroBooks.Application.UseCases
{
    public class UpdatePublisherUseCase : IUpdatePublisherUseCase
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public UpdatePublisherUseCase(IPublisherRepository publisherRepositor, IMapper mapper)
        {
            _publisherRepository = publisherRepositor;
            _mapper = mapper;
        }
        public async Task<PublisherDTO> UpdatePublisherAsync(PublisherUpdateRequestModel publisherUpdateRequestModel)
        {
            if (publisherUpdateRequestModel == null)
            {
                throw new ArgumentNullException(nameof(publisherUpdateRequestModel), "Update request model cannot be null.");
            }

            var publisherDTO = _mapper.Map<PublisherDTO>(publisherUpdateRequestModel);
            ValidateAuthor(publisherDTO);

            var authorEntity = await _publisherRepository.UpdatePublisherAsync(_mapper.Map<Publisher>(publisherDTO));

            if (authorEntity == null)
            {
                throw new KeyNotFoundException("Publisher not found.");
            }

            return _mapper.Map<PublisherDTO>(authorEntity);
        }

        private void ValidateAuthor(PublisherDTO publisher)
        {
            var validator = new PublisherDTOValidator();
            var validationResult = validator.Validate(publisher);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("publisher data is invalid", validationResult.Errors);
            }
        }
       
    }
}
