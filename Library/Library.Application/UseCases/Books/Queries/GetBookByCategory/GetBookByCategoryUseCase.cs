using Library.Application.Contracts.Repositories;
using Library.Application.UseCases.Books.Queries.GetBooks;
using Library.Application.Utilities.Mediator;
using Library.Application.Utilities.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.UseCases.Books.Queries.GetBookByCategory
{
    public class GetBookByCategoryUseCase : IRequestHandler<GetBookByCategoryQuery, PaginationResponse<BookListItemDto>>
    {
        private readonly IBookRepository _repository;

        public GetBookByCategoryUseCase(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginationResponse<BookListItemDto>> Handle(GetBookByCategoryQuery query)
        {
            var (books, totalCount) = await _repository.GetByCategoryIdAsync(query.CategoryId, query.Pagination);
            var items = books.Select(b => b.ToListItemDto()).ToList();
            return PaginationResponse<BookListItemDto>.Create(items, totalCount, query.Pagination);
        }
    }
}
