using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using ScoreTracker.Data.Contracts;
using ScoreTracker.Data.Entities;
using ScoreTracker.DTOs;
using ScoreTracker.Pages;

namespace ScoreTracker.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IPlayerRepository _playerRepository;

        public MainViewModel(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository ?? throw new ArgumentNullException(nameof(playerRepository));

            Players = [];
        }

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ShowStatisticsCommand))]
        [NotifyCanExecuteChangedFor(nameof(AddScoreCommand))]
        private bool _shouldDisplayPlayerButtons;

        [ObservableProperty]
        private ObservableCollection<PlayerDto> _players;

        [ObservableProperty]
        private string _addPlayerInput;

        [RelayCommand]
        private void AddPlayer()
        {
            if (string.IsNullOrWhiteSpace(AddPlayerInput))
            {
                return;
            }

            var player = new Player(AddPlayerInput);
            var playerDto = new PlayerDto
            {
                Id = player.Id,
                CreatedAt = player.CreatedAt,
                Name = player.Name
            };

            Players.Add(playerDto);
            _playerRepository.CreateAsync(player);

            AddPlayerInput = string.Empty;
            ShouldDisplayPlayerButtons = true;
        }

        [RelayCommand]
        private void RemovePayer(PlayerDto player)
        {
            if (!Players.Contains(player))
            {
                return;
            }

            Players.Remove(player);
            _playerRepository.DeleteAsync(player.Id);

            ShouldDisplayPlayerButtons = Players.Any();
        }

        [RelayCommand(CanExecute = nameof(ShouldDisplayPlayerButtons))]
        private async Task ShowStatistics()
        {
            await Shell.Current.GoToAsync(nameof(StatisticsPage));
        }

        [RelayCommand(CanExecute = nameof(ShouldDisplayPlayerButtons))]
        private async Task AddScore()
        {
            var container = new Dictionary<string, object>
            {
                ["Players"] = Players
            };

            await Shell.Current.GoToAsync(nameof(ScorePage), container);
        }
    }
}
