public interface IGameRepository
{
	Task<Game?> GetByIdAsync(Guid id);
	Task<List<Game>> GetAllAsync();
	Task AddAsync(Game game);
	Task UpdateAsync(Game game);
}