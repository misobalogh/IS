using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.StudentViews;
using project.App.Views.AdminViews;
using project.BL.Facades;
using project.BL.Facades.Interfaces;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;


public partial class AdminStudentsViewModel(
    IStudentFacade studentFacade,
    IMessengerService messengerService, UserDataService userDataService)
    : AdminNavigationSideBar(messengerService, userDataService)
{
    public IEnumerable<StudentListModel> Students { get; set; } = null!;
    private bool firstSearch = true;

    public string NameBtn { get; set; } = "Name";
    public string EmailBtn { get; set; } = "Email";

    private bool SortDescending = false;

    private SortBy SortedBy = SortBy.None;

    private enum SortBy
    {
        Student,
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
    }

    [RelayCommand]
    async Task EditStudent(object clickedItem)
    {
        if (clickedItem == null)
        {
            await Shell.Current.GoToAsync($"{nameof(AdminNewStudentView)}?studentId=");
            return;
        }

        if (clickedItem is StudentListModel student)
        {
            var route = $"{nameof(AdminNewStudentView)}?studentId={student.Id}";
            await Shell.Current.GoToAsync(route);
        }
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

