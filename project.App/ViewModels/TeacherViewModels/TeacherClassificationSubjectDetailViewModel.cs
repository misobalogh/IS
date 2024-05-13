using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.App.Views.TeacherViews;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;

[QueryProperty("SubjectId", "subjectId")]
public partial class TeacherClassificationSubjectDetailViewModel(IMessengerService messengerService) : ViewModelBase(messengerService)
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

