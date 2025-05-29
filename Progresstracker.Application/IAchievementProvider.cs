using Progresstracker.Domain.DataObjects;

namespace Progresstracker.Application
{
	public interface IAchievementProvider
	{
		Task<List<Achievement>> GetAchievementsAsync(Game game, UserProfile profile);
	}
}

