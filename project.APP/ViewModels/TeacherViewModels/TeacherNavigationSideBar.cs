﻿using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.TeacherViews;

namespace project.App.ViewModels;

public partial class TeacherNavigationSideBar(IMessengerService messengerService) : ViewModelBase(messengerService)
{
    [RelayCommand]
    async Task GoToProfile()
    {
        await Shell.Current.GoToAsync(nameof(TeacherProfileView));
    }

    [RelayCommand]
    async Task GoToSchedule()
    {
        await Shell.Current.GoToAsync(nameof(TeacherScheduleView));
    }

    [RelayCommand]
    async Task GoToClassification()
    {
        await Shell.Current.GoToAsync(nameof(TeacherClassificationView));
    }

    [RelayCommand]
    async Task GoToSubjects()
    {
        await Shell.Current.GoToAsync(nameof(TeacherSubjectsView));
    }

    [RelayCommand]
    async Task GoToTests()
    {
        await Shell.Current.GoToAsync(nameof(TeacherTestsView));
    }

    [RelayCommand]
    async Task GoToStudents()
    {
        await Shell.Current.GoToAsync(nameof(TeacherStudentsView));
    }

    [RelayCommand]
    async Task Logout()
    {
        if (Application.Current?.MainPage?.Navigation != null)
        {
            await Application.Current.MainPage.Navigation.PopToRootAsync();
        }

    }
}

