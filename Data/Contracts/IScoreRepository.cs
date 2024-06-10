using ScoreTracker.Data.Entities;

namespace ScoreTracker.Data.Contracts
{
    public interface IScoreRepository
    {
        Task CreateBulkAsync(IEnumerable<Score> scores);

        Task<IEnumerable<Score>> GetAllAsync();
    }
}
