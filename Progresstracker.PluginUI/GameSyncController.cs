using Progresstracker.Application;
using Progresstracker.Domain;

namespace Progresstracker.PluginUI.Controllers
{
    public class GameSyncController
    {
        private readonly SyncAchievementsUseCase _syncAchievementsUseCase;
        private readonly IGameRepository _gameRepo;
        private readonly IGameProgressCalculator _progressCalculator;

        public GameSyncController(
            SyncAchievementsUseCase syncAchievementsUseCase,
            IGameRepository gameRepo,
            IGameProgressCalculator progressCalculator)
        {
            _syncAchievementsUseCase = syncAchievementsUseCase;
            _gameRepo = gameRepo;
            _progressCalculator = progressCalculator;
        }

        public async Task<(Game game, double progress)> SyncGameAsync(Guid profileId, Guid gameId)
        {
            await _syncAchievementsUseCase.ExecuteAsync(profileId, gameId);
            var updatedGame = await _gameRepo.GetByIdAsync(gameId);
            var progress = _progressCalculator.Calculate(updatedGame);
            return (updatedGame, progress);
        }
    }
}
