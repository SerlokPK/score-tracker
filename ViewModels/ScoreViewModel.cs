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
            if (!Scores.Any(x => x.Result.HasValue))
            {
                return;
            }

            foreach (var score in Scores)
            {
                score.Result = null;
            }
        }

        [RelayCommand]
        private async Task Submit()
        {
            if (!Scores.Any(x => x.Result.HasValue))
            {
                return;
            }

            var date = DateTime.UtcNow;
            var scores = Scores
                .Where(s => s.Result.HasValue)
                .Select(s => new Score
                {
                    Id = Guid.NewGuid(),
                    PlayerId = s.PlayerId,
                    CreatedAt = date,
                    Result = s.Result.Value
                });
            
            await _scoreRepository.CreateBulkAsync(scores);

            foreach (var score in Scores)
            {
                score.Result = null;
            }
        }
    }
}
