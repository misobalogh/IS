﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.App.Views.TeacherViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;


public partial class TeacherStudentsViewModel(
    IStudentFacade studentFacade,
    IMessengerService messengerService, UserDataService userDataService) 
    : TeacherNavigationSideBar(messengerService, userDataService)
{
    //TODO: pokud by se nekde mely zobrazovat studenti, ktere ucitel uci
    //public IEnumerable<EnrolledSubjectsListModel> EnrolledSubjects { get; private set; } = null!;
    public IEnumerable<StudentListModel> Students { get; set; } = null!;
    private bool firstSearch = true;

    public string NameBtn { get; set; } = "Name";
    public string EmailBtn { get; set; } = "Email";
    public string GradeBtn { get; set; } = "Grade";

    private bool SortDescending = false;

    private SortBy SortedBy = SortBy.None;

    private enum SortBy
    {
        Student,
        Grade,
        Email,
        None
    };

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        Students = await studentFacade.GetAsync();
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
        Students = await studentFacade.SearchStudent(searchTerm);
        //EnrolledSubjects = await enrolledSubjectsFacade.SearchSubject(searchTerm);
    }

    [RelayCommand]
    void SortByName()
    {
        ResetToOriginalName();

        ChangeSortDirectionIfSorted(SortBy.Student);

        NameBtn = GetSortColName(NameBtn);

        Students = studentFacade.Sort(Students, nameof(StudentListModel.FirstName), SortDescending);

        SortedBy = SortBy.Student;
    }

    [RelayCommand]
    void SortByEmail()
    {
        ResetToOriginalName();

        ChangeSortDirectionIfSorted(SortBy.Email);

        EmailBtn = GetSortColName(EmailBtn);

        Students = studentFacade.Sort(Students, nameof(StudentListModel.Email), SortDescending);

        SortedBy = SortBy.Email;
    }

    [RelayCommand]
    void SortByGrade()
    {
        ResetToOriginalName();

        ChangeSortDirectionIfSorted(SortBy.Grade);

        GradeBtn = GetSortColName(GradeBtn);

        Students = studentFacade.Sort(Students, nameof(StudentListModel.Grade), SortDescending);

        SortedBy = SortBy.Grade;
    }

    /// <summary>
    /// Sets column header to original text - without arrows
    /// </summary>
    private void ResetToOriginalName()
    {
        NameBtn = "Name";
        EmailBtn = "Email";
        GradeBtn = "Grade";
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

