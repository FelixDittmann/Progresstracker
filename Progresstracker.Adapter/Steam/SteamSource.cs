using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Progresstracker.Domain.DataObjects;

namespace Progresstracker.Adapter.Steam
{
    public class SteamSource : ISteamSource
    {
        private readonly HttpClient _httpClient;
        public SteamSource(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<Achievement>> GetAchievementsAsync(SteamGameInfo steamGame, UserProfile profile)
        {
            var url = $"https://api.steampowered.com/ISteamUserStats/GetPlayerAchievements/v1/?" +
              $"appid={steamGame.AppId}&key={profile.SteamApiKey}&steamid={profile.SteamProfileID}";

            var json = await _httpClient.GetStringAsync(url);
            var result = JsonSerializer.Deserialize<SteamAchievementResponse>(json);

            return result?.Playerstats?.Achievements.Select(a => new Achievement
            {
                Id = Guid.NewGuid(),
                Title = a.ApiName,
                Description = a.Description,
                IsUnlocked = a.Achieved == 1,
                UnlockDate = a.UnlockTime > 0 ? DateTimeOffset.FromUnixTimeSeconds(a.UnlockTime).DateTime : null,
                GameId = Guid.Empty
            }).ToList() ?? [];
        }

        public Task<List<Achievement>> GetAchievementsAsync(Game game, UserProfile profile)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SteamGameInfo>> GetOwnedGamesAsync(UserProfile profile)
        {
            var url = $"https://api.steampowered.com/IPlayerService/GetOwnedGames/v1/?" +
                      $"key={profile.SteamApiKey}&steamid={profile.SteamProfileID}&include_appinfo=true";

            var json = await _httpClient.GetStringAsync(url);
            var response = JsonSerializer.Deserialize<SteamOwnedGamesResponse>(json);

            return response?.Response?.Games?.Select(g => new SteamGameInfo
            {
                AppId = g.AppId.ToString(),
                Name = g.Name
            }).ToList() ?? [];
        }

    }
}
