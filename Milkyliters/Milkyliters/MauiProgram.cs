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
            });

        // Services
        builder.Services.AddSingleton<DatabaseService>();
        builder.Services.AddSingleton<App>();
        builder.Services.AddSingleton<IFeedingService, FeedingService>();
        builder.Services.AddSingleton<IPooService, PooService>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
