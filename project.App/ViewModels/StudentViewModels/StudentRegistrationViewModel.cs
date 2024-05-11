using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Views.StudentViews;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;

public partial class StudentRegistrationViewModel : ViewModelBase
{    //TODO NOT IMPLEMENTED

    private static ActivityModel _ac1 => new()
    {
        SubjectId = Guid.Empty,
        SubjectName = "Diskrétní matematika",
        Name = "IDM",
        ActivityType = ActivityType.MidtermExam,
        TeacherName = "Ing. Jan Novák",
        TeacherId = Guid.Empty,
        Start = DateTime.Now,
        End = DateTime.Now,
        Room = Room.A01,
        Capacity = 100,
        MaxPoints = 100
    };

    private static ActivityModel _ac2 => new()
    {
        SubjectId = Guid.Empty,
        SubjectName = "Databázové systémy",
        Name = "IDS",
        ActivityType = ActivityType.MidtermExam,
        TeacherName = "Ing. Jana Nováková",
        TeacherId = Guid.Empty,
        Start = DateTime.Now,
        End = DateTime.Now,
        Room = Room.B01,
        Capacity = 500,
        MaxPoints = 60
    };

    public List<ActivityModel> _activity =
    [
        _ac1,
        _ac2,
    ];


    public List<ActivityModel> Activity
    {
        get => _activity;
        set => SetProperty(ref _activity, value);
    }

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

