public interface IAchievementRepository
{
    Task<List<Achievement>> GetByGameIdAsync(Guid gameId);
    Task UpdateAsync(Achievement achievement);
}