using Microsoft.Extensions.Logging;
using project.App.ViewModels;
using project.App.Views.StudentViews;
using project.App.Views.LoginViews;
using project.BL;
using CookBook.DAL.Options;
using Microsoft.Extensions.Configuration;
using CookBook.DAL;

namespace project.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services
                .AddDALServices(GetDALOptions(builder.Configuration))
                //TODO: .AddAppServices()
                .AddBLServices();

            Routing.RegisterRoute(nameof(StudentClassificationView), typeof(StudentClassificationView));
            Routing.RegisterRoute(nameof(StudentRegistrationView), typeof(StudentRegistrationView));
            Routing.RegisterRoute(nameof(StudentScheduleView), typeof(StudentScheduleView));
            Routing.RegisterRoute(nameof(StudentSubjectsView), typeof(StudentSubjectsView));
            Routing.RegisterRoute(nameof(StudentTestsView), typeof(StudentTestsView));

            return builder.Build();
        }

        private static DALOptions GetDALOptions(IConfiguration configuration)
        {
            DALOptions dalOptions = new()
            {
                DatabaseDirectory = FileSystem.AppDataDirectory
            };
            configuration.GetSection("CookBook:DAL").Bind(dalOptions);
            return dalOptions;
        }
    }
}
