using _153504_SIVY.UI.ViewModels;

namespace _153504_SIVY.UI.Pages;

public partial class EditObjectPage : ContentPage
{
	private EditObjectViewModel viewModel;
	public EditObjectPage(EditObjectViewModel vm)
	{
		InitializeComponent();
		viewModel = vm;
		BindingContext = viewModel;
	}
}