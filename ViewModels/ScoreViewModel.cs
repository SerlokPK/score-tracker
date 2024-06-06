using CommunityToolkit.Mvvm.ComponentModel;
using ScoreTracker.Data.Entities;

namespace ScoreTracker.ViewModels
{
    [QueryProperty("Players", "Players")]
    public partial class ScoreViewModel : ObservableObject
    {
        [ObservableProperty]
        private IEnumerable<Player> _players;
    }
}
