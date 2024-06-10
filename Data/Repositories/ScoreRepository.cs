﻿using ScoreTracker.Data.Contracts;
using ScoreTracker.Data.Entities;

namespace ScoreTracker.Data.Repositories
{
    public class ScoreRepository : Context, IScoreRepository
    {
        public async Task CreateBulkAsync(IEnumerable<Score> scores)
        {
            await SetupContextAsync();
            await Database.InsertAllAsync(scores);
        }

        public async Task<IEnumerable<Score>> GetAllAsync()
        {
            await SetupContextAsync();
            return await Database.Table<Score>().ToListAsync();
        }
    }
}
