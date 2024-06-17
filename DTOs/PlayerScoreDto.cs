using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ScoreTracker.DTOs
{
    public partial class PlayerScoreDto : ObservableObject
    {
        public string Name { get; set; }

        [ObservableProperty] 
        private ObservableCollection<PositionDto> _positions;
    }
}
