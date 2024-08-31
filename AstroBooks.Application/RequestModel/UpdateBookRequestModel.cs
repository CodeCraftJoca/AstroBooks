using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Application.RequestModel
{
    public class UpdateBookRequestModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<Guid> BookGenre { get; set; }
        public List<Guid> BookAuthor { get; set; }
        public List<Guid> Publisher { get; set; }
        public string ISBN { get; set; }
        public string Language { get; set; }
    }
}
