using _153504_SIVY.UI.ViewModels;

namespace _153504_SIVY.UI.Pages;

public partial class AddNewObjectPage : ContentPage
{
	private AddNewObjectViewModel viewModel;
	public AddNewObjectPage(AddNewObjectViewModel vm)
	{
		InitializeComponent();
		viewModel = vm;
		BindingContext = viewModel;
	}
}