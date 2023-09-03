using AutoMapper;

using LayeredArchitecture.Services;

using Microsoft.AspNetCore.Mvc;

namespace LayeredArchitecture.Controllers;

[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly ILogger<BookController> _logger;
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;

    public BookController(ILogger<BookController> logger, IBookService bookService, IMapper mapper)
    {
        _logger = logger;
        _bookService = bookService;
        _mapper = mapper;
    }

    [HttpGet(Name = "GetBooks")]
    public async Task<IEnumerable<BookResponse>> Get()
    {
        var results = await _bookService.GetBooksAsync();
        return _mapper.Map<IEnumerable<BookResponse>>(results);
    }

    [HttpGet("tags", Name = "GetBookTags")]
    public async Task<IEnumerable<string>> GetTags()
    {
        var tags = await _bookService.GetBookTagsAsync();
        return tags;
    }
}