public class SyncSteamAchievement
{
    private readonly IGameRepository _gameRepository;
    private readonly ISteamService _steamService;

    public SyncSteamAchievement(IGameRepository gameRepository, ISteamService steamService)
    {
        _gameRepository = gameRepository;
        _steamService = steamService;
    }

    public async Task ExecuteAsync(Guid gameId)
    {
        var game = await _gameRepository.GetByIdAsync(gameId);
        if (game == null || string.IsNullOrEmpty(game.SteamAppId)) return;

        var steamAchievements = await _steamService.GetAchievementsAsync(game.SteamAppId);

        game.Achievements.Clear();
        game.Achievements.AddRange(steamAchievements);

        await _gameRepository.UpdateAsync(game);
    }
}