using CommunityToolkit.Mvvm.Input;
using project.App.Services;
using project.App.Views.AdminViews;
using project.BL.Facades;
using project.BL.Models;
using project.DAL.Enums;

namespace project.App.ViewModels;

public partial class AdminNewTeacherViewModel(ITeacherFacade teacherFacade, IMessengerService messengerService, UserDataService userDataService) : AdminNavigationSideBar(messengerService, userDataService)
{
    public TeacherModel NewTeacher { get; private set; } = TeacherModel.Empty;
    public List<TitleBefore> TitlesBefore { get; private set; } = Enum.GetValues(typeof(TitleBefore)).Cast<TitleBefore>().ToList();
    public List<TitleAfter> TitlesAfter { get; private set; } = Enum.GetValues(typeof(TitleAfter)).Cast<TitleAfter>().ToList();

    [RelayCommand]
    async Task CreateTeacher()
    {
        if (string.IsNullOrEmpty(NewTeacher.Email) ||
            string.IsNullOrEmpty(NewTeacher.FirstName) ||
            string.IsNullOrEmpty(NewTeacher.LastName))
        {
            //RequiredFieldNotFilled();
            return;
        }


        // Check if email is unique
        bool emailExists = await teacherFacade.EmailExistsAsync(NewTeacher.Email);
        if (emailExists)
        {
            // Notify user that the email already exists
            return;
        }

        await teacherFacade.SaveAsync(NewTeacher);
    }
}
