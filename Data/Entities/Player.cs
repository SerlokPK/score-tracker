using SQLite;

namespace ScoreTracker.Data.Entities
{
    public class Player
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public Player()
        {
            
        }

        public Player(string name)
        {
            Name = name;
            CreatedAt = DateTime.UtcNow;
            Id = Guid.NewGuid();
        }
    }
}
