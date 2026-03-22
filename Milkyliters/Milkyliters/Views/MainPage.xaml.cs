using Milkyliters.ViewModels;

namespace Milkyliters.Views;

public partial class MainPage : ContentPage
{
    MainViewModel _viewModel;
    public MainPage(MainViewModel viewModel)
    {
        _viewModel = viewModel;
        InitializeComponent();
        BindingContext = _viewModel;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.InitializeAsync();
    }
}
