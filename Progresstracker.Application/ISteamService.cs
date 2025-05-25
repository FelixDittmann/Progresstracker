public interface ISteamService
{
    Task<List<Achievement>> GetAchievementsAsync(string steamAppId);
}
