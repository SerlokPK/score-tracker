using ScoreTracker.Data.Entities;

namespace ScoreTracker.Data.Contracts
{
    public interface IScoreRepository
    {
        Task CreateAsync(Score score);

        Task<IEnumerable<Score>> GetAllAsync();
    }
}
