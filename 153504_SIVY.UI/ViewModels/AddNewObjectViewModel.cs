using _153504_SIVY.Domain.Entities;
using _153504_SIVY.MyApplication.Abstractions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace _153504_SIVY.UI.ViewModels
{
    [QueryProperty(nameof(Performer), nameof(Performer))]
    public partial class AddNewObjectViewModel : ObservableObject
    {
        private ISongService _songService;

        [ObservableProperty]
        Performer performer;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        string genre;

        [ObservableProperty]
        string language;

        [ObservableProperty]
        string duration;

        [RelayCommand]
        async void AddSong() => await AddNewSong();

        public AddNewObjectViewModel(ISongService songService)
        {
            _songService = songService;
        }

        public async Task AddNewSong()
        {
            double _duration;

            if (Performer != null &&
                double.TryParse(duration, out _duration) &&
                !string.IsNullOrEmpty(name) &&
                !string.IsNullOrEmpty(genre) &&
                !string.IsNullOrEmpty(language) &&
                !string.IsNullOrEmpty(duration))
            {
                Random r = new Random();
                Song song = new Song()
                {
                    Name = name,
                    Genre = genre,
                    Language = language,
                    Duration = _duration,
                    Performer = performer,
                    Position = r.Next(0, 100)

                };

                await _songService.AddAsync(song);

                MessagingCenter.Send(this, "update");
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
