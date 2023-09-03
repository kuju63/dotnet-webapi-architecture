using LayeredArchitecture.Repositories.Models;

namespace LayeredArchitecture.Repositories
{
    public interface IHistoryRepository
    {
        Task RegisterHistoryAsync(string title, string description);

        Task<History[]> GetHistoriesAsync();

        Task<History[]> GetHistoryPerTitleAsync(string title);
    }
}