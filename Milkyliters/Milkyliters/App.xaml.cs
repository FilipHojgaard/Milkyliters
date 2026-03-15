using Milkyliters.Data;

namespace Milkyliters;

public partial class App : Application
{
    public App(DatabaseService db)
    {
        InitializeComponent();
        Task.Run(async () => await db.InitializeAsync()).Wait();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }
}