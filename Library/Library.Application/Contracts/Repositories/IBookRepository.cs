using Library.Application.Utilities.Pagination;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Contracts.Repositories
{
    public interface IBookRepository
    {
        Task<PaginationResponse<Book>> GetAllAsync(PaginationRequest pagination);
        Task<Book?> GetBookByIdAsync(int id);
        Task<PaginationResponse<Book>> GetByCategoryIdAsync(int categoryId, PaginationRequest pagination);
    }
}
