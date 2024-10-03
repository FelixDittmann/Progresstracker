using Newtonsoft.Json.Linq;
using Progresstracker.DataObjects;

public class SteamAchievementPuller
{
    private readonly string apiKey;
    private readonly string steamId;
    private string? appId;
    private HttpClient httpClient;

    public SteamAchievementPuller(string apikey, string steamid, HttpClient client, string? appid)
    {
        apiKey = apikey;
        steamId = steamid;
        appId = appid;
        httpClient = client;
    }

    public async Task<List<Spiel>> GetOwnedGamesAsync()
    {
        string url = $"https://api.steampowered.com/IPlayerService/GetOwnedGames/v1/?key={apiKey}&steamid={steamId}&include_appinfo=1&include_played_free_games=1";

        HttpResponseMessage response = await httpClient.GetAsync(url);
        List<Spiel> ownedGames = new();

        if (response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(result);

            foreach (var game in json["response"]["games"])
            {
                var newGame = new Spiel
                {
                    AppId = game["appid"].ToObject<int>(),
                    Name = game["name"].ToString(),
                    Playtime = game["playtime_forever"].ToObject<int>(),
                    Achievements = new List<Progresstracker.Database.Achievement>()
                };
                ownedGames.Add(newGame);
            }
        }
        else
        {
            Console.WriteLine($"Fehler: {response.StatusCode}");
        }
        return ownedGames;
    }

    public async Task GetPlayerAchievementsAsync(string gameId)
    {
        {
            string url = $"https://api.steampowered.com/ISteamUserStats/GetPlayerAchievements/v1/?key={apiKey}&steamid={steamId}&appid={gameId}";

            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(result);

                // Ergebnisse parsen und Errungenschaften anzeigen
                foreach (var achievement in json["playerstats"]["achievements"])
                {
                    string name = achievement["apiname"].ToString();
                    bool achieved = achievement["achieved"].ToObject<int>() == 1;
                    Console.WriteLine($"Errungenschaft: {name}, Freigeschaltet: {achieved}");
                }
            }
            else
            {
                Console.WriteLine($"Fehler: {response.StatusCode}");
            }
        }
    }
}
