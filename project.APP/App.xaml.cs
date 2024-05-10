using project.App.Shells;
using project.App.Views.LoginViews;

namespace project.App

{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
