using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ScoreTracker.Data.Contracts;
using ScoreTracker.Data.Entities;
using ScoreTracker.DTOs;

namespace ScoreTracker.ViewModels
{
    [QueryProperty("Players", "Players")]
    public partial class ScoreViewModel : ObservableObject
    {
        private readonly IScoreRepository _scoreRepository;

        public ScoreViewModel(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
            Scores = [];
        }

        [ObservableProperty]
        private ObservableCollection<PlayerDto> _players;

        [ObservableProperty]
        private ObservableCollection<ScoreDto> _scores;

        [RelayCommand]
        private void Clear()
        {
            foreach (var score in Scores)
            {
                score.Result = null;
            }
        }

        [RelayCommand]
        private void Submit()
        {
            var scores = Scores
                .Where(s => s.Result.HasValue)
                .Select(s => new Score
                {
                    Id = s.Id,
                    PlayerId = s.PlayerId,
                    CreatedAt = DateTime.UtcNow,
                    Result = s.Result.Value
                });
            
            _scoreRepository.CreateBulkAsync(scores);

            foreach (var score in Scores)
            {
                score.Result = null;
            }
        }
    }
}
