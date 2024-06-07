﻿using Microsoft.Extensions.Logging;
using ScoreTracker.Data.Contracts;
using ScoreTracker.Data.Repositories;
using ScoreTracker.Pages;
using ScoreTracker.ViewModels;

namespace ScoreTracker
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            builder.Services.AddTransient<StatisticsPage>();
            builder.Services.AddTransient<StatisticsViewModel>();

            builder.Services.AddTransient<ScorePage>();
            builder.Services.AddTransient<ScoreViewModel>();

            builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
            builder.Services.AddScoped<IScoreRepository, ScoreRepository>();

            return builder.Build();
        }
    }
}
