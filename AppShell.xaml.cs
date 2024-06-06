using ScoreTracker.Pages;

namespace ScoreTracker
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(StatisticsPage), typeof(StatisticsPage));
        }
    }
}
