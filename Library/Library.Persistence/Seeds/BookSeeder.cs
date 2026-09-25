using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence.Seeds
{
    public class BookSeeder : IDataSeeder
    {
        private readonly DataContext _context;

        public BookSeeder(DataContext context)
        {
            _context = context;
        }

        public int Order => 3;

        public async Task SeedAsync(CancellationToken cancellationToken = default)
        {
            if (await _context.Books.AnyAsync(cancellationToken))
            {
                return;
            }

            Author garciaMarquez = await _context.Authors.FirstAsync(a => a.Name == "Gabriel García Márquez", cancellationToken);
            Author asimov = await _context.Authors.FirstAsync(a => a.Name == "Isaac Asimov", cancellationToken);
            Author harari = await _context.Authors.FirstAsync(a => a.Name == "Yuval Noah Harari", cancellationToken);
            Author quinn = await _context.Authors.FirstAsync(a => a.Name == "Julia Quinn", cancellationToken);
            Author fitzpatrick = await _context.Authors.FirstAsync(a => a.Name == "Becca Fitzpatrick", cancellationToken);
            Author wilde = await _context.Authors.FirstAsync(a => a.Name == "Oscar Wilde", cancellationToken);
            Author blasco = await _context.Authors.FirstAsync(a => a.Name == "Martín Blasco", cancellationToken);

            Category ficcion = await _context.Categories.FirstAsync(c => c.Name == "Ficción", cancellationToken);
            Category ciencia = await _context.Categories.FirstAsync(c => c.Name == "Ciencia", cancellationToken);
            Category historia = await _context.Categories.FirstAsync(c => c.Name == "Historia", cancellationToken);
            Category romance = await _context.Categories.FirstAsync(c => c.Name == "Romance", cancellationToken);
            Category misterio = await _context.Categories.FirstAsync(c => c.Name == "Misterio", cancellationToken);

            List<Book> books =
            [
                new Book("Cien años de soledad", "9780307474728", 1967, garciaMarquez.Id, ficcion.Id),
                new Book("El amor en los tiempos del cólera", "9789500703208", 1985, garciaMarquez.Id, ficcion.Id),
                new Book("Fundación", "9788497599245", 1951, asimov.Id, ciencia.Id),
                new Book("Sapiens", "9780062316097", 2011, harari.Id, historia.Id),
                new Book("Bridgerton", "9780062911414", 2000, quinn.Id, romance.Id),
                new Book("Hush, Hush", "9781416989417", 2009, fitzpatrick.Id, romance.Id),
                new Book("The Canterville Ghost", "9780582426917", 1887, wilde.Id, misterio.Id),
                new Book("La Oscuridad de los Colores", "9788408123456", 2015, blasco.Id, misterio.Id)
            ];

            await _context.Books.AddRangeAsync(books, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
