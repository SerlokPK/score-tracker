using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ScoreTracker.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
            Players = [];
        }

        [ObservableProperty]
        private ObservableCollection<string> players;

        [ObservableProperty]
        private string addPlayerInput;

        [RelayCommand]
        private void AddPlayer()
        {
            if (string.IsNullOrWhiteSpace(AddPlayerInput))
            {
                return;
            }

            Players.Add(AddPlayerInput);
            AddPlayerInput = string.Empty;
        }
    }
}
