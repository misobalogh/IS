using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using project.App.Views.StudentViews;
using project.App.Views.AdminViews;
using project.App.Views.TeacherViews;
using project.App.Services;
using project.BL;
using project.DAL;
using project.DAL.Options;
using project.DAL.Migrator;

namespace project.App;

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

        ConfigureAppSettings(builder);

        builder.Services
            .AddDALServices(GetDALOptions(builder.Configuration))
            .AddAppServices()
            .AddBLServices()
            .AddSingleton<UserDataService>();
        var app = builder.Build();

        Routing.RegisterRoute(nameof(StudentClassificationView), typeof(StudentClassificationView));
        Routing.RegisterRoute(nameof(StudentRegistrationView), typeof(StudentRegistrationView));
        Routing.RegisterRoute(nameof(StudentScheduleView), typeof(StudentScheduleView));
        Routing.RegisterRoute(nameof(StudentSubjectsView), typeof(StudentSubjectsView));
        Routing.RegisterRoute(nameof(StudentTestsView), typeof(StudentTestsView));
        Routing.RegisterRoute(nameof(StudentClassificationSubjectDetailView), typeof(StudentClassificationSubjectDetailView));
        Routing.RegisterRoute(nameof(StudentProfileView), typeof(StudentProfileView));

        Routing.RegisterRoute(nameof(TeacherClassificationView), typeof(TeacherClassificationView));
        Routing.RegisterRoute(nameof(TeacherStudentsView), typeof(TeacherStudentsView));
        Routing.RegisterRoute(nameof(TeacherScheduleView), typeof(TeacherScheduleView));
        Routing.RegisterRoute(nameof(TeacherSubjectsView), typeof(TeacherSubjectsView));
        Routing.RegisterRoute(nameof(TeacherTestsView), typeof(TeacherTestsView));
        Routing.RegisterRoute(nameof(TeacherClassificationSubjectDetailView), typeof(TeacherClassificationSubjectDetailView));
        Routing.RegisterRoute(nameof(TeacherProfileView), typeof(TeacherProfileView));

        Routing.RegisterRoute(nameof(AdminProfileView), typeof(AdminProfileView));
        Routing.RegisterRoute(nameof(AdminStudentsView), typeof(AdminStudentsView));
        Routing.RegisterRoute(nameof(AdminTeachersView), typeof(AdminTeachersView));




        MigrateDb(app.Services.GetRequiredService<IDbMigrator>());

        return app;
    }

    private static void ConfigureAppSettings(MauiAppBuilder builder)
    {
        var configurationBuilder = new ConfigurationBuilder();

        var assembly = Assembly.GetExecutingAssembly();
        const string appSettingsFilePath = "project.App.appsettings.json";
        using var appSettingsStream = assembly.GetManifestResourceStream(appSettingsFilePath);
        if (appSettingsStream is not null)
        {
            configurationBuilder.AddJsonStream(appSettingsStream);
        }

        var configuration = configurationBuilder.Build();
        builder.Configuration.AddConfiguration(configuration);
    }

    private static DALOptions GetDALOptions(IConfiguration configuration)
    {
        DALOptions dalOptions = new()
        {
            DatabaseDirectory = FileSystem.AppDataDirectory
        };
        configuration.GetSection("project:DAL").Bind(dalOptions);
        return dalOptions;
    }
    
    private static void MigrateDb(IDbMigrator migrator) => migrator.Migrate();
}
