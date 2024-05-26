﻿using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.AdminViews;
using project.BL.Facades;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;

[QueryProperty("TeacherId", "teacherId")]
public partial class AdminNewTeacherViewModel(ITeacherFacade teacherFacade, IMessengerService messengerService, UserDataService userDataService) : AdminNavigationSideBar(messengerService, userDataService)
{
    public string? TeacherId { get; set; }
    public TeacherModel NewTeacher { get; private set; } = TeacherModel.Empty;
    public List<TitleBefore> TitlesBefore { get; private set; } = Enum.GetValues(typeof(TitleBefore)).Cast<TitleBefore>().ToList();
    public List<TitleAfter> TitlesAfter { get; private set; } = Enum.GetValues(typeof(TitleAfter)).Cast<TitleAfter>().ToList();

    protected override async Task LoadDataAsync()
    {
        if (string.IsNullOrEmpty(TeacherId))
        {
            return;
        }

        await base.LoadDataAsync();
        NewTeacher = await teacherFacade.GetAsync(Guid.Parse(TeacherId)) ?? TeacherModel.Empty;
    }

    [RelayCommand]
    async Task CreateTeacher()
    {
        if (string.IsNullOrEmpty(NewTeacher.Email) ||
            string.IsNullOrEmpty(NewTeacher.FirstName) ||
            string.IsNullOrEmpty(NewTeacher.LastName))
        {
            NotifyUser("Please fill in all required fields: First Name, Last Name, and Email.");
            return;
        }

        if (!NewTeacher.Email.Contains('@'))
        {
            NotifyUser("Invalid email");
            return;
        }

        // Check if email is unique
        bool emailExists = await teacherFacade.EmailExistsAsync(NewTeacher.Email);
        if (emailExists && string.IsNullOrEmpty(TeacherId))
        {
            NotifyUser("Email already exists.");
            return;
        }

        await teacherFacade.SaveAsync(NewTeacher);
        NotifyUser("New teacher successfully created");
        await Shell.Current.GoToAsync(nameof(AdminTeachersView));
    }

    private static void NotifyUser(string message)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            Shell.Current.DisplayAlert("Notification", message, "OK");
        });
    }
}
