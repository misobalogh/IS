﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.App.Views.TeacherViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;


public partial class TeacherStudentsViewModel(
    IEnrolledSubjectsFacade enrolledSubjectsFacade,
    IMessengerService messengerService) 
    : TeacherNavigationSideBar(messengerService)
{
    public IEnumerable<EnrolledSubjectsListModel> EnrolledSubjects { get; private set; } = null!;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        EnrolledSubjects = await enrolledSubjectsFacade.GetAsync();
    }
}

