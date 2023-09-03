using LayeredArchitecture.Services.Models;

namespace LayeredArchitecture.Services;

public interface IBookService
{
    Task<IEnumerable<BookModel>> GetBooksAsync();
    Task<IEnumerable<string>> GetBookTagsAsync();
}