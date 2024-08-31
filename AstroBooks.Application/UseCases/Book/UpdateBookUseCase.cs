using AstroBooks.Application.DTO;
using AstroBooks.Application.Intefaces;
using AstroBooks.Application.RequestModel;
using AstroBooks.Application.Services.Interfaces;
using AstroBooks.Infrastructure.Repository.Interfaces;
using AstroBooks.Infrastructure.Services;
using AutoMapper;


namespace AstroBooks.Application.UseCases
{
    
    public class UpdateBookUseCase : IUpdateBookUseCase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IbookMapper _bookMapper;
        private readonly IBookBuilderService _bookBuilderService;
        
        public UpdateBookUseCase(IBookRepository bookRepository, IbookMapper bookMapper, IBookBuilderService bookBuilderService)
        {
            _bookRepository = bookRepository;
            _bookMapper = bookMapper;
            _bookBuilderService = bookBuilderService;

        }
        public async Task<BookDTO> UpdateBook(UpdateBookRequestModel updateBookRequestModel)
        {
           var book = await _bookBuilderService.UpdateBook(updateBookRequestModel);
            var bookEntity = await _bookRepository.UpdateBookAsync(_bookMapper.MapToEntity(book));
            return _bookMapper.MapToDto(bookEntity);
        }
    }
}
