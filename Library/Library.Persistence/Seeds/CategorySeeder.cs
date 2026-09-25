using System;
using System.Collections.Generic;
using System.Text;
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Seeds
{
    public class CategorySeeder : IDataSeeder
    {
        private readonly DataContext _context;

        public CategorySeeder(DataContext context)
        {
            _context = context;
        }

        public int Order => 1;

        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            if (await _context.Categories.AnyAsync(cancellationToken))
            {
                return;
            }

            List<Category> categories =
            [
                new Category("Ficción"),
                new Category("Ciencia"),
                new Category("Historia"),
                new Category("Tecnología"),
                new Category("Romance"),
                new Category("Misterio")
            ];

            await _context.Categories.AddRangeAsync(categories, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
