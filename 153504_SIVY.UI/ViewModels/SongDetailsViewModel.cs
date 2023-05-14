using _153504_SIVY.Domain.Entities;
using CommunityToolkit.Mvvm.ComponentModel;

namespace _153504_SIVY.UI.ViewModels
{
    [QueryProperty(nameof(Song), nameof(Song))]
    public partial class SongDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        Song song;
    }
}
