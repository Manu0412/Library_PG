using Library.Application.UseCases.Books.Queries.GetBooks;
using Library.Application.Utilities.Mediator;
using Library.Application.Utilities.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.UseCases.Books.Queries.GetBookByCategory
{
    public class GetBookByCategoryQuery : IRequest<PaginationResponse<BookListItemDto>>
    {
        public int CategoryId { get; set; }
        public PaginationRequest Pagination { get; set; } = PaginationRequest.Default();
    }
}
