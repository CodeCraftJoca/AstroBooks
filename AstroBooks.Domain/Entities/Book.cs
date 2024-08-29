using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Language { get; set; }
        public List<Genre> BookGenre { get; set; }
        public List<Author> BookAuthor { get; set; }
        public List<Publisher> Publisher { get; set; }

    }
}
