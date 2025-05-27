namespace Progresstracker.Domain.DataObjects
{
	public class Game
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string? ExternalServiceId { get; set; }

		public List<Achievement> Achievements { get; set; } = new();
	}
}