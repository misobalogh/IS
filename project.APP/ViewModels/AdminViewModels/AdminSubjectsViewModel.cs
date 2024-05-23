using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.AdminViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;


public partial class AdminSubjectsViewModel(
    ISubjectFacade subjectFacade,
    IMessengerService messengerService, UserDataService userDataService) 
    : AdminNavigationSideBar(messengerService, userDataService)
{
    public IEnumerable<SubjectListModel> Subjects { get; set; } = null!;
    private bool firstSearch = true;

    public string SubjectNameBtn { get; set; } = "Name";
    public string SubjectTagBtn { get; set; } = "Tag";
    public string SemesterBtn { get; set; } = "Semester";

    private bool SortDescending = false;

    private SortBy SortedBy = SortBy.None;

    private enum SortBy
    {
        Name,
        Tag,
        Semester,
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
        if (firstSearch && string.IsNullOrEmpty(searchTerm))
        {
            return;
        }
        firstSearch = false;
        Subjects = await subjectFacade.SearchSubject(searchTerm);
    }

    [RelayCommand]
    async Task NewSubject(string searchTerm)
    {
        await Shell.Current.GoToAsync(nameof(AdminNewSubjectView));
    }

    [RelayCommand]
    void SortByName()
    {
        ResetToOriginalName();

        ChangeSortDirectionIfSorted(SortBy.Name);

        SubjectNameBtn = GetSortColName(SubjectNameBtn);

        Subjects = subjectFacade.Sort(Subjects, nameof(SubjectListModel.SubjectName), SortDescending);

        SortedBy = SortBy.Name;
    }

    [RelayCommand]
    void SortByTag()
    {
        ResetToOriginalName();

        ChangeSortDirectionIfSorted(SortBy.Tag);

        SubjectTagBtn = GetSortColName(SubjectTagBtn);

        Subjects = subjectFacade.Sort(Subjects, nameof(SubjectListModel.SubjectTag), SortDescending);

        SortedBy = SortBy.Tag;
    }

    [RelayCommand]
    void SortBySemester()
    {
        ResetToOriginalName();

        ChangeSortDirectionIfSorted(SortBy.Semester);

        SemesterBtn = GetSortColName(SemesterBtn);

        Subjects = subjectFacade.Sort(Subjects, nameof(SubjectListModel.Semester), SortDescending);

        SortedBy = SortBy.Semester;
    }

    /// <summary>
    /// Sets column header to original text - without arrows
    /// </summary>
    private void ResetToOriginalName()
    {
        SubjectNameBtn = "Name";
        SubjectTagBtn = "Tag";
        SemesterBtn = "Semester";
    }

    /// <summary>
    /// if clicked on column by which is already sorted -> change direction of sort
    /// </summary>
    private void ChangeSortDirectionIfSorted(SortBy newSortBy)
    {
        if (newSortBy == SortedBy)
        {
            SortDescending = !SortDescending;
        }
        else // if switched to sorting by different column, set to descending
        {
            SortDescending = false;
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

