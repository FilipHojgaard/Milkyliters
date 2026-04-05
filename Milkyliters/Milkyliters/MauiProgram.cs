using Microsoft.Extensions.Logging;
using Milkyliters.Data;
using Milkyliters.Services;
using Milkyliters.ViewModels;
using Milkyliters.Views;

namespace Milkyliters;

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
                fonts.AddFont("Nunito-Regular.ttf", "NunitoRegular");
                fonts.AddFont("Nunito-Bold.ttf", "NunitoBold");
            });

        // Services
        builder.Services.AddSingleton<DatabaseService>();
        builder.Services.AddSingleton<App>();
        builder.Services.AddSingleton<IFeedingService, FeedingService>();
        builder.Services.AddSingleton<IPooService, PooService>();

        // Pages
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<FeedingHistoryPage>();
        builder.Services.AddSingleton<PooHistoryPage>();

        // ViewModels
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<FeedingHistoryViewModel>();
        builder.Services.AddSingleton<PooHistoryViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
