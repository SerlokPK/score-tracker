namespace ScoreTracker.DTOs
{
    public class PlayerDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? Score { get; set; }
    }
}
