using ScoreTracker.Data.Contracts;
using ScoreTracker.ViewModels;

namespace ScoreTracker.Pages;

public partial class ScorePage : ContentPage
{
    public ScorePage(ScoreViewModel scoreViewModel)
    {
        InitializeComponent();
        BindingContext = scoreViewModel;
    }
}