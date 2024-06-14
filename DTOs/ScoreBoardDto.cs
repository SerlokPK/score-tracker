using CommunityToolkit.Mvvm.ComponentModel;

namespace ScoreTracker.DTOs
{
    public partial class ScoreBoardDto : ObservableObject
    {
        public DateTime CreatedAt { get; set; }

        public IEnumerable<PlayerDto> Players { get; set; }
    }
}
