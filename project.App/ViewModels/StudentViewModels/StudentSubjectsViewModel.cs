using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.BL.Facades;
using project.BL.Models;

namespace project.App.ViewModels;

public partial class StudentSubjectsViewModel(
    ISubjectFacade subjectFacade, 
    IMessengerService messengerService,
    UserDataService userDataService) : StudentNavigationSideBar(messengerService, userDataService)
{    
    public IEnumerable<SubjectListModel> Subjects { get; set; } = null!;

    public string SubjectNameBtn { get; set; } = "Name";
    public string SubjectTagBtn { get; set; } = "Tag";

    private bool SortDescending = true;

    private SortBy SortedBy = SortBy.None;

    private enum SortBy {
        Name,
        Tag,
        None
    };

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();

        Subjects = await subjectFacade.GetAsync();
    }

    [RelayCommand]
    async Task Search(string searchTerm)
    {
        Subjects = await subjectFacade.SearchSubject(searchTerm);
    }

    [RelayCommand]
    void SortByName()
    {
        ResetToOriginalName();
        
        ChangeSortDirectionIfSorted(SortBy.Name);

        SubjectNameBtn = GetSortColName(SubjectNameBtn);

        //TODO: seradit seznam studentu

        SortedBy = SortBy.Name;
    }

    [RelayCommand]
    void SortByTag()
    {
        ResetToOriginalName();
        
        ChangeSortDirectionIfSorted(SortBy.Tag);
        
        SubjectTagBtn = GetSortColName(SubjectTagBtn);

        //TODO: seradit seznam studentu

        SortedBy = SortBy.Tag;
    }

    /// <summary>
    /// Sets column header to original text - without arrows
    /// </summary>
    private void ResetToOriginalName()
    {
        SubjectNameBtn = "Name";
        SubjectTagBtn = "Tag";
    }

    /// <summary>
    /// if clicked on column by which is already sorted -> change direction of sort
    /// </summary>
    private void ChangeSortDirectionIfSorted(SortBy newSortBy)
    {
        if (newSortBy == SortBy.Name && SortedBy == SortBy.Name)
        {
            SortDescending = !SortDescending;
        } else if (newSortBy == SortBy.Tag && SortedBy == SortBy.Tag)
        {
            SortDescending = !SortDescending;
        } else // if switched to sorting by different column, set to descending
        {
            SortDescending = true;
        }
    }

    private string GetSortColName(string colName)
    {
        if (SortDescending)
        {
            return colName + " ↓";
        }
        else
        {
            return colName + " ↑";
        }
    }
}

