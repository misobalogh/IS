﻿using project.BL.Facades;
using project.BL.Models;
using project.Common.Tests;
using project.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using project.BL.Facades.Interfaces;
using project.DAL.Enums;
using Xunit;
using Xunit.Abstractions;
using project.DAL.Entities;
using System.Reflection;

namespace project.BL.Tests;

public sealed class ActivityFacadeTests : FacadeTestsBase
{
    private readonly IActivityFacade _activityFacadeSUT;

    public ActivityFacadeTests(ITestOutputHelper output) : base(output)
    {
        _activityFacadeSUT = new ActivityFacade(UnitOfWorkFactory, ActivityModelMapper);
    }

    [Fact]
    public async Task Create_WithNonExistingItem_DoesNotThrow()
    {
        var model = new ActivityModel
        {
            Id = Guid.Parse("5bb5f586-11ec-4b9f-97d9-4f0dfe111fcc"),
            SubjectId = ActivitySeeds.IJCConsultation.SubjectId,
            SubjectName = ActivitySeeds.IJCConsultation.Subject.Name,
            Name = "MA",
            ActivityType = ActivityType.Lecture,
            TeacherName = ActivitySeeds.IJCConsultation.Teacher.LastName,
            Start = default,
            End = default,
            Room = Room.B01,
            Capacity = 0,
            MaxPoints = 0,
            TeacherId = ActivitySeeds.IJCConsultation.TeacherId,

        };

        await _activityFacadeSUT.SaveAsync(model, model.SubjectId, model.TeacherId);
    }
    
    [Fact]
    public async Task GetById_NonExistent()
    {
        var activity = await _activityFacadeSUT.GetAsync(ActivitySeeds.EmptyActivity.Id);
    
        Assert.Null(activity);
    }
    
    [Fact]
    public async Task IFJMidterm_DeleteById_Deleted()
    {
        // var test = await _activityFacadeSUT.GetAsync();
        
        await _activityFacadeSUT.DeleteAsync(ActivitySeeds.IFJMidterm.Id);

        await using var dbxAssert = await DbContextFactory.CreateDbContextAsync();
        Assert.False(await dbxAssert.Activities.AnyAsync(i => i.Id == ActivitySeeds.IFJMidterm.Id));
    }

    [Theory]
    [InlineData("2024-05-15", "2024-05-16")]  
    [InlineData("2025-01-01", "2025-12-31")]  
    public void FilterBySubjects_ReturnsCorrectActivities(DateTime startDate, DateTime endDate)
    {
        Guid subjectId = ActivitySeeds.IFJMidterm.SubjectId;  // Assuming this is seeded

        ActivitySeeds.SeedActivitiesForTesting();

        IEnumerable<ActivityListModel> activities = [
            ActivityModelMapper.MapToListModel(ActivitySeeds.IFJMidterm),
            ActivityModelMapper.MapToListModel(ActivitySeeds.IJCConsultation)];

    }

    [Theory]
    [InlineData("Name", true)]  // Descending sort by name
    [InlineData("Start", false)] // Ascending sort by start date
    public void GetSortedActivities_ReturnsSortedResults(string sortBy, bool descending)
    {
        // Arrange
        ActivitySeeds.SeedActivitiesForTesting();

        IEnumerable<ActivityListModel> activities = [
            ActivityModelMapper.MapToListModel(ActivitySeeds.IFJMidterm),
            ActivityModelMapper.MapToListModel(ActivitySeeds.IJCConsultation)];

        // Act
        var result = _activityFacadeSUT.GetSortedActivities(activities, sortBy, descending);

        // Use reflection correctly here:
        PropertyInfo? propInfo = typeof(ActivityListModel).GetProperty(sortBy);
        if (propInfo == null)
        {
            throw new ArgumentException($"'{sortBy}' is not a valid property of ActivityListModel");
        }

        var expected = descending
            ? activities.OrderByDescending(a => propInfo.GetValue(a, null))
            : activities.OrderBy(a => propInfo.GetValue(a, null));

        Assert.True(result.SequenceEqual(expected), "Activities should be sorted correctly based on the provided property.");
    }

    [Fact]
    public void GetSortedActivities_WithInvalidProperty_ThrowsArgumentException()
    {
        // Arrange
        ActivitySeeds.SeedActivitiesForTesting();

        IEnumerable<ActivityListModel> activities = [
            ActivityModelMapper.MapToListModel(ActivitySeeds.IFJMidterm),
            ActivityModelMapper.MapToListModel(ActivitySeeds.IJCConsultation)];

        string invalidProperty = "NonexistentProperty";

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _activityFacadeSUT.GetSortedActivities(activities, invalidProperty));
    }
}
