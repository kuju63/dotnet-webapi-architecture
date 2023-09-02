using LayeredArchitecture.Repositories.Models;

namespace LayeredArchitecture.Repositories
{
    public interface IHistoryRepository
    {
        Task RegisterHistoryAsync(string owner, string repositoryName);

        Task<History[]> GetHistoriesAsync();

        Task<History[]> GetHistoryPerOwnerAsync(string owner);
    }
}