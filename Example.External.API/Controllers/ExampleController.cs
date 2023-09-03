using Microsoft.AspNetCore.Mvc;

namespace Example.External.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ExampleController : ControllerBase
{
    private static readonly ExampleBook[] ExampleBooks = new []
    {
        new ExampleBook("Example Book 1", "This is an example book.", new [] { "example", "book" }),
        new ExampleBook("Example Book 2", "This is another example book.", new [] { "example", "book" }),
        new ExampleBook("Example Book 3", "This is a third example book.", new [] { "example", "book" }),
    };

    public ExampleController(ILogger<ExampleController> logger)
    {
        
    }

    [HttpGet(Name = "GetExampleBooks")]
    public IEnumerable<ExampleBook> Get()
    {
        return ExampleBooks;
    }

    [HttpGet("tags", Name = "GetExampleBookTags")]
    public IEnumerable<string> GetTags()
    {
        return ExampleBooks.SelectMany(book => book.Tags).Distinct();
    }
}

public record class ExampleBook(string Title, string Description, string[] Tags);