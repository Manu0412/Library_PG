using Library.Application.UseCases.Books.Queries.GetBookByCategory;
using Library.Application.UseCases.Books.Queries.GetBookById;
using Library.Application.UseCases.Books.Queries.GetBooks;
using Library.Application.Utilities.Mediator;
using Library.Application.Utilities.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using Library.Application.Contracts.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application
{
    public static class ApplicationServicesRegistry
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Mediator
            services.AddScoped<IMediator, SimpleMediator>();

            // Use Cases
            services.AddScoped<IRequestHandler<GetBooksQuery, PaginationResponse<BookListItemDto>>, GetBooksUseCase>();
            services.AddScoped<IRequestHandler<GetBookByIdQuery, BookDetailDto?>, GetBookByIdUseCase>();
            services.AddScoped<IRequestHandler<GetBookByCategoryQuery, PaginationResponse<BookListItemDto>>, GetBookByCategoryUseCase>();

            return services;
        }
    }
}
