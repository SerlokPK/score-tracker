using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using ScoreTracker.Pages;

namespace ScoreTracker.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            Players = [];
        }

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(ShowStatisticsCommand))]
        private bool _shouldExecuteStatisticsButton;

        [ObservableProperty]
        private ObservableCollection<string> _players;

        [ObservableProperty]
        private string _addPlayerInput;

        [RelayCommand]
        private void AddPlayer()
        {
            if (string.IsNullOrWhiteSpace(AddPlayerInput))
            {
                return;
            }

            Players.Add(AddPlayerInput);
            AddPlayerInput = string.Empty;

            ShouldExecuteStatisticsButton = true;
        }

        [RelayCommand]
        private void RemovePayer(string player)
        {
            if (!Players.Contains(player))
            {
                return;
            }

            Players.Remove(player);
            ShouldExecuteStatisticsButton = Players.Any();
        }

        [RelayCommand(CanExecute = nameof(ShouldExecuteStatisticsButton))]
        private async Task ShowStatistics()
        {
            await Shell.Current.GoToAsync(nameof(StatisticsPage));
        }
    }
}
