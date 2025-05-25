public class Achievement
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsUnlocked { get; set; }
    public DateTime? UnlockDate { get; set; }

    public Guid GameId { get; set; }
}
