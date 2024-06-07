using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using ScoreTracker.Data.Contracts;
using ScoreTracker.Data.Entities;

namespace ScoreTracker.ViewModels
{
    [QueryProperty("Players", "Players")]
    public partial class ScoreViewModel : ObservableObject
    {
        private readonly IScoreRepository _scoreRepository;

        public ScoreViewModel(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }

        [ObservableProperty]
        private ObservableCollection<Player> _players;
    }
}
