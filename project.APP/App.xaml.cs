﻿using project.App.Shells;

namespace project.App;

public partial class App : Application
{
    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        MainPage = serviceProvider.GetRequiredService<AppShell>();
    }
}
