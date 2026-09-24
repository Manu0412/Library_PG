using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.UseCases.Books.Queries.GetBookById
{
    public class BookDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Isbn { get; set; } = null!;
        public int PublicationYear { get; set; }
        public string AuthorName { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
    }
}
