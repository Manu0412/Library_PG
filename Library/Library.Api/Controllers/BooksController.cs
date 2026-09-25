using Library.Application.UseCases.Books.Queries.GetBookById;
using Library.Application.UseCases.Books.Queries.GetBooks;
using Library.Application.UseCases.Books.Queries.GetBookByCategory;
using Library.Application.Utilities.Mediator;
using Library.Application.Utilities.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<PaginationResponse<BookListItemDto>>> GetList(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = PaginationRequest.DefaultPageSize)
        {
            GetBooksQuery query = new()
            {
                Pagination = new PaginationRequest(pageNumber, pageSize)
            };

            PaginationResponse<BookListItemDto> result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BookDetailDto>> GetById(int id)
        {
            GetBookByIdQuery query = new() { Id = id };
            BookDetailDto? result = await _mediator.Send(query);

            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpGet("category/{categoryId:int}")]
        public async Task<ActionResult<PaginationResponse<BookListItemDto>>> GetByCategory(
            int categoryId,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = PaginationRequest.DefaultPageSize)
        {
            GetBookByCategoryQuery query = new()
            {
                CategoryId = categoryId,
                Pagination = new PaginationRequest(pageNumber, pageSize)
            };

            PaginationResponse<BookListItemDto> result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
