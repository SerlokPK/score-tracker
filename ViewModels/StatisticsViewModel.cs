using CommunityToolkit.Mvvm.ComponentModel;
using ScoreTracker.Data.Contracts;
using ScoreTracker.Data.Entities;
using ScoreTracker.DTOs;
using ScoreTracker.Extensions;
using System.Collections.ObjectModel;
using System.Linq.Expressions;

namespace ScoreTracker.ViewModels
{
    [QueryProperty("Players", "Players")]
    public partial class StatisticsViewModel : ObservableObject
    {
        private readonly IScoreRepository _scoreRepository;

        private const string Day = nameof(Day);
        private const string Month = nameof(Month);
        private const string Year = nameof(Year);

        public StatisticsViewModel(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;

            ScoreSum = [];
            ScoreBoard = [];
            SelectedDate = DateTime.Now;
            Items = [Day, Month, Year];
            IsScoreBoardVisible = true;
        }

        [ObservableProperty]
        private DateTime _selectedDate;

        [ObservableProperty]
        private IEnumerable<string> _items;

        [ObservableProperty]
        private string _selectedItem;

        [ObservableProperty]
        private ObservableCollection<PlayerDto> _players;

        [ObservableProperty]
        private ObservableCollection<PlayerDto> _scoreSum;

        [ObservableProperty]
        private ObservableCollection<ScoreBoardDto> _scoreBoard;

        [ObservableProperty]
        private bool _isScoreBoardVisible;

        [ObservableProperty]
        private bool _isScoreSumVisible;

        public async Task LoadStatisticsAsync()
        {
            DateTime start;
            DateTime end;
            switch (SelectedItem)
            {
                case Day:
                    start = SelectedDate.GetAbsoluteStart();
                    end = SelectedDate.GetAbsoluteEnd();
                    break;
                case Month:
                    start = SelectedDate.GetAbsoluteStartMonth();
                    end = SelectedDate.GetAbsoluteEndMonth();
                    break;
                case Year:
                    start = SelectedDate.GetAbsoluteStartYear();
                    end = SelectedDate.GetAbsoluteEndYear();
                    break;
                default:
                    start = SelectedDate.GetAbsoluteStart();
                    end = SelectedDate.GetAbsoluteEnd();
                    break;
            }

            Expression<Func<Score, bool>> expression = score =>
                start <= score.CreatedAt &&
                end > score.CreatedAt;
            var scores = (await _scoreRepository.GetAsync(expression)).ToList();

            SetScoreSum(scores);
            SetScoreBoard(scores);
        }

        private void SetScoreBoard(IEnumerable<Score> scores)
        {
            var groupByDate = scores
                .GroupBy(x => x.CreatedAt)
                .Select(group => new ScoreBoardDto
                {
                    CreatedAt = group.Key,
                    Players = group.OrderBy(x => x.Result).Select(x => new PlayerDto
                    {
                        Name = Players.First(p => p.Id == x.PlayerId).Name,
                        Score = group.First(g => g.PlayerId == x.PlayerId).Result
                    }).ToList()
                })
                .OrderByDescending(x => x.CreatedAt)
                .ToList();

            ScoreBoard = [];
            foreach (var scoreBoard in groupByDate)
            {
                // TODO citja iz appsettings
                //scoreBoard.Players = scoreBoard.Players
                //    .OrderBy(x => x.Score)
                //    .ToList();

                var previousScore = 0;
                var tablePlace = 0;
                foreach (var player in scoreBoard.Players)
                {
                    var currentScore = player.Score.Value;
                    player.Score = currentScore == previousScore ? tablePlace : ++tablePlace;

                    previousScore = currentScore;
                }

                ScoreBoard.Add(scoreBoard);
            }

            //groupByDate.SelectMany(x => x.Players).Select(p =>
            //{

            //});
        }

        private void SetScoreSum(IEnumerable<Score> scores)
        {
            var groupByPlayer = scores
                .GroupBy(x => x.PlayerId)
                .Select(group => new PlayerDto
                {
                    Name = Players.First(p => p.Id == group.Key).Name,
                    Score = group.Sum(s => s.Result)
                })
                .ToList();

            ScoreSum = [];
            foreach (var player in groupByPlayer)
            {
                ScoreSum.Add(player);
            }
        }
    }
}
