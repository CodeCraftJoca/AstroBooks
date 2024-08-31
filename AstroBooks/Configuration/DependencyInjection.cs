using AstroBooks.Application.Intefaces;
using AstroBooks.Application.Intefaces.Publisher;
using AstroBooks.Application.Mapping;
using AstroBooks.Application.Services.Interfaces;
using AstroBooks.Application.UseCases;
using AstroBooks.Application.UseCases.Book;
using AstroBooks.Infrastructure.Repository;
using AstroBooks.Infrastructure.Repository.Interfaces;
using AstroBooks.Infrastructure.Services;

namespace AstroBooks.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();

            services.AddScoped<IGetBookUseCase, GetBookUseCase>();
            services.AddScoped<ICreateBookUseCase, CreateBookUseCase>();
            services.AddScoped<IUpdateBookUseCase, UpdateBookUseCase>();
            services.AddScoped<IDeleteBookUseCase, DeleteBookUseCase>();

            services.AddScoped<ICreateAuthorUseCase, CreateAuthorUseCase>();
            services.AddScoped<IGetAuthorUseCase, GetAuthorUseCase>();
            services.AddScoped<IUpdateAuthorUseCase, UpdateAuthorUseCase>();

            services.AddScoped<ICreatePublisherUseCase, CreatePublisherUseCase>();
            services.AddScoped<IGetPublisherUseCase, GetPublisherUseCase>();
            services.AddScoped<IUpdatePublisherUseCase, UpdatePublisherUseCase>();

            services.AddScoped<ICreateGenreUseCase, CreateGenreUseCase>();
            services.AddScoped<IGetGenreUseCase, GetGenreUseCase>();
            services.AddScoped<IUpdateGenreUseCase, UpdateGenreUseCase>();

            //Services
            services.AddScoped<IBookBuilderService, BookBuilderService>();
            services.AddScoped<IbookMapper, BookMapper>();
            return services;
        }
    }
}
