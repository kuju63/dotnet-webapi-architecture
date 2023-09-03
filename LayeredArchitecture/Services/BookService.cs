using AutoMapper;

using LayeredArchitecture.Repositories;
using LayeredArchitecture.Services.Models;

namespace LayeredArchitecture.Services;

public class BookService : IBookService
{
    private readonly ILogger<BookService> _logger;
    private readonly IHistoryRepository _historyRepository;
    private readonly IBookApi _bookApi;
    private readonly IMapper _mapper;

    public BookService(ILogger<BookService> logger, IHistoryRepository historyRepository, IBookApi bookApi, IMapper mapper)
    {
        _logger = logger;
        _historyRepository = historyRepository;
        _bookApi = bookApi;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BookModel>> GetBooksAsync()
    {
        var books = await _bookApi.GetBooksAsync();
        foreach (var book in books)
        {
            await _historyRepository.RegisterHistoryAsync(book.Title, book.Description);
        }
        return _mapper.Map<IEnumerable<BookModel>>(books);
    }

    public async Task<IEnumerable<string>> GetBookTagsAsync()
    {
        var tags = await _bookApi.GetBookTagsAsync();
        return tags;
    }

}