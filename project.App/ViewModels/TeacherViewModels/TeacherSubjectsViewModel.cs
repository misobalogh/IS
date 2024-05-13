using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.App.Views.TeacherViews;
using project.BL.Facades;
using project.BL.Models;

namespace project.App.ViewModels;

public partial class TeacherSubjectsViewModel(ISubjectFacade subjectFacade, IMessengerService messengerService) : ViewModelBase(messengerService)
{    //TODO NOT IMPLEMENTED

    public IEnumerable<SubjectListModel> Subjects { get; set; } = null!;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Subjects = await subjectFacade.GetAsync();
    }



    //Menu navigation Commmands
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
}

