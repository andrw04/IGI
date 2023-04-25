using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _153504_SIVY.Domain.Entities;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls;

namespace _153504_SIVY.UI.ViewModels
{
    [QueryProperty(nameof(Song), nameof(Song))]
    public partial class SongDetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        Song song;
    }
}
