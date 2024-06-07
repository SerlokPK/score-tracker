using ScoreTracker.Data.Entities;

namespace ScoreTracker.Data.Contracts
{
    public interface IPlayerRepository
    {
        Task CreateAsync(Player player);

        Task DeleteAsync(Guid id);

        Task<IEnumerable<Player>> GetAllAsync();
    }
}
