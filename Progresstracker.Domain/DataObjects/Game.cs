public class Game
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public string SteamAppId { get; set; }
	public List<Achievement> Achievements { get; set; } = new();

	public double GetProgress() =>
		Achievements.Count == 0 ? 0 : Achievements.Count(a => a.IsUnlocked) * 100.0 / Achievements.Count;
}