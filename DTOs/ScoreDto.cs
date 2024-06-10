using CommunityToolkit.Mvvm.ComponentModel;

namespace ScoreTracker.DTOs
{
    public partial class ScoreDto : ObservableObject
    {
        public Guid Id { get; set; }

        public Guid PlayerId { get; set; }

        public string PlayerName { get; set; }

        public DateTime CreatedAt { get; set; }

        [ObservableProperty] 
        private int? _result;
    }
}
