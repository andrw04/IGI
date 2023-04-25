using _153504_SIVY.MyApplication.Abstractions;
using _153504_SIVY.MyApplication.Services;
using _153504_SIVY.Domain.Abstractions;
using _153504_SIVY.Persistense.Repository;
using _153504_SIVY.UI.ViewModels;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using _153504_SIVY.UI.Pages;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using _153504_SIVY.Persistense.Data;
using Microsoft.EntityFrameworkCore;
using _153504_SIVY.Domain.Entities;

namespace _153504_SIVY.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            string settingsStream = "_153504_SIVY.UI.appsettings.json";

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream(settingsStream);
            builder.Configuration.AddJsonStream(stream);

#if DEBUG
            builder.Logging.AddDebug();
#endif
            AddDbContext(builder);
            SetupServices(builder.Services);
            SeedData(builder.Services);

            return builder.Build();
        }

        public async static void SeedData(IServiceCollection services)
        {
            using var provider = services.BuildServiceProvider();

            var unitOfWork = provider.GetService<IUnitOfWork>();

            await unitOfWork.RemoveDatabaseAsync();
            await unitOfWork.CreateDatabaseAsync();

            #region add_performers
            var performer1 = new Performer()
            {
                Name = "Rammstein",
                DebuteDate = 1994,
                Nationality = "Germany"
            };

            var performer2 = new Performer()
            {
                Name = "Linkin Park",
                DebuteDate = 1996,
                Nationality = "USA"
            };

            IReadOnlyList<Performer> performers = new List<Performer>() { performer1, performer2 };
            foreach(var performer in performers)
            {
                await unitOfWork.PerformerRepository.AddAsync(performer);
            }
            await unitOfWork.SaveAllAsync();
            #endregion

            #region add_songs
            var song1 = new Song()
            {
                Name = "Faint",
                Genre = "Rock",
                Language = "English",
                Position = 2,
                Performer = performer2,
                Duration = 2.48
            };

            var song2 = new Song()
            {
                Name = "In the End",
                Genre = "Rock",
                Language = "English",
                Position = 10,
                Performer = performer2,
                Duration = 3.38
            };

            IReadOnlyList<Song> songs = new List<Song>() { song1, song2 };
            foreach(var song in songs)
            {
                await unitOfWork.SongRepository.AddAsync(song);
            }
            await unitOfWork.SaveAllAsync();
            #endregion
        }
        private static void SetupServices(IServiceCollection services)
        {

            // Services
            services.AddSingleton<IUnitOfWork, EfUnitOfWork>();
            services.AddSingleton<IPerformerService, PerformerService>();
            services.AddSingleton<ISongService, SongService>();

            // Pages
            services.AddSingleton<Performers>();

            // ViewModels
            services.AddSingleton<PerformersViewModel>();
        }

        private static void AddDbContext(MauiAppBuilder builder)
        {
            var connStr = builder.Configuration.GetConnectionString("DefaultConnection");

            string dataDirectory = String.Empty;

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseMySql(connStr, new MySqlServerVersion(new Version(8, 0, 30))).
                Options;

            builder.Services.AddSingleton<AppDbContext>((s) => new AppDbContext(options));
        }

    }
}