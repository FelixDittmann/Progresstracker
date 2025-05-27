using Progresstracker.Application;
using Progresstracker.Domain;
using Progresstracker.Domain.DataObjects;

namespace Progresstracker.PluginUI
{
    public class GameSyncController
    {
        private readonly SyncAchievement _syncAchievementsUseCase;
        private readonly IGameRepository _gameRepo;
        private readonly IGameProgressCalculator _progressCalculator;

        public GameSyncController(
            SyncAchievement syncAchievementsUseCase,
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
