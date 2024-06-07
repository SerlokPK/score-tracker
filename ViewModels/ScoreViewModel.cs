using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ScoreTracker.Data.Entities;

namespace ScoreTracker.ViewModels
{
    [QueryProperty("Players", "Players")]
    public partial class ScoreViewModel : ObservableObject
    {
        public ScoreViewModel()
        {
            
        }

        [ObservableProperty]
        private ObservableCollection<Player> _players;

        [ObservableProperty]
        private ObservableCollection<Score> _scores;
    }
}
