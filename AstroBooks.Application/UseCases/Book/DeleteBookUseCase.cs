using AstroBooks.Application.Intefaces;
using AstroBooks.Infrastructure.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Application.UseCases.Book
{
    public class DeleteBookUseCase: IDeleteBookUseCase
    {
        private readonly IBookRepository _bookRepository;

        public DeleteBookUseCase(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Task DeleteBook(Guid id)
        {
            if(id == Guid.Empty)
            {
                throw new ArgumentException("Id cannot be empty");
            }
            return _bookRepository.DeleteBookSync(id);
        }
    }
}
