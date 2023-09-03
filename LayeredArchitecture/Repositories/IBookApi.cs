using LayeredArchitecture.Repositories.Models;

using Refit;

namespace LayeredArchitecture.Repositories;

public interface IBookApi
{
    [Get("/example/")]
    Task<IEnumerable<Book>> GetBooksAsync();

    [Get("/example/tags")]
    Task<IEnumerable<string>> GetBookTagsAsync();
}