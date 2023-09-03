using LayeredArchitecture.Services;

using Microsoft.AspNetCore.Mvc;

namespace LayeredArchitecture.Controllers;

[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly ILogger<BookController> _logger;

    public BookController(ILogger<BookController> logger, IBookService bookService)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetBooks")]
    public async Task<IEnumerable<BookResponse>> Get()
    {
        throw new NotImplementedException();
    }

    [HttpGet("tags", Name = "GetBookTags")]
    public async Task<IEnumerable<string>> GetTags()
    {
        throw new NotImplementedException();
    }
}