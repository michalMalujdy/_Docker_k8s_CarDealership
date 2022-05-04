using CarDealership.Core;
using CarDealership.Core.Persistence;

var builder = WebApplication.CreateBuilder(args);

var logger = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<Program>>();
logger.LogInformation("App is starting");

builder.Services.AddCore(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(corsPolicyBuilder =>
    {
        corsPolicyBuilder.WithOrigins("http://localhost:3000");
        corsPolicyBuilder.WithOrigins("http://localhost:5557");
        corsPolicyBuilder.WithHeaders("Content-Type");
    });
});

var app = builder.Build();

using (var db = builder.Services.BuildServiceProvider().GetRequiredService<Db>())
{
    DbInitializer.RunMigrations(db, logger);
    DbInitializer.SeedDb(db, logger);
}

app.UseHealthChecks("/api/ready");
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UseAuthorization();
app.MapControllers();
app.Run();