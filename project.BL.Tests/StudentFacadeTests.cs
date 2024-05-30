using project.BL.Facades;
using project.BL.Models;
using project.DAL.Enums;
using project.Common.Tests;
using project.Common.Tests.Seeds;
using System.Collections.ObjectModel;
using project.BL.Models;
using project.BL.Tests;
using project.Common.Tests;
using Xunit;
using Xunit.Abstractions;
using project.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace project.BL.Tests;

public class StudentFacadeTests : FacadeTestsBase
{
    private readonly IStudentFacade _studentFacadeSUT;

    public StudentFacadeTests(ITestOutputHelper output) : base(output)
    {
        _studentFacadeSUT = new StudentFacade(UnitOfWorkFactory, StudentModelMapper);
    }

    // [Fact]
    public async Task Create_EqualsCreated() 
    {
        //Arrange
        var model = new StudentModel
        {
            FirstName = "Honza",
            LastName = "Novák",
            Email = "test@facade.com",
            Password = "totally_random_password123",
            Grade = 4
        };
    
        //Act
        var returnedModel = await _studentFacadeSUT.SaveAsync(model);
        
        //Assert
        FixIds(model, returnedModel);
        DeepAssert.Equal(model, returnedModel);
    }

    private static void FixIds(StudentModel expectedModel, StudentModel returnedModel)
    {
        returnedModel.Id = expectedModel.Id;

        foreach (var enrolledSubjectsModel in returnedModel.EnrolledSubjects)
        {
            var enrolledSubjectsDetailModel = expectedModel.EnrolledSubjects.FirstOrDefault(i =>
                i.SubjectId == enrolledSubjectsModel.SubjectId
                && i.SubjectName == enrolledSubjectsModel.SubjectName
                && i.Points == enrolledSubjectsModel.Points);

            if (enrolledSubjectsDetailModel != null)
            {
                enrolledSubjectsModel.SubjectId = enrolledSubjectsModel.SubjectId;
                enrolledSubjectsModel.SubjectName = enrolledSubjectsDetailModel.SubjectName;
                enrolledSubjectsModel.Points = enrolledSubjectsDetailModel.Points;
                enrolledSubjectsModel.Mark = enrolledSubjectsDetailModel.Mark;
            }
        }
        
        foreach (var registeredActivitiesModel in returnedModel.RegisteredActivities)
        {
            var registeredDetailModel = expectedModel.RegisteredActivities.FirstOrDefault(i =>
                i.ActivityId == registeredActivitiesModel.ActivityId
                && i.ActivityName == registeredActivitiesModel.ActivityName);

            if (registeredDetailModel != null)
            {
                registeredActivitiesModel.ActivityId = registeredActivitiesModel.ActivityId;
                registeredActivitiesModel.ActivityName = registeredDetailModel.ActivityName;
            }
        }
        
        foreach (var evaluationModel in returnedModel.Evaluation)
        {
            var evaluationDetailModel = expectedModel.Evaluation.FirstOrDefault(i =>
                i.Points == evaluationModel.Points
                && i.StudentId == evaluationModel.StudentId);

            if (evaluationDetailModel != null)
            {
                evaluationModel.StudentId = evaluationModel.StudentId;
                evaluationModel.Points = evaluationDetailModel.Points;
            }
        }
    }

    private async Task SeedDatabaseAsync()
    {
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        var students = new List<StudentEntity>
        {
            new StudentEntity {Id = Guid.NewGuid(), FirstName = "Jan", LastName = "Horák", Email = "jan@novak.cz", Password = "test_data"},
            new StudentEntity {Id = Guid.NewGuid(), FirstName = "Marie", LastName = "Nováková", Email = "marie@novakova.cz", Password = "test_data"},
            new StudentEntity {Id = Guid.NewGuid(), FirstName = "Jiří", LastName = "Novák", Email = "jiri@novak.cz", Password = "test_data"}
        };
        dbx.Students.AddRange(students);
        await dbx.SaveChangesAsync();
    }

    [Theory]
    [InlineData("jan", 1)]  // Assuming "Jan" is part of a student's name in the seeded data.
    [InlineData("JAN", 1)]  // Case-insensitivity test.
    [InlineData("novák", 2)]  // Last name part.
    public async Task SearchStudent_ReturnsExpectedResults(string searchTerm, int expectedCount)
    {
        // Arrange
        await SeedDatabaseAsync();  // Ensure the database is seeded before each test.

        // Act
        var results = await _studentFacadeSUT.SearchStudent(searchTerm);

        // Assert
        Assert.Equal(expectedCount, results.Count);
    }
}
