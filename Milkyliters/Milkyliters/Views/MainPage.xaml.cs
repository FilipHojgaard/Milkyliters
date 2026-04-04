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
        Window.Resumed += OnWindowResumed;
        await _viewModel.InitializeAsync();
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        Window.Resumed -= OnWindowResumed;
    }

    private async void OnWindowResumed(object? sender, EventArgs e)
    {
        await _viewModel.InitializeAsync();
    }
}
