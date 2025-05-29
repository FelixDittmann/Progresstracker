using Progresstracker.Domain.DataObjects;
using Progresstracker.Application;

namespace Progresstracker.Adapter.Steam
{
    public interface ISteamSource : IDataSource
    {
        Task<List<SteamGameInfo>> GetOwnedGamesAsync(UserProfile profile);
        Task<List<Achievement>> GetAchievementsAsync(SteamGameInfo steamGame, UserProfile profile);
    }
}