using _153504_SIVY.Domain.Entities;
using _153504_SIVY.UI.ViewModels;

namespace _153504_SIVY.UI.Pages;

public partial class SongDetails : ContentPage
{
	private SongDetailsViewModel model;
	public SongDetails(SongDetailsViewModel viewModel)
	{
		InitializeComponent();
		model = viewModel;
		BindingContext = model;
	}
}