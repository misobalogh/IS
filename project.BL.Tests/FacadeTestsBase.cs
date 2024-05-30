using project.BL.Mappers;
using project.Common.Tests;
using project.Common.Tests.Factories;
using project.DAL;
using project.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using project.BL.Models;
using project.DAL.Entities;
using Xunit;
using Xunit.Abstractions;

namespace project.BL.Tests;

public class FacadeTestsBase : IAsyncLifetime
{
    protected FacadeTestsBase(ITestOutputHelper output)
    {
        XUnitTestOutputConverter converter = new(output);
        Console.SetOut(converter);

        DbContextFactory = new DbContextSqLiteTestingFactory(GetType().FullName!, seedTestingData: true);

        ActivityModelMapper = new ActivityModelMapper();
        EnrolledSubjectsModelMapper = new EnrolledSubjectsModelMapper();
        EvaluationModelMapper = new EvaluationModelMapper();
        RegisteredActivitiesModelMapper = new RegisteredActivitiesModelMapper();
        EvaluationModelMapper = new EvaluationModelMapper();
        SubjectModelMapper = new SubjectModelMapper();
        TeacherModelMapper = new TeacherModelMapper();
        StudentModelMapper = new StudentModelMapper();

        UnitOfWorkFactory = new UnitOfWorkFactory(DbContextFactory);
    }

    protected IDbContextFactory<ApplicationDbContext> DbContextFactory { get; }
    protected ActivityModelMapper ActivityModelMapper { get; }
    protected EnrolledSubjectsModelMapper EnrolledSubjectsModelMapper { get; }
    protected EvaluationModelMapper EvaluationModelMapper { get; }
    protected RegisteredActivitiesModelMapper RegisteredActivitiesModelMapper { get; }
    protected StudentModelMapper StudentModelMapper { get; }
    protected SubjectModelMapper SubjectModelMapper { get; }
    protected TeacherModelMapper TeacherModelMapper { get; }
    
    protected UnitOfWorkFactory UnitOfWorkFactory { get; }

    public async Task InitializeAsync()
    {
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        await dbx.Database.EnsureDeletedAsync();
        await dbx.Database.EnsureCreatedAsync();
    }

    public async Task DisposeAsync()
    {
        await using var dbx = await DbContextFactory.CreateDbContextAsync();
        await dbx.Database.EnsureDeletedAsync();
    }
}
