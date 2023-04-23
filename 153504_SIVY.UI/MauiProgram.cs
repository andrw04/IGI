using _153504_SIVY.MyApplication.Abstractions;
using _153504_SIVY.MyApplication.Services;
using _153504_SIVY.Domain.Abstractions;
using _153504_SIVY.Persistense.Repository;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace _153504_SIVY.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
#if DEBUG
            builder.Logging.AddDebug();
#endif
            SetupServices(builder.Services);
            return builder.Build();
        }

        private static void SetupServices(IServiceCollection services)
        {

            // Services
            services.AddSingleton<IUnitOfWork, FakeUnitOfWork>();
            services.AddSingleton<IPerformerService, PerformerService>();
            services.AddSingleton<ISongService, SongService>();

            // Pages


            // ViewModels
        }

    }
}