﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.BL.Facades;
using project.BL.Models;

namespace project.App.ViewModels;

public partial class StudentSubjectsViewModel(
    ISubjectFacade subjectFacade, 
    IEnrolledSubjectsFacade enrolledSubjectsFacade,
    IMessengerService messengerService,
    UserDataService userDataService) : StudentNavigationSideBar(messengerService, userDataService)
{    
    public IEnumerable<SubjectListModel> Subjects { get; set; } = null!;
    private bool firstSearch = true;
    public string SubjectNameBtn { get; set; } = "Name";
    public string SubjectTagBtn { get; set; } = "Tag";

    private bool SortDescending = false;

    private SortBy SortedBy = SortBy.None;

    private enum SortBy {
        Name,
        Tag,
        None
    };

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        if (loggedUser == null)
        {
            return;
        }

        Subjects = await subjectFacade.GetAsync();
        var enrolledSubjects = await enrolledSubjectsFacade.GetAsync();
        var enrolledByLoggedUser = enrolledSubjects.Where(es => es.StudentId == loggedUser.Id).Select(es => es.SubjectId);

        Subjects = Subjects.Where(sub => enrolledByLoggedUser.Contains(sub.Id));
        
        SortByName();
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

