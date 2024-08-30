using AstroBooks.Application.Intefaces;
using AstroBooks.Application.UseCases;
using AstroBooks.Infrastructure.Repository;
using AstroBooks.Infrastructure.Repository.Interfaces;

namespace AstroBooks.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();

            services.AddScoped<IGetBookUseCase, GetBookUseCase>();
            services.AddScoped<ICreateBookUseCase, CreateBookUseCase>();

            services.AddScoped<ICreateAuthorUseCase, CreateAuthorUseCase>();
            services.AddScoped<IGetAuthorUseCase, GetAuthorUseCase>();
            services.AddScoped<IUpdateAuthorUseCase, UpdateAuthorUseCase>();

            return services;
        }
    }
}
