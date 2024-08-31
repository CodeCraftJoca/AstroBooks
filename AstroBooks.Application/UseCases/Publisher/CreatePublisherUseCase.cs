using AstroBooks.Application.DTO;
using AstroBooks.Application.Intefaces.Publisher;
using AstroBooks.Application.RequestModel;
using AstroBooks.Domain.Entities;
using AstroBooks.Infrastructure.Repository;
using AstroBooks.Infrastructure.Repository.Interfaces;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Application.UseCases
{
    public class CreatePublisherUseCase : ICreatePublisherUseCase
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public CreatePublisherUseCase(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public Task<PublisherDTO> CreatePublisherAsync(CreatePublisherRequestModel createPublisher)
        {
            var publisherDto = _mapper.Map<PublisherDTO>(createPublisher);
            PublisherValidator(publisherDto);
            var publisherEntity = _publisherRepository.CreatePublisherAsync(_mapper.Map<Publisher>(publisherDto));
            return Task.FromResult(_mapper.Map<PublisherDTO>(publisherEntity.Result));

        }

        private void PublisherValidateData(PublisherDTO publisher)
        {
            var validator = new PublisherDTOValidator();
            var validationResult = validator.Validate(publisher);
            if (!validationResult.IsValid)
            {
                throw new ValidationException("Author data is invalid", validationResult.Errors);
            }
        }


        private async Task<Guid> GenerateUniquePublicId()
        {
            Guid newId;
            do
            {
                newId = Guid.NewGuid();
            } while (await _publisherRepository.PublisherIdExistsAsync(newId) == true);

            return newId;
        }

        private void PublisherValidator(PublisherDTO publisher)
        {
            publisher.Id = GenerateUniquePublicId().Result;

            PublisherValidateData(publisher);
        }


    }
}
