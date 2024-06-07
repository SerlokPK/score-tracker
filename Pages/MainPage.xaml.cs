using ScoreTracker.Data.Contracts;
using ScoreTracker.ViewModels;

namespace ScoreTracker
{
    public partial class MainPage : ContentPage
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly MainViewModel _mainViewModel;

        public MainPage(MainViewModel mainViewModel, IPlayerRepository playerRepository)
        {
            InitializeComponent();
            BindingContext = mainViewModel;

            _playerRepository = playerRepository;
            _mainViewModel = mainViewModel;
        }

        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            base.OnNavigatedTo(args);

            _mainViewModel.Players.Clear();

            var players = await _playerRepository.GetAllAsync();
            foreach (var player in players)
            {
                _mainViewModel.Players.Add(player);
            }

            _mainViewModel.ShouldDisplayPlayerButtons = _mainViewModel.Players.Any();
        }
    }

}
