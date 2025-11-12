using WASD.QLicPlatform.API.Shared.Domain.Repositories;
using WASD.QLicPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using WASD.QLicPlatform.API.Shared.Infrastructure.Mediator.Cortex.Configuration;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using WASD.QLicPlatform.API.Reports.Domain.Repositories;
using WASD.QLicPlatform.API.Reports.Infrastructure.Persistence.EFC.Repositories;
using WASD.QLicPlatform.API.Reports.Application.Internal.CommandServices;
using WASD.QLicPlatform.API.Reports.Application.Internal.QueryServices;
using Cortex.Mediator.Commands;
using Cortex.Mediator.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// -----------------------------
// Controllers + Route Convention
// -----------------------------
builder.Services.AddControllers(options =>
    options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// -----------------------------
// OpenAPI / Swagger
// -----------------------------
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo
        {
            Title = "WASD.QLicPlatform.API",
            Version = "v1",
            Description = "WASD QLic Platform API",
            TermsOfService = new Uri("https://wasd-qlic.com/tos"),
            Contact = new OpenApiContact
            {
                Name = "WASD Corporation",
                Email = "contact@wasd.com"
            },
            License = new OpenApiLicense
            {
                Name = "Apache 2.0",
                Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
            }
        });
    options.EnableAnnotations();
});

// -----------------------------
// Database Connection (MySQL)
// -----------------------------
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }
    else
    {
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error);
    }
});

// -----------------------------
// Dependency Injection
// -----------------------------
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Reports Module
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<ReportCommandService>();
builder.Services.AddScoped<ReportQueryService>();

// -----------------------------
// Mediator Configuration
// -----------------------------
builder.Services.AddScoped(typeof(ICommandPipelineBehavior<>), typeof(LoggingCommandBehavior<>));
builder.Services.AddCortexMediator(
    configuration: builder.Configuration,
    handlerAssemblyMarkerTypes: [typeof(Program)],
    configure: options =>
    {
        options.AddOpenCommandPipelineBehavior(typeof(LoggingCommandBehavior<>));
        // options.AddDefaultBehaviors();
    });

// -----------------------------
// Build App
// -----------------------------
var app = builder.Build();

// Ensure database exists
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// -----------------------------
// Middleware Pipeline
// -----------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
