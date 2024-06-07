using ScoreTracker.Data.Contracts;
using ScoreTracker.ViewModels;

namespace ScoreTracker.Pages;

public partial class ScorePage : ContentPage
{
    private readonly ScoreViewModel _scoreViewModel;
    private readonly IScoreRepository _scoreRepository;

    public ScorePage(ScoreViewModel scoreViewModel, IScoreRepository scoreRepository)
    {
        InitializeComponent();
        BindingContext = scoreViewModel;

        _scoreViewModel = scoreViewModel;
        _scoreRepository = scoreRepository;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        _scoreViewModel.Scores.Clear();

        var players = await _scoreRepository.GetAllAsync();
        foreach (var player in players)
        {
            _scoreViewModel.Scores.Add(player);
        }
    }
}