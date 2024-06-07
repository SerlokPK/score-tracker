using ScoreTracker.Data.Contracts;
using ScoreTracker.Data.Entities;

namespace ScoreTracker.Data.Repositories
{
    public class ScoreRepository : Context, IScoreRepository
    {
        public async Task CreateAsync(Score score)
        {
            await SetupContextAsync();
            await Database.InsertAsync(score);
        }

        public async Task<IEnumerable<Score>> GetAllAsync()
        {
            await SetupContextAsync();
            return await Database.Table<Score>().ToListAsync();
        }
    }
}
