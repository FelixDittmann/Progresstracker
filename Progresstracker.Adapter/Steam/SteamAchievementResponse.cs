 
using System.Text.Json.Serialization;

public class SteamAchievementResponse
{
    [JsonPropertyName("playerstats")]
    public PlayerStats Playerstats { get; set; }
}

public class PlayerStats
{
    [JsonPropertyName("achievements")]
    public List<SteamAchievement> Achievements { get; set; }
}

public class SteamAchievement
{
    [JsonPropertyName("apiname")]
    public string ApiName { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("achieved")]
    public int Achieved { get; set; }

    [JsonPropertyName("unlocktime")]
    public long UnlockTime { get; set; }
}
