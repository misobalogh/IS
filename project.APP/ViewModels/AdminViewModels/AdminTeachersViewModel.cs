using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.TeacherViews;
using project.App.Views.AdminViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Enums;
using System.Globalization;

namespace project.App.ViewModels;


public partial class AdminTeachersViewModel(
    ITeacherFacade teacherFacade,
    IMessengerService messengerService, UserDataService userDataService) 
    : AdminNavigationSideBar(messengerService, userDataService)
{
    public IEnumerable<TeacherListModel> Teachers { get; set; } = null!;
    private bool firstSearch = true;

    public string NameBtn { get; set; } = "Name";
    public string EmailBtn { get; set; } = "Email";

    private bool SortDescending = false;

    private SortBy SortedBy = SortBy.None;

    private enum SortBy
    {
        Name,
        Email,
        None
    };

    protected override async Task LoadDataAsync()
    {
        await base.LoadDataAsync();
        Teachers = await teacherFacade.GetAsync();
    }

    [RelayCommand]
    async Task Search(string searchTerm)
    {
        if (firstSearch && string.IsNullOrEmpty(searchTerm))
        {
            return;
        }
        firstSearch = false;

        Teachers = await teacherFacade.SearchTeacher(searchTerm);
    }

    [RelayCommand]
    async Task EditTeacher(object clickedItem)
    {
        if (clickedItem == null)
        {
            await Shell.Current.GoToAsync($"{nameof(AdminNewTeacherView)}?teacherId=");
            return;
        }

        if (clickedItem is TeacherListModel teacher)
        {
            var route = $"{nameof(AdminNewTeacherView)}?teacherId={teacher.Id}";
            await Shell.Current.GoToAsync(route);
        }
    }

    [RelayCommand]
    void SortByName()
    {
        ResetToOriginalName();

        ChangeSortDirectionIfSorted(SortBy.Name);

        NameBtn = GetSortColName(NameBtn);

        Teachers = teacherFacade.Sort(Teachers, nameof(TeacherListModel.FirstName), SortDescending);

        SortedBy = SortBy.Name;
    }

    [RelayCommand]
    void SortByEmail()
    {
        ResetToOriginalName();

        ChangeSortDirectionIfSorted(SortBy.Email);

        EmailBtn = GetSortColName(EmailBtn);

        Teachers = teacherFacade.Sort(Teachers, nameof(TeacherListModel.Email), SortDescending);

        SortedBy = SortBy.Email;
    }

    /// <summary>
    /// Sets column header to original text - without arrows
    /// </summary>
    private void ResetToOriginalName()
    {
        NameBtn = "Name";
        EmailBtn = "Email";
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

