using Milkyliters.Views;

namespace Milkyliters;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(EditFeedingPage), typeof(EditFeedingPage));
    }
}
