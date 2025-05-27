using Progresstracker.Domain.DataObjects;

namespace Progresstracker.Application
{
	public interface IAchievementProvider
	{
		Task<List<Achievement>> GetAchievementsAsync(string externalId, UserProfile profile);
	}
}

