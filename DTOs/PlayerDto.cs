using CommunityToolkit.Mvvm.ComponentModel;

namespace ScoreTracker.DTOs
{
    public partial class PlayerDto : ObservableObject
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }

        [ObservableProperty] 
        private int? _score;
    }
}
