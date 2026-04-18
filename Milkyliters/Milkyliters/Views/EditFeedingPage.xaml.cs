using Milkyliters.ViewModels;

namespace Milkyliters.Views;

public partial class EditFeedingPage : ContentPage
{

	private readonly EditFeedingViewModel _viewModel;

	public EditFeedingPage(EditFeedingViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel;
	}
}