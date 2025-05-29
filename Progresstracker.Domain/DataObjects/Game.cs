namespace Progresstracker.Domain.DataObjects
{
	public class Game
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
        public List<GameSourceIdentifier> ExternalIds { get; set; } = new();
        public List<Achievement> Achievements { get; set; } = new();

		public void AddAchievement(Achievement achievement)
		{
            if (achievement == null) throw new ArgumentNullException(nameof(achievement));
            if (Achievements.Any(a => a.Id == achievement.Id)) return;
            achievement.GameId = Id;
            Achievements.Add(achievement);
        }

        public void AddAchievements(IEnumerable<Achievement> achievements)
        {
            if (achievements == null) throw new ArgumentNullException(nameof(achievements));
            foreach (var achievement in achievements)
            {
                AddAchievement(achievement);
            }
        }
    }
}