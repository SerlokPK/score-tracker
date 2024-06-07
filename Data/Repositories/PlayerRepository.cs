using ScoreTracker.Data.Contracts;
using ScoreTracker.Data.Entities;

namespace ScoreTracker.Data.Repositories
{
    public class PlayerRepository : Context, IPlayerRepository
    {
        public async Task CreateAsync(Player player)
        {
            await SetupContextAsync();
            await Database.InsertAsync(player);
        }

        public async Task DeleteAsync(Guid id)
        {
            await SetupContextAsync();
            await Database.DeleteAsync<Player>(id);
            // TODO proveri da li kaskadno brise scores
        }

        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            await SetupContextAsync();
            return await Database.Table<Player>().ToListAsync();
        }
    }
}
