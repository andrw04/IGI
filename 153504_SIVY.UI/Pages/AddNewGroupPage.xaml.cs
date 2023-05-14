using _153504_SIVY.Domain.Abstractions;
using _153504_SIVY.Domain.Entities;
using _153504_SIVY.MyApplication.Abstractions;
using _153504_SIVY.UI.ViewModels;
using CommunityToolkit.Mvvm.Input;

namespace _153504_SIVY.UI.Pages;

public partial class AddNewGroupPage : ContentPage
{
	private AddNewGroupViewModel model;
	public AddNewGroupPage(AddNewGroupViewModel viewModel)
	{
		InitializeComponent();
		model = viewModel;
		BindingContext = model;
	}
}