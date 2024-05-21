using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.App.Views.TeacherViews;
using project.BL.Facades;
using project.BL.Models;

namespace project.App.ViewModels;

public partial class TeacherSubjectsViewModel(
    ISubjectFacade subjectFacade, 
    IMessengerService messengerService, 
    UserDataService userDataService) : TeacherNavigationSideBar(messengerService, userDataService)
{    
    public IEnumerable<SubjectListModel> Subjects { get; set; } = null!;
    private bool firstSearch = true;

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Subjects = await subjectFacade.GetAsync();
    }

    [RelayCommand]
    async Task Search(string searchTerm)
    {
        if (firstSearch && string.IsNullOrEmpty(searchTerm))
        {
            return;
        }
        firstSearch = false;
        Subjects = await subjectFacade.SearchSubject(searchTerm);
    }

    [RelayCommand]
    async Task ShowSubjectDetails(object clickedItem)
    {
        if (clickedItem == null)
        {
            return;
        }

        if (clickedItem is SubjectListModel subject)
        {
            var route = $"{nameof(TeacherSubjectsDetailView)}?subjectId={subject.Id}";
            await Shell.Current.GoToAsync(route);
        }
    }
}

