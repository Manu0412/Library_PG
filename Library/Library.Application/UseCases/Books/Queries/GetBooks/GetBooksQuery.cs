using Library.Application.Utilities.Mediator;
using Library.Application.Utilities.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.UseCases.Books.Queries.GetBooks
{
    public class GetBooksQuery : IRequest<PaginationResponse<BookListItemDto>>
    {
        public PaginationRequest Pagination { get; set; } = PaginationRequest.Default();
    }
}
