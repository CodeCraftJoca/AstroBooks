using AstroBooks.Application.DTO;
using AstroBooks.Application.InputModel;
using AstroBooks.Application.RequestModel;
using AstroBooks.Domain.Entities;
using AutoMapper;


namespace AstroBooks.Application.Mapping
{
    public class ProfileMapping: Profile
    {
        public ProfileMapping()
        {


            CreateMap<Book, BookDTO>()
                 .ForMember(dest => dest.ISBN, opt => opt.MapFrom(src => src.ISBN))
                 .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Language))
                 .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres))
                 .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors))
                 .ForMember(dest => dest.Publishers, opt => opt.MapFrom(src => src.Publishers));

            CreateMap<BookDTO, Book>()
                .ForMember(dest => dest.ISBN, opt => opt.MapFrom(src => src.ISBN))
                .ForMember(dest => dest.Language, opt => opt.MapFrom(src => src.Language))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres))
                .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors))
                .ForMember(dest => dest.Publishers, opt => opt.MapFrom(src => src.Publishers));


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

            CreateMap<CreateGenreRequestModel, GenreDTO>()
                        .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<GenreDTO, Genre>()
                .ForMember(dest => dest.Books, opt => opt.Condition(src => src.Books != null));

            CreateMap<Genre, GenreDTO>()
                .ForMember(dest => dest.Books, opt => opt.Condition(src => src.Books != null));

            CreateMap<GenreUpdateRequestModel, GenreDTO>()
                .ForMember(dest => dest.Books, opt => opt.Ignore());







        }
    }
}
