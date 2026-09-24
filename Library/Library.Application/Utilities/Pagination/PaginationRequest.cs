using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Application.Utilities.Pagination
{
    public class PaginationRequest
    {
        public const int DefaultPageSize = 15;
        public const int MaxPageSize = 50;

        public int PageNumber { get; }
        public int PageSize { get; }

        public PaginationRequest(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = Math.Min(pageSize, MaxPageSize);
        }

        public static PaginationRequest Default() => new(1, DefaultPageSize);
    }
}
