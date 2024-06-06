using ScoreTracker.ViewModels;

namespace ScoreTracker.Pages;

public partial class StatisticsPage : ContentPage
{
    public StatisticsPage(StatisticsViewModel statisticsViewModel)
    {
        InitializeComponent();
        BindingContext = statisticsViewModel;
    }
}