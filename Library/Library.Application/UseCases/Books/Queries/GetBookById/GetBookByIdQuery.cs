using System;
using System.Collections.Generic;
using System.Text;
using Library.Application.Utilities.Mediator;

namespace Library.Application.UseCases.Books.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<BookDetailDto?>
    {
        public int Id { get; set; }
    }
}
