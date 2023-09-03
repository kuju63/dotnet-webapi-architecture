using LayeredArchitecture.Repositories;
using LayeredArchitecture.Services.Models;

namespace LayeredArchitecture.Services;

public class BookService : IBookService
{
    private readonly ILogger<BookService> _logger;
    private readonly IHistoryRepository _historyRepository;


    public BookService(ILogger<BookService> logger, IHistoryRepository historyRepository)
    {
        _logger = logger;
        _historyRepository = historyRepository;

    }

    public Task<IEnumerable<BookModel>> GetBooksAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<string>> GetBookTagsAsync()
    {
        throw new NotImplementedException();
    }

}