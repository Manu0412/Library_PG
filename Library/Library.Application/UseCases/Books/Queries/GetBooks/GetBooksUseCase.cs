using Library.Application.Contracts.Repositories;
using Library.Application.UseCases.Books.Queries.GetBookByCategory;
using Library.Application.Utilities.Mediator;
using Library.Application.Utilities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.UseCases.Books.Queries.GetBooks
{
    public class GetBooksUseCase : IRequestHandler<GetBooksQuery, PaginationResponse<BookListItemDto>>
    {
        private readonly IBookRepository _repository;

        public GetBooksUseCase(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginationResponse<BookListItemDto>> Handle(GetBooksQuery query)
        {
            var (books, totalCount) = await _repository.GetAllAsync(query.Pagination);
            var items = books.Select(b => b.ToListItemDto()).ToList();
            return PaginationResponse<BookListItemDto>.Create(items, totalCount, query.Pagination);
        }
    }
}
