using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;

[QueryProperty("SubjectId", "subjectId")]
public partial class StudentClassificationSubjectDetailViewModel(IMessengerService messengerService) : ViewModelBase(messengerService)
{
    public string? SubjectId { get; set; }

    //private EnrolledSubjectsModel GetSubjectById(Guid id)
    //{
    //    return new EnrolledSubjectsModel
    //    {
    //        SubjectId = id,
    //        SubjectName = "Test test",
    //        Points = 50,
    //        Mark = Mark.A,
    //        Year = DateTime.Now
    //    };
    //}

    [RelayCommand]
    async Task GoToSchedule()
    {
        await Shell.Current.GoToAsync(nameof(StudentScheduleView));
    }
    [RelayCommand]
    async Task GoToClassification()
    {
        await Shell.Current.GoToAsync(nameof(StudentClassificationView));
    }
    [RelayCommand]
    async Task GoToSubjects()
    {
        await Shell.Current.GoToAsync(nameof(StudentSubjectsView));
    }
    [RelayCommand]
    async Task GoToTests()
    {
        await Shell.Current.GoToAsync(nameof(StudentTestsView));
    }
    [RelayCommand]
    async Task GoToRegistration()
    {
        await Shell.Current.GoToAsync(nameof(StudentRegistrationView));
    }
}

