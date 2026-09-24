using System;
using System.Collections.Generic;
using System.Text;
using Library.Application.UseCases.Books.Queries.GetBookById;

namespace Library.Application.UseCases.Books.Queries.GetBookById
{
    internal static class MapperExtensions
    {
        public static BookDetailDto ToDetailDto(this Domain.Entities.Book book)
        {
            return new BookDetailDto
            {
                Id = book.Id,
                Title = book.Title,
                Isbn = book.Isbn,
                PublicationYear = book.PublicationYear,
                AuthorName = book.Author.Name,
                CategoryName = book.Category.Name
            };
        }
    }
}
