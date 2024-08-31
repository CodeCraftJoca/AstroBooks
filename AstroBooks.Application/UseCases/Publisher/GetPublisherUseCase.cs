using AstroBooks.Application.DTO;
using AstroBooks.Application.InputModel;
using AstroBooks.Application.Intefaces;
using AstroBooks.Domain.Entities;
using AstroBooks.Infrastructure.Repository.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Application.UseCases
{
    public class GetPublisherUseCase : IGetPublisherUseCase
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public GetPublisherUseCase(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }
        public async Task<PublisherDTO> GetPublisherNameAsync(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                throw new ArgumentNullException(nameof(query), "Query cannot be null or empty.");
            }

            var publisherEntity = await _publisherRepository.GetPublisherByNameAsync(query);

            if (publisherEntity == null)
            {
                throw new KeyNotFoundException("Publisher not found.");
            }

            return _mapper.Map<PublisherDTO>(publisherEntity);
        }

        public Task<PublisherDTO> GetPublisherById(Guid id)
        {
            if(id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var publisherEntity = _publisherRepository.GetPublisherByIdAsync(id);

            if (publisherEntity == null)
            {
                throw new KeyNotFoundException("Publisher not found.");
            }

           return Task.FromResult(_mapper.Map<PublisherDTO>(publisherEntity.Result));
        }

        public async Task<IEnumerable<PublisherDTO>> GetPublishersAsync()
        {
            var publishers = await _publisherRepository.GetPublishersAsync();

            if (publishers == null || !publishers.Any())
            {
                throw new KeyNotFoundException("Publisher not found.");
            }

            return _mapper.Map<IEnumerable<PublisherDTO>>(publishers);
        }
    }
}
