using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ScoreTracker.Data.Entities
{
    public class Score
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        [ForeignKey(typeof(Player))]
        public Guid PlayerId { get; set; }

        public DateTime CreatedAt { get; set; }

        [ManyToOne]
        public Player Player { get; set; }
    }
}
