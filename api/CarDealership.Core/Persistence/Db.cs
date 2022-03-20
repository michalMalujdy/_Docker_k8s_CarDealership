using System.Reflection;
using CarDealership.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Core.Persistence;

public class Db : DbContext
{
    public DbSet<Car> Cars { get; set; } = null!;

    public Db(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}