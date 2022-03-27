using CarDealership.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CarDealership.Core.Persistence;

public static class DbInitializer
{
    public static void ConfigureDb<T>(IServiceCollection services, IConfiguration configuration, ILogger<T> logger)
    {
        logger.LogInformation("Connecting to DB; {ConnectionString}", configuration.GetConnectionString("DefaultConnection"));

        try
        {
            services.AddDbContext<Db>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(Db).Assembly.FullName)));
        }
        catch (Exception e)
        {
            logger.LogError("Cannot connect to DB, reason: {Reason}", e.Message);
            throw;
        }
    }

    public static void RunMigrations<T>(Db db, ILogger<T> logger)
    {
        if (db.Database.GetPendingMigrations().Any())
        {
            logger.LogInformation("Starting migrations");
            db.Database.Migrate();
        }
        else
        {
            logger.LogInformation("No migration needed");
        }
    }

    public static void SeedDb<T>(Db db, ILogger<T> logger)
    {
        if (db.Cars.Any())
        {
            return;
        }

        logger.LogInformation("Running seed");

        db.Cars.AddRange(
            new Car
            {
                Make = "Ford",
                Model = "Focus",
                RegistrationNumber = "ABC 82931"
            },
            new Car
            {
                Make = "Renault",
                Model = "Megane",
                RegistrationNumber = "KRL 926413"
            },
            new Car
            {
                Make = "Toyota",
                Model = "Corolla",
                RegistrationNumber = "FXS 017393"
            }
        );

        db.SaveChanges();
    }
}