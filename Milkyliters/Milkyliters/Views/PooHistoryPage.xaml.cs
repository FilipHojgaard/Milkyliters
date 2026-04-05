using System.Runtime.Serialization;
using Milkyliters.ViewModels;

namespace Milkyliters.Views;

public partial class PooHistoryPage : ContentPage
{
	PooHistoryViewModel _viewModel;
	public PooHistoryPage(PooHistoryViewModel viewModel)
	{
		_viewModel = viewModel;
		InitializeComponent();
		BindingContext = _viewModel;
    }

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await _viewModel.LoadRecentPoosAsync();
    }
}