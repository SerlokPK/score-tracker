using ScoreTracker.Data.Entities;
using SQLite;

namespace ScoreTracker.Data
{
    public class Context
    {
        internal SQLiteAsyncConnection Database;

        internal async Task SetupContextAsync()
        {
            if (Database is not null)
            {
                return;
            }

            Database = new SQLiteAsyncConnection(DatabasePath, Flags);

            await Database.CreateTableAsync<Player>();
        }

        private const string DatabaseFilename = "score-tracker.db3";

        private const SQLiteOpenFlags Flags =
            SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;

        private static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}
