using System.Collections.ObjectModel;
using System.Linq.Expressions;
using CommunityToolkit.Mvvm.ComponentModel;
using ScoreTracker.Data.Contracts;
using ScoreTracker.Data.Entities;
using ScoreTracker.DTOs;
using ScoreTracker.Extensions;

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

            SelectedDate = DateTime.Now;
            Items = [Day, Month, Year];
            SelectedItem = Items.First();
        }

        [ObservableProperty]
        private DateTime _selectedDate;

        [ObservableProperty]
        private IEnumerable<string> _items;

        [ObservableProperty]
        private string _selectedItem;

        [ObservableProperty]
        private ObservableCollection<PlayerDto> _players;

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
            var scores = await _scoreRepository.GetAsync(expression);
            var groupedScores = scores
                .GroupBy(x => x.PlayerId)
                .Select(group => new
                {
                    PlayerId = group.Key,
                    TotalResult = group.Sum(s => s.Result)
                })
                .ToList();

            foreach (var player in Players)
            {
                player.Score = groupedScores
                    .SingleOrDefault(x => x.PlayerId == player.Id)
                    ?.TotalResult;
            }
        }
    }
}
