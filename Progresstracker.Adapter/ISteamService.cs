using Progresstracker.Domain.DataObjects;
using Progresstracker.Application;

namespace Progresstracker.Adapter
{
    public interface ISteamService : IDataSource
    {
        Task<List<Achievement>> GetAchievementsAsync(string steamAppId);
    }
}