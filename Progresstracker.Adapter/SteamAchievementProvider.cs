using Progresstracker.Application;
using Progresstracker.Domain.DataObjects;

public class SteamAchievementProvider : IAchievementProvider
{
	private readonly HttpClient _httpClient;

	public SteamAchievementProvider(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<List<Achievement>> GetAchievementsAsync(string steamAppId, UserProfile user)
	{
		if (string.IsNullOrEmpty(user.SteamApiKey) || string.IsNullOrEmpty(user.SteamProfileID))
			return new();

		var url = $"https://api.steampowered.com/ISteamUserStats/GetPlayerAchievements/v1/?" +
					$"appid={steamAppId}&key={user.SteamApiKey}&steamid={user.SteamProfileID}";

		var json = await _httpClient.GetStringAsync(url);

		return new List<Achievement>();
	}
}
