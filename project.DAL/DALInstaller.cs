using project.DAL.Factories;
using project.DAL.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.DependencyInjection;
using project.DAL;
using project.DAL.Options;
using project.DAL.Migrator;

namespace project.DAL;

public static class DALInstaller
{
    public static IServiceCollection AddDALServices(this IServiceCollection services, DALOptions options)
    {
        //TODO: dodelat Migrator jako z cookbooku?

        //TODO: zkontrolovat DbContextSqLiteFactory oni pouzivali options
        //TODO: a asi nepouzivat seedTestingData: true
        services.AddSingleton(options);

        if (options is null)
        {
            throw new InvalidOperationException("No persistence provider configured");
        }

        if (string.IsNullOrEmpty(options.DatabaseDirectory))
        {
            throw new InvalidOperationException($"{nameof(options.DatabaseDirectory)} is not set");
        }
        //TODO: pokusit se to udelat jako v kucharce, nejde to
        //if (string.IsNullOrEmpty(options.DatabaseName))
        //{
        //    throw new InvalidOperationException($"{nameof(options.DatabaseName)} is not set");
        //}

        //services.AddSingleton<IDbContextFactory<ApplicationDbContext>>(_ =>
        //    new DbContextSqLiteFactory(options.DatabaseFilePath, options?.SeedDemoData ?? false));

        //TODO: seedTestingData pred produkci na false
        services.AddSingleton<IDbContextFactory<ApplicationDbContext>>(_ =>
            new DbContextSqLiteFactory("project.db", true));

        services.AddSingleton<IDbMigrator, DbMigrator>();

        services.AddSingleton<ActivityEntityMapper>();
        services.AddSingleton<EnrolledSubjectEntityMapper>();
        services.AddSingleton<EvaluationEntityMapper>();
        services.AddSingleton<RegisteredActivitiesEntityMapper>();
        services.AddSingleton<RegisteredSubjectEntityMapper>();
        services.AddSingleton<StudentEntityMapper>();
        services.AddSingleton<SubjectEntityMapper>();
        services.AddSingleton<TeacherEntityMapper>();
        services.AddSingleton<TeachingSubjectsEntityMapper>();

        return services;
    }
}
