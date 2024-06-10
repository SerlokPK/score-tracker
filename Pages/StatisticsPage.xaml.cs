using ScoreTracker.Data.Contracts;
using ScoreTracker.ViewModels;

namespace ScoreTracker.Pages;

public partial class StatisticsPage : ContentPage
{
    private readonly StatisticsViewModel _statisticsViewModel;

    public StatisticsPage(StatisticsViewModel statisticsViewModel)
    {
        InitializeComponent();
        BindingContext = statisticsViewModel;

        _statisticsViewModel = statisticsViewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await _statisticsViewModel.LoadStatisticsAsync();
    }
}