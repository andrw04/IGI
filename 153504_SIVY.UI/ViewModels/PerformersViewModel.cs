using System.Collections.ObjectModel;
using _153504_SIVY.Domain.Entities;
using _153504_SIVY.MyApplication.Abstractions;
using _153504_SIVY.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace _153504_SIVY.UI.ViewModels
{
    public partial class PerformersViewModel : ObservableObject
    {
        private readonly IPerformerService _performerService;
        private readonly ISongService _songService;

        public ObservableCollection<Song> Songs { get; set; } = new();
        public ObservableCollection<Performer> Performers { get; set; } = new();

        [ObservableProperty]
        Performer selectedPerformer;

        [RelayCommand]
        async void UpdatePerformerList() => await GetPerformers();

        [RelayCommand]
        async void UpdateSongList() => await GetSongs();

        [RelayCommand]
        async void ShowDetails(Song song) => await GotoDetailsPage(song);

        [RelayCommand]
        async void NewGroup() => await GotoAddNewGroupPage();

        [RelayCommand]
        async void NewObject() => await GotoAddNewObjectPage();

        public PerformersViewModel(IPerformerService performerService, ISongService songService)
        {
            _performerService = performerService;
            _songService = songService;

            MessagingCenter.Subscribe<AddNewGroupViewModel>(this, "update", (sender) =>
            {
                UpdatePerformerList();
            });

            MessagingCenter.Subscribe<AddNewObjectViewModel>(this, "update", (sender) =>
            {
                UpdateSongList();
            });
        }

        public async Task GetPerformers()
        {
            var performers = await _performerService.GetAllAsync();
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Performers.Clear();
                foreach (var performer in performers)
                {
                    Performers.Add(performer);
                }
            });
        }

        public async Task GetSongs()
        {
            if (SelectedPerformer != null)
            {
                var songs = await _songService.GetPerformerSongs(SelectedPerformer.Id);
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    Songs.Clear();
                    foreach (var song in songs)
                    {
                        Songs.Add(song);
                    }
                });
            }
        }

        public async Task GotoDetailsPage(Song song)
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"Song", song }
            };
            await Shell.Current.GoToAsync(nameof(SongDetails), parameters);
        }

        public async Task GotoAddNewGroupPage()
        {
            await Shell.Current.GoToAsync(nameof(AddNewGroupPage));
        }

        public async Task GotoAddNewObjectPage()
        {
            if (SelectedPerformer != null)
            {
                IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"Performer", SelectedPerformer }
            };
                await Shell.Current.GoToAsync(nameof(AddNewObjectPage), parameters);
            }
        }
    }
}
