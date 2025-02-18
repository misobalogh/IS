﻿using project.App.ViewModels;
using project.BL.Models;

namespace project.App.Views.StudentViews;

public partial class StudentSubjectsRegistrationView
{
    StudentSubjectsRegistrationViewModel vm;


    public StudentSubjectsRegistrationView(StudentSubjectsRegistrationViewModel viewModel) : base(viewModel)
    {
		InitializeComponent();
        vm = viewModel;
    }

    private async void OnRegisterButtonClicked(object sender, EventArgs e)
    {
        var button = sender as Button;

        var subject = button!.CommandParameter as SubjectListModel;

        if (button != null)
        {
            if (await vm.IsRegistered(subject))
            {
                //await vm.Unregister(subject!.Id);
                button.Text = "Register";
                button.BackgroundColor = Color.FromRgb(171, 147, 227);
            }
            else
            {
                await vm.Register(subject: subject);
                button.Text = "Unregister";
                button.BackgroundColor = Color.FromRgb(255, 0, 0);
            }
        }
    }

    private async void OnLoad(object sender, EventArgs e)
    {
        var button = sender as Button;

        var subject = button!.CommandParameter as SubjectListModel;

        if (button != null)
        {
            if (await vm.IsRegistered(subject))
            {
                button.Text = "Unregister";
                button.BackgroundColor = Color.FromRgb(255, 0, 0);
            }
            else
            {
                button.Text = "Register";
                button.BackgroundColor = Color.FromRgb(171, 147, 227);
            }
        }
    }
}
