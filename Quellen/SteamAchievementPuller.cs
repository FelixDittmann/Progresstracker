using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json.Linq;
using Progresstracker.Configuration;
using Progresstracker.Database;
using Progresstracker.DataObjects;
using Progresstracker.Quellen;

public class SteamAchievementPuller : IDataSource
{
    private readonly string apiKey;
    private readonly string steamId;
    private HttpClient httpClient;
    private readonly ConfigurationSettingsHandler _config;
    private string _sourcename;

    public SteamAchievementPuller(ConfigurationSettingsHandler configuration, Profile profile)
    {
        apiKey = profile.SteamApiKey;
        steamId = profile.SteamProfileID;
        httpClient = new HttpClient();
        _config = configuration;
        _sourcename = "steam";
    }

    public async Task<List<Game>> GetOwnedGamesAsync(Profile profile)
    {
        string url = $"https://api.steampowered.com/IPlayerService/GetOwnedGames/v1/?key={apiKey}&steamid={steamId}&include_appinfo=1&include_played_free_games=1";

        HttpResponseMessage response = await httpClient.GetAsync(url);
        List<Game> ownedGames = new();

        if (response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(result);

            foreach (var game in json["response"]["games"])
            {
                long AppId = game["appid"].ToObject<long>();
                string Name = game["name"].ToString();
                int PlaytimeForever = game["playtime_forever"].ToObject<int>();
                string Source = _sourcename;
                var newGame = new Game(AppId, Name, PlaytimeForever, Source);
                    
                ownedGames.Add(newGame);
            }
        }
        else
        {
            Console.WriteLine($"Fehler: {response.StatusCode}");
        }
        return ownedGames;
    }

    public async Task<List<Achievement>> GetAchievementsAsync(long gameId, Profile profile)
    {
        string url = $"https://api.steampowered.com/ISteamUserStats/GetPlayerAchievements/v1/?key={apiKey}&steamid={steamId}&appid={gameId}";

        HttpResponseMessage response = await httpClient.GetAsync(url);
        List<Achievement> achievementList = new();
        if (response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(result);

            // Ergebnisse parsen und Errungenschaften anzeigen
            foreach (var achievement in json["playerstats"]["achievements"])
            {
                string name = achievement["apiname"].ToString();
                bool achieved = achievement["achieved"].ToObject<int>() == 1;
                string description = achievement["description"]?.ToString() ?? "No description available";
                achievementList.Add(new Achievement(name, description, achieved, gameId, profile.ProfileID, "steam"));
            }
        }
        else
        {
            Console.WriteLine($"Fehler: {response.StatusCode}");
        }
        return achievementList;
    }
}
