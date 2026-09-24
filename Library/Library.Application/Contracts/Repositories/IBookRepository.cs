using Library.Application.Utilities.Pagination;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Contracts.Repositories
{
    public interface IBookRepository
    {
        Task<(List<Book> Items, int TotalCount)> GetAllAsync(PaginationRequest pagination);
        Task<Book?> GetBookByIdAsync(int id);
        Task<(List<Book> Items, int TotalCount)> GetByCategoryIdAsync(int categoryId, PaginationRequest pagination);
    }
}
