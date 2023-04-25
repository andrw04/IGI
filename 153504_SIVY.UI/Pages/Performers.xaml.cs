using _153504_SIVY.Domain.Entities;
using _153504_SIVY.UI.ViewModels;

namespace _153504_SIVY.UI.Pages;

public partial class Performers : ContentPage
{
	private PerformersViewModel model;
	public Performers(PerformersViewModel viewModel)
	{
		InitializeComponent();
		model = viewModel;
		BindingContext = model;
	}
}