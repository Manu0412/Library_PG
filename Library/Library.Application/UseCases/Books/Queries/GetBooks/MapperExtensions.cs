using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Library.Domain.Entities;

namespace Library.Application.UseCases.Books.Queries.GetBooks
{
    internal static class MapperExtensions
    {
        public static BookListItemDto ToBookListItemDto(this Book book)
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
