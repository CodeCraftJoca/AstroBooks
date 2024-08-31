using AstroBooks.Application.DTO;
using AstroBooks.Application.InputModel;
using AstroBooks.Application.RequestModel;
using AstroBooks.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroBooks.Application.Mapping
{
    public class BookMapping: Profile
    {
        public BookMapping()
        {
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();
            CreateMap<Author, AuthorDTO>()
                        .ForMember(dest => dest.Books, opt => opt.Condition(src => src.Books != null));
            CreateMap<AuthorDTO, Author>()
                    .ForMember(dest => dest.Books, opt => opt.Condition(src => src.Books != null));
            CreateMap<AuthorRequestModel, AuthorDTO>()
                        .ForMember(dest => dest.Books, opt => opt.Ignore())
                        .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<AuthorUpdateRequestModel, AuthorDTO>()
                       .ForMember(dest => dest.Books, opt => opt.Ignore());

            CreateMap<AuthorUpdateRequestModel, Author>()
                .ForMember(dest => dest.Books, opt => opt.Ignore());



            CreateMap<CreatePublisherRequestModel, PublisherDTO>()
                        .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<PublisherDTO, Publisher>()
                .ForMember(dest => dest.Books, opt => opt.Condition(src => src.Books != null));

            CreateMap<Publisher, PublisherDTO>()
                .ForMember(dest => dest.Books, opt => opt.Condition(src => src.Books != null));

            CreateMap<PublisherUpdateRequestModel, PublisherDTO>()
                .ForMember(dest => dest.Books, opt => opt.Ignore());


        }
    }
}
