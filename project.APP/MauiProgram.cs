using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using project.App.ViewModels;
using project.App.Views.StudentViews;
using project.App.Views.LoginViews;

namespace project.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif


            Routing.RegisterRoute(nameof(StudentClassificationView), typeof(StudentClassificationView));
            Routing.RegisterRoute(nameof(StudentRegistrationView), typeof(StudentRegistrationView));
            Routing.RegisterRoute(nameof(StudentScheduleView), typeof(StudentScheduleView));
            Routing.RegisterRoute(nameof(StudentSubjectsView), typeof(StudentSubjectsView));
            Routing.RegisterRoute(nameof(StudentTestsView), typeof(StudentTestsView));

            return builder.Build();
        }
    }
}
