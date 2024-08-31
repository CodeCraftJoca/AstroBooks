using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Application.Intefaces
{
    public interface IDeleteBookUseCase
    {
        Task DeleteBook(Guid id);
    }
}
