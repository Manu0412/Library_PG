using System;
using System.Collections.Generic;
using System.Text;
using Library.Application.UseCases.Books.Queries.GetBooks;

namespace Library.Application.UseCases.Books.Queries.GetBookByCategory
{
    internal static class MapperExtensions
    {
        public static BookListItemDto ToListItemDto(this Domain.Entities.Book book)
        {
            return new BookListItemDto
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
