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

    public Task<History[]> GetHistoryPerTitleAsync(string title)
    {
        return _context.Histories.Where(h => h.Title == title).ToArrayAsync();
    }

    public async Task RegisterHistoryAsync(string title, string description)
    {
        _ = await _context.Histories.AddAsync(new History
        {
            Title = title,
            Description = description,
            CreatedDateTime = DateTime.UtcNow,
            UpdatedDateTime = DateTime.UtcNow
        });

        var result = await _context.SaveChangesAsync();
        if (result == 1)
        {
            _logger.LogInformation($"History for {title}/{description} registered.");
        }
        else
        {
            _logger.LogError($"History for {title}/{description} not registered.");
        }
    }

}