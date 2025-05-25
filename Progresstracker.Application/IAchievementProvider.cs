public interface IAchievementProvider
{
	Task<List<Achievement>> GetAchievementsAsync(string externalId, UserProfile profile);
}
