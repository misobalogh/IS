﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Views.StudentViews;
using project.BL.Models;

namespace project.App.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    public StudentModel model { get; set; } = StudentModel.Empty;
    public string? LoginCredential { get; set; }

    [RelayCommand]
    async Task login()
    {
        await Shell.Current.GoToAsync(nameof(StudentScheduleView));
    }
}

