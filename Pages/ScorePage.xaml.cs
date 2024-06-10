using ScoreTracker.DTOs;
using ScoreTracker.ViewModels;

namespace ScoreTracker.Pages;

public partial class ScorePage : ContentPage
{
    private readonly ScoreViewModel _scoreViewModel;

    public ScorePage(ScoreViewModel scoreViewModel)
    {
        InitializeComponent();
        BindingContext = scoreViewModel;

        _scoreViewModel = scoreViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        foreach (var player in _scoreViewModel.Players)
        {
            _scoreViewModel.Scores.Add(new ScoreDto
            {
                PlayerName = player.Name,
                PlayerId = player.Id,
                Id = Guid.NewGuid()
            });
        }
    }
}