using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace BookAPP;

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
            })
            .UseMauiCommunityToolkit();

#if DEBUG
        builder.Logging.AddDebug();
#endif
        AddBookServices(builder.Services);

        return builder.Build();
    }

    private static IServiceCollection AddBookServices(IServiceCollection services)
    {
        services.AddSingleton<BookService>();

        services.AddSingleton<HomePage>()
                .AddSingleton<HomeViewModel>();

        services.AddTransientWithShellRoute<AllBooksPage, AllBookViewModel>(nameof(AllBooksPage));

        services.AddTransientWithShellRoute<DetailPage, DetailsViewModel>(nameof(DetailPage));

        services.AddSingleton<CartViewModel>();
        services.AddTransient<CartPage>();
        return services;
    }
}
