using System.Text.Json;
using Progresstracker.Application;
using Progresstracker.Domain.DataObjects;

namespace Progresstracker.Adapter.Steam
{
    public class SteamAchievementProvider : IAchievementProvider
    {
        private readonly SteamSource _steamSource;

        public SteamAchievementProvider(SteamSource steamSource)
        {
            _steamSource = steamSource;
        }

        public async Task<List<Achievement>> GetAchievementsAsync(Game game, UserProfile profile)
        {
            if (game is not SteamGameInfo)
                throw new ArgumentException("Invalid game type");
            if (string.IsNullOrWhiteSpace(profile.SteamApiKey) || string.IsNullOrWhiteSpace(profile.SteamProfileID))
                return [];

            SteamGameInfo steamGame = (SteamGameInfo)game;

            var url = $"https://api.steampowered.com/ISteamUserStats/GetPlayerAchievements/v1/?" +
                      $"appid={steamGame.AppId}&key={profile.SteamApiKey}&steamid={profile.SteamProfileID}";

            _steamSource.ConnectToDataSource(url);
            var json = await _steamSource.GetData();

            var result = JsonSerializer.Deserialize<SteamAchievementResponse>(json);

            return result?.Playerstats?.Achievements.Select(a => new Achievement
            {
                Id = Guid.NewGuid(),
                Title = a.ApiName,
                Description = a.Description,
                IsUnlocked = a.Achieved == 1,
                UnlockDate = a.UnlockTime > 0
                    ? DateTimeOffset.FromUnixTimeSeconds(a.UnlockTime).DateTime
                    : null,
                GameId = Guid.Parse(steamGame.AppId),
            }).ToList() ?? [];
        }
    }
}
