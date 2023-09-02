using LayeredArchitecture.Repositories.Models;

using Microsoft.EntityFrameworkCore;

namespace LayeredArchitecture.Repositories;

public class HistoryRepository : IHistoryRepository
{
    private readonly ILogger<HistoryRepository> _logger;
    private readonly HistoryContext _context;

    public HistoryRepository(ILogger<HistoryRepository> logger, HistoryContext context)
    {
        _logger = logger;
        _context = context;
    }

    public Task<History[]> GetHistoriesAsync() => _context.Histories.ToArrayAsync();

    public Task<History[]> GetHistoryPerOwnerAsync(string owner)
    {
        return _context.Histories.Where(h => h.Owner == owner).ToArrayAsync();
    }

    public async Task RegisterHistoryAsync(string owner, string repositoryName)
    {
        _ = await _context.Histories.AddAsync(new History
        {
            Owner = owner,
            RepositoryName = repositoryName,
            CreatedDateTime = DateTime.UtcNow,
            UpdatedDateTime = DateTime.UtcNow
        });

        var result = await _context.SaveChangesAsync();
        if (result == 1)
        {
            _logger.LogInformation($"History for {owner}/{repositoryName} registered.");
        }
        else
        {
            _logger.LogError($"History for {owner}/{repositoryName} not registered.");
        }
    }

}