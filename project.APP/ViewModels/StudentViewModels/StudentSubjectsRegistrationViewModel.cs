using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;

public partial class StudentSubjectsRegistrationViewModel(
    ISubjectFacade subjectFacade,
    IMessengerService messengerService,
    UserDataService userDataService) : StudentNavigationSideBar(messengerService, userDataService)
{

    public IEnumerable<SubjectListModel> Subjects { get; set; } = null!;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        Subjects = await subjectFacade.GetAsync();
    }

    [RelayCommand]
    async Task Register()
    {
        //TODO
    }
}

