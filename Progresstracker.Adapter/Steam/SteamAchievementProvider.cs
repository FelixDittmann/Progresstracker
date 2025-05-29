using System.Text.Json;
using Progresstracker.Application;
using Progresstracker.Domain;
using Progresstracker.Domain.DataObjects;

public class SteamAchievementProvider : IAchievementProvider
{
	private readonly HttpClient _httpClient;

	public SteamAchievementProvider(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<List<Achievement>> GetAchievementsAsync(Game game, UserProfile user)
	{
		if (string.IsNullOrEmpty(user.SteamApiKey) || string.IsNullOrEmpty(user.SteamProfileID))
			return new();

		var url = $"https://api.steampowered.com/ISteamUserStats/GetPlayerAchievements/v1/?" +
					$"appid={steamAppId}&key={user.SteamApiKey}&steamid={user.SteamProfileID}";

		var json = await _httpClient.GetStringAsync(url);

        var steamResponse = JsonSerializer.Deserialize<SteamApiResponse>(json);

        if (steamResponse?.Playerstats?.Achievements == null)
            return new List<Achievement>();

        return steamResponse.Playerstats.Achievements.Select(a => new Achievement
        {
            Id = Guid.NewGuid(),
            Title = a.ApiName,
            Description = a.Description,
            IsUnlocked = a.Achieved == 1,
            UnlockDate = a.UnlockTime > 0 ? DateTimeOffset.FromUnixTimeSeconds(a.UnlockTime).DateTime : null,
            GameId = game.Id
        }).ToList();
    }
}
