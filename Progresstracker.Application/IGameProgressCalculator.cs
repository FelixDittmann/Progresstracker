using Progresstracker.Domain.DataObjects;

public interface IGameProgressCalculator
{
    double Calculate(Game game);
}

public class GameProgressCalculator : IGameProgressCalculator
{
    public double Calculate(Game game)
    {
        if (game.Achievements == null || game.Achievements.Count == 0)
            return 0;

        var unlocked = game.Achievements.Count(a => a.IsUnlocked);
        return unlocked * 100.0 / game.Achievements.Count;
    }
}
