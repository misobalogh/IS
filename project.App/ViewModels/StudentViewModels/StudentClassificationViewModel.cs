using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.Input;
using project.App.Views.StudentViews;
using project.App.Services;
using project.BL.Facades;
using project.BL.Models;

namespace project.App.ViewModels;

public partial class StudentClassificationViewModel(
    IEnrolledSubjectsFacade enrolledSubjectsFacade,
    IMessengerService messengerService,
    StudentDataService studentDataService) : StudentNavigationSideBar(messengerService, studentDataService)
{
    public IEnumerable<EnrolledSubjectsListModel> EnrolledSubjects { get; private set; } = null!;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        EnrolledSubjects = await enrolledSubjectsFacade.GetAsync();
        if (loggedUser !=  null)
        {
            EnrolledSubjects = EnrolledSubjects.Where(subject => subject.StudentId == loggedUser.Id);
        }
    }

    [RelayCommand]
    async Task ShowSubjectDetails(object clickedItem)
    {
        if (clickedItem == null) { 
            return; 
        }

        if (clickedItem is EnrolledSubjectsListModel subject) {
            var route = $"{nameof(StudentClassificationSubjectDetailView)}?subjectId={subject.Id}";
            await Shell.Current.GoToAsync(route);
        }
    }
}

