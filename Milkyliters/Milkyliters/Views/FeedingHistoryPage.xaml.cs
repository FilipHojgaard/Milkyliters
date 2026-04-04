using Milkyliters.ViewModels;

namespace Milkyliters.Views;

public partial class FeedingHistoryPage : ContentPage
{
	FeedingHistoryViewModel _viewModel;

	public FeedingHistoryPage(FeedingHistoryViewModel viewModel)
	{
		_viewModel = viewModel;
		InitializeComponent();
		BindingContext = _viewModel;
    }

	protected async override void OnAppearing()
	{
		base.OnAppearing();
		await _viewModel.LoadRecentFeedingsAsync();
    }
}