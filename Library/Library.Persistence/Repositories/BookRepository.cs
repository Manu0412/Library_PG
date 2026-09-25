using Library.Application.Utilities.Pagination;
using Library.Domain.Entities;
using Library.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Library.Application.Contracts.Repositories;

namespace Library.Persistence.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<PaginationResponse<Book>> GetAllAsync(PaginationRequest pagination)
        {
            IQueryable<Book> query = _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .OrderBy(b => b.Title);

            return await query.ToPagedListAsync(pagination);
        }

        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<PaginationResponse<Book>> GetByCategoryIdAsync(int categoryId, PaginationRequest pagination)
        {
            IQueryable<Book> query = _context.Books
                .Include(b => b.Author)
                .Include(b => b.Category)
                .Where(b => b.CategoryId == categoryId)
                .OrderBy(b => b.Title);

            return await query.ToPagedListAsync(pagination);
        }
    }
}
