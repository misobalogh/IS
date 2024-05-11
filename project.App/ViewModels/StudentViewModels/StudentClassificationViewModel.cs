using CommunityToolkit.Mvvm.Input;
using project.App.Views.StudentViews;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels.StudentViewModels;

public partial class StudentClassificationViewModel : ViewModelBase
{
    private static EnrolledSubjectsModel _es1 => new()
    {
        SubjectId = Guid.Parse("d7ebd9e9-95a6-4a67-b43f-c16c0475f735"),
        SubjectName = "IDM",
        Points = 49,
        Mark = Mark.F,
        Year = DateTime.Now
    };

    private static EnrolledSubjectsModel _es2 => new()
    {
        SubjectId = Guid.Empty,
        SubjectName = "IDS",
        Points = 99,
        Mark = Mark.A,
        Year = DateTime.Now
    };

    private static EnrolledSubjectsModel _es3 => new()
    {
        SubjectId = Guid.Empty,
        SubjectName = "ICS",
        Points = 0,
        Mark = Mark.None,
        Year = DateTime.Now
    };


    private static EnrolledSubjectsModel _es4 => new()
    {
        SubjectId = Guid.Empty,
        SubjectName = "IPP",
        Points = 30,
        Mark = Mark.None,
        Year = DateTime.Now
    };

    public List<EnrolledSubjectsModel> _enrolledSubjects =
    [
        _es1,
        _es2,
        _es3,
        _es4,
    ];

    public List<EnrolledSubjectsModel> EnrolledSubjects
    {
        get => _enrolledSubjects;
        set => SetProperty(ref _enrolledSubjects, value);
    }

    [RelayCommand]
    async Task ShowSubjectDetails(EnrolledSubjectsModel subject)
    {
        if (subject == null) return;
        var route = $"{nameof(StudentClassificationSubjectDetailView)}?subjectId={subject.SubjectId}";
        await Shell.Current.GoToAsync(route);
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

