using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Seeds
{
    public class AuthorSeeder : IDataSeeder
    {
        private readonly DataContext _context;

        public AuthorSeeder(DataContext context)
        {
            _context = context;
        }

        public int Order => 2;

        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            if (await _context.Authors.AnyAsync(cancellationToken))
            {
                return;
            }

            List<Author> authors =
            [
                new Author("Gabriel García Márquez"),
                new Author("Isaac Asimov"),
                new Author("Yuval Noah Harari"),
                new Author("Julia Quinn"),
                new Author("Becca Fitzpatrick"),
                new Author("Oscar Wilde"),
                new Author("Martín Blasco")
            ];

            await _context.Authors.AddRangeAsync(authors, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
