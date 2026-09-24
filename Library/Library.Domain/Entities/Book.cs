using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    public sealed class Book
    {
        public int Id { get; private set; }
        public string Title { get; private set; } = null;
        public string Isbn { get; private set; } = null;
        public int PublicationYear { get; private set; }

        public int AuthorId { get; private set; }
        public Author Author { get; private set; }


        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

        public Book(string title, string isbn, int publicationYear, int authorId, int categoryId)
        {
            Title = title;
            Isbn = isbn;
            PublicationYear = publicationYear;
            AuthorId = authorId;
            CategoryId = categoryId;
        }

        private Book()
        {
        }

    }
}
