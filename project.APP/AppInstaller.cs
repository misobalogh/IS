using CommunityToolkit.Mvvm.Messaging;
using project.App.ViewModels;
using project.App.Shells;
using project.App.Views;

namespace project.App;

public static class AppInstaller
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddSingleton<AppShell>();

        //TODO: messengerService, alertService, pokud bude potreba

        services.Scan(selector => selector
            .FromAssemblyOf<App>()
            .AddClasses(filter => filter.AssignableTo<ContentPageBase>())
            .AsSelf()
            .WithTransientLifetime());

        services.Scan(selector => selector
            .FromAssemblyOf<App>()
            .AddClasses(filter => filter.AssignableTo<IViewModel>())
            .AsSelfWithInterfaces()
            .WithTransientLifetime());

        //TODO: jestli je potreba services.AddTransient<INavigationService, NavigationService>();

        return services;
    }
}
