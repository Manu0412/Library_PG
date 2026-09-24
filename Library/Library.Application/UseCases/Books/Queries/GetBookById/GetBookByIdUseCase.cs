using System;
using System.Collections.Generic;
using System.Text;
using Library.Application.Utilities.Mediator;
using Library.Application.Contracts.Repositories;

namespace Library.Application.UseCases.Books.Queries.GetBookById
{
    public class GetBookByIdUseCase : IRequestHandler<GetBookByIdQuery, BookDetailDto?>
    {
        private readonly IBookRepository _repository;

        public GetBookByIdUseCase(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<BookDetailDto?> Handle(GetBookByIdQuery query)
        {
            var book = await _repository.GetBookByIdAsync(query.Id);
            return book?.ToDetailDto();
        }
    }
}
