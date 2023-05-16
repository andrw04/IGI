using _153504_SIVY.Domain.Entities;
using _153504_SIVY.MyApplication.Abstractions;
using _153504_SIVY.MyApplication.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System;
using System.Text;

namespace _153504_SIVY.UI.ViewModels
{
    [QueryProperty(nameof(Song), nameof(Song))]
    public partial class EditObjectViewModel : ObservableObject
    {
        ISongService songService;
        IPerformerService performerService;

        public ObservableCollection<Performer> Performers { get; set; } = new();

        [ObservableProperty]
        Performer selectedPerformer;

        [ObservableProperty]
        Song song;

        [RelayCommand]
        public async void EditSong() => await Edit();

        [RelayCommand]
        async void UpdatePerformerList() => await GetPerformers();

        [RelayCommand]
        async void ChooseImage() => await LoadImage();
        public EditObjectViewModel(ISongService songService, IPerformerService performerService)
        {
            this.songService = songService;
            this.performerService = performerService;
        }

        public async Task Edit()
        {
            if (SelectedPerformer != null)
            {
                var p = song.Performer;
                p.Songs.Remove(song);
                await performerService.UpdateAsync(p);
                song.Performer = SelectedPerformer;
            }
            await songService.UpdateAsync(song);
            MessagingCenter.Send(this, "update");
            await Shell.Current.GoToAsync("../..");
        }

        public async Task GetPerformers()
        {
            var performers = await performerService.GetAllAsync();
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                Performers.Clear();
                foreach (var performer in performers)
                {
                    Performers.Add(performer);
                }
            });
        }

        public async Task LoadImage()
        {
            var options = new PickOptions
            {
                PickerTitle = "Pick Image Please",
                FileTypes = FilePickerFileType.Images
            };

            var result = await FilePicker.Default.PickAsync(options);
            if (result != null && song != null)
            {
                // Generate FileName
                string targetFileName = song.Id.ToString();
                int dotIndex = result.FileName.LastIndexOf('.');
                string fileFormat = result.FileName.Substring(dotIndex);
                targetFileName += fileFormat;

                // Generate path
                string targetFile = Path.Combine(FileSystem.Current.AppDataDirectory, targetFileName);

                // Copy image to appdata
                using var stream = await result.OpenReadAsync();
                using FileStream outputStream = File.OpenWrite(targetFile);
                await stream.CopyToAsync(outputStream);
            }

            MessagingCenter.Send(this, "update");

            // await Shell.Current.GoToAsync("../..");
        }
    }
}
