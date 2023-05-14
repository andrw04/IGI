using _153504_SIVY.MyApplication.Abstractions;
using _153504_SIVY.Domain.Entities;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace _153504_SIVY.UI.ViewModels
{
    public partial class AddNewGroupViewModel : ObservableObject
    {
        [ObservableProperty]
        string name;
        [ObservableProperty]
        string nationality;
        [ObservableProperty]
        string debute;

        IPerformerService _performerService;
        public AddNewGroupViewModel(IPerformerService service)
        {
            _performerService = service;
        }

        [RelayCommand]
        async void Create() => await CreateAndUpdate();

        public async Task CreateAndUpdate()
        {
            var _name = name;
            var _nationality = nationality;
            int _debute;

            if (int.TryParse(debute, out _debute) &&
                !string.IsNullOrEmpty(_name) &&
                !string.IsNullOrEmpty(_nationality))
            {
                Performer performer = new Performer()
                {
                    Name = _name,
                    Nationality = _nationality,
                    DebuteDate = _debute
                };

                await _performerService.AddAsync(performer);

                MessagingCenter.Send(this, "update");
            }
        }
    }
}
