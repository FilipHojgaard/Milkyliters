using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Milkyliters.Data;

namespace Milkyliters
{
    public partial class App : Application
    {
        public App(AppDbContext db)
        {
            InitializeComponent();
            db.Database.Migrate();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}