using System.Collections.ObjectModel;
using project.BL.Facades;
using project.BL.Models;
using project.Common.Tests;
using project.Common.Tests.Seeds;
using Microsoft.EntityFrameworkCore;
using project.DAL.Enums;
using Xunit;
using Xunit.Abstractions;

namespace project.BL.Tests;

public sealed class TeacherFacadeTests : FacadeTestsBase
{
    private readonly ITeacherFacade _teacherFacadeSUT;

    public TeacherFacadeTests(ITestOutputHelper output) : base(output)
    {
        _teacherFacadeSUT = new TeacherFacade(UnitOfWorkFactory, TeacherModelMapper);
    }

    [Fact]
    public async Task Create_WithWithoutTeachingSubjects_EqualsCreated()
    {
        // Arrange
        var model = new TeacherModel
        {
            FirstName = "Joe",
            LastName = "Mama",
            Password = "random_password123",
            Email = "joe@mama.com"
        };
        
        // Act
        var returnedModel = await _teacherFacadeSUT.SaveAsync(model);
        
        // Assert
        FixIds(model, returnedModel);
        DeepAssert.Equal(model, returnedModel);
    }
    
    [Fact]
    public async Task Create_WithNonExistingTeachingSubjects_Throws()
    {
        //Arrange
        var model = new TeacherModel()
        {
            FirstName = "Joe",
            LastName = "Mama",
            Password = "random_password123",
            Email = "joe@mama.com",
            TeachingSubjects = new ObservableCollection<SubjectListModel>()
            {
                new()
                {
                    Id = Guid.Empty,
                    SubjectName = "Seminář C#",
                    SubjectTag = "ICS"
                }
            }
        };

        //Act & Assert
        await Assert.ThrowsAnyAsync<InvalidOperationException>(() => _teacherFacadeSUT.SaveAsync(model));
    }
    
    [Fact]
    public async Task Create_WithExistingTeachingSubjects_Throws()
    {
        //Arrange
        var model = new TeacherModel()
        {
            FirstName = "Joe",
            LastName = "Mama",
            Email = "joe@mama.com",
            Password = "random_password987",
            TitleBefore = TitleBefore.Ing,
            TeachingSubjects = new ObservableCollection<SubjectListModel>()
            {
                new ()
                {
                    Id = SubjectSeeds.IFJ.Id,
                    SubjectName = SubjectSeeds.IFJ.Name,
                    SubjectTag = SubjectSeeds.IFJ.Tag
                }
            },
        };

        //Act && Assert
        await Assert.ThrowsAnyAsync<InvalidOperationException>(() => _teacherFacadeSUT.SaveAsync(model));
    }

    [Fact]
    public async Task Create_WithExistingAndNotExistingTeachingSubjects_Throws()
    {
        //Arrange
        var model = new TeacherModel()
        {
            FirstName = "Joe",
            LastName = "Mama",
            Email = "joe@mama.com",
            Password = "random_password987",
            TitleBefore = TitleBefore.Ing,
            TeachingSubjects =
            [
                new()
                {
                    Id = Guid.Empty,
                    SubjectName = "Subject 1",
                    SubjectTag = "IS1"
                },

                SubjectModelMapper.MapToListModel(SubjectSeeds.IFJ)

            ],
        };

        //Act & Assert
        await Assert.ThrowsAnyAsync<InvalidOperationException>(() => _teacherFacadeSUT.SaveAsync(model));
    }
    
    [Fact]
    public async Task GetById_FromSeeded_EqualsSeeded()
    {
        //Arrange
        var detailModel = TeacherModelMapper.MapToDetailModel(TeacherSeeds.TeacherEntity);

        //Act
        var returnedModel = await _teacherFacadeSUT.GetAsync(detailModel.Id);

        //Assert
        DeepAssert.Equal(detailModel, returnedModel);
    }
    
    [Fact]
    public async Task GetAll_FromSeeded_ContainsSeeded()
    {
        //Arrange
        var listModel = TeacherModelMapper.MapToListModel(TeacherSeeds.TeacherEntity);
    
        //Act
        var returnedModel = await _teacherFacadeSUT.GetAsync();
    
        //Assert
        Assert.Contains(listModel, returnedModel);
    }
    
    [Fact]
    public async Task Update_FromSeeded_DoesNotThrow()
    {
        //Arrange
        var detailModel = TeacherModelMapper.MapToDetailModel(TeacherSeeds.TeacherEntity);
        detailModel.FirstName = "Jan";

        //Act & Assert
        await _teacherFacadeSUT.SaveAsync(detailModel with {TeachingSubjects = default!});
    }
    
    [Fact]
    public async Task Update_LastName_FromSeeded_Updated()
    {
        //Arrange
        var detailModel = TeacherModelMapper.MapToDetailModel(TeacherSeeds.TeacherEntity);
        detailModel.LastName = "Petr";

        //Act
        await _teacherFacadeSUT.SaveAsync(detailModel with { TeachingSubjects = default!});

        //Assert
        var returnedModel = await _teacherFacadeSUT.GetAsync(detailModel.Id);
        DeepAssert.Equal(detailModel, returnedModel);
    }
    
    [Fact]
    public async Task Update_RemoveTeachingSubjects_FromSeeded_NotUpdated()
    {
        //Arrange
        var detailModel = TeacherModelMapper.MapToDetailModel(TeacherSeeds.TeacherEntity);
        detailModel.TeachingSubjects.Clear();
    
        //Act
        await _teacherFacadeSUT.SaveAsync(detailModel);
    
        //Assert
        var returnedModel = await _teacherFacadeSUT.GetAsync(detailModel.Id);
        DeepAssert.Equal(TeacherModelMapper.MapToDetailModel(TeacherSeeds.TeacherEntity), returnedModel);
    }
    
    [Fact]
    public async Task DeleteById_FromSeeded_DoesNotThrow()
    {
        //Arrange & Act & Assert
        await _teacherFacadeSUT.DeleteAsync(TeacherSeeds.TeacherEntity.Id);
    }
    
    private static void FixIds(TeacherModel expectedModel, TeacherModel returnedModel)
    {
        returnedModel.Id = expectedModel.Id;

        foreach (var teachingSubjectsModel in returnedModel.TeachingSubjects)
        {
            var teachingSubjectsDetailModel = expectedModel.TeachingSubjects.FirstOrDefault(i =>
                i.SubjectName == teachingSubjectsModel.SubjectName
                && i.Id == teachingSubjectsModel.Id
                && i.SubjectTag == teachingSubjectsModel.SubjectTag);

            if (teachingSubjectsDetailModel != null)
            {
                teachingSubjectsModel.Id = teachingSubjectsModel.Id;
                teachingSubjectsModel.SubjectTag = teachingSubjectsDetailModel.SubjectTag;
            }
        }
    }
}
