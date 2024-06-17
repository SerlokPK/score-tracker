using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ScoreTracker.DTOs
{
    public partial class PlayerScoreDto : ObservableObject
    {
        public string Name { get; set; }

        [ObservableProperty] 
        private int _firstPlace;

        [ObservableProperty]
        private int _secondPlace;

        [ObservableProperty]
        private int _thirdPlace;
    }
}
