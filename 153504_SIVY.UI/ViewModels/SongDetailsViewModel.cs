using _153504_SIVY.Domain.Entities;
using _153504_SIVY.UI.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;

namespace _153504_SIVY.UI.ViewModels
{
    [QueryProperty(nameof(Song), nameof(Song))]
    public partial class SongDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        Song song;

        [RelayCommand]
        async void Edit() => await GotoEditObjectPage();

        public async Task GotoEditObjectPage()
        {
            IDictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "Song", song }
            };
            await Shell.Current.GoToAsync(nameof(EditObjectPage), parameters);
        }
    }
}
