using Progresstracker.Domain;
using Progresstracker.Domain.Repository_Interfaces;

namespace Progresstracker.Application
{
    public class SyncAchievement
    {
        private readonly IUserProfileRepository _userRepo;
        private readonly IGameRepository _gameRepo;
        private readonly IAchievementProvider _achievementProvider;

        public SyncAchievement(
            IUserProfileRepository userRepo,
            IGameRepository gameRepo,
            IAchievementProvider achievementProvider)
        {
            _userRepo = userRepo;
            _gameRepo = gameRepo;
            _achievementProvider = achievementProvider;
        }

        public async Task ExecuteAsync(Guid profileId, Guid gameId)
        {
            var user = await _userRepo.GetByIdAsync(profileId);
            var game = await _gameRepo.GetByIdAsync(gameId);

            if (user != null && game != null && game.ExternalIds != null)
            {
                var newAchievements = await _achievementProvider.GetAchievementsAsync(game, user);

                game.Achievements.Clear();
                game.Achievements.AddRange(newAchievements);
                await _gameRepo.UpdateAsync(game);
            }
        }
    }
}
