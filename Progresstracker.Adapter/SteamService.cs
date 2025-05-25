public class SteamService : ISteamService
{
    private readonly HttpClient _httpClient;

    public SteamService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Achievement>> GetAchievementsAsync(string steamAppId)
    {
        // Beispielcode (API-Key, Error-Handling auslassen):
        var url = $"https://api.steampowered.com/ISteamUserStats/GetPlayerAchievements/v1/?appid={steamAppId}&key=DEIN_API_KEY&steamid=USER_ID";
        var response = await _httpClient.GetStringAsync(url);
        
        // Deserialisieren und zu Domain-Modell mappen
        var result = new List<Achievement>();
        return result;
    }
}
