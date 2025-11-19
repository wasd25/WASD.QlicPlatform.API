using WASD.QLicPlatform.API.Shared.Domain.Repositories;
using WASD.QLicPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using WASD.QLicPlatform.API.Shared.Infrastructure.Mediator.Cortex.Configuration;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Cortex.Mediator.Commands;
using Cortex.Mediator.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WASD.QLicPlatform.API.IAM.Application.Services;
using WASD.QLicPlatform.API.IAM.Domain.Repositories;
using WASD.QLicPlatform.API.IAM.Infrastructure.Persistence.Repositories;
using WASD.QLicPlatform.API.IAM.Infrastructure.Services;
using WASD.QLicPlatform.API.Profile.Domain.Repositories;
using WASD.QLicPlatform.API.Profile.Infrastructure.Persistence.Repositories;
using WASD.QLicPlatform.API.Alerts.Application.Internal.CommandServices;
using WASD.QLicPlatform.API.Alerts.Application.Internal.QueryServices;
using WASD.QLicPlatform.API.Alerts.Domain.Repositories;
using WASD.QLicPlatform.API.Alerts.Domain.Services;
using WASD.QLicPlatform.API.Alerts.Infrastructure.Persistence.EFC.Repositories;
using WASD.QLicPlatform.API.Usage_Management.Application.CommandServices;
using WASD.QLicPlatform.API.Usage_Management.Application.QueryServices;
using WASD.QLicPlatform.API.Usage_Management.Domain.Repositories;
using WASD.QLicPlatform.API.Usage_Management.Domain.Services;
using WASD.QLicPlatform.API.Usage_Management.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connectionString == null) throw new InvalidOperationException("Connection string not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (builder.Environment.IsDevelopment())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    else if (builder.Environment.IsProduction())
        options.UseMySQL(connectionString)
            .LogTo(Console.WriteLine, LogLevel.Error);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    
    options.SwaggerDoc("v1",
        new OpenApiInfo()
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

// Dependency Injection

// Registrar servicios del BC Profile
builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();

//Registrar servicios de IAM
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
builder.Services.AddScoped<ITokenService, JwtTokenService>();

// Shared Bounded Context 
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Alert Bounded Context 
builder.Services.AddScoped<IAlertRepository, AlertRepository>();
builder.Services.AddScoped<IAlertCommandService, AlertCommandService>();
builder.Services.AddScoped<IAlertQueryService, AlertQueryService>(); 


// Usage Management Bounded Context

// Usage Summary
builder.Services.AddScoped<IUsageSummaryRepository, UsageSummaryRepository>();
builder.Services.AddScoped<IUsageSummaryCommandService, UsageSummaryCommandService>();
builder.Services.AddScoped<IUsageSummaryQueryService, UsageSummaryQueryService>();

// Usage Events
builder.Services.AddScoped<IUsageEventsRepository, UsageEventsRepository>();
builder.Services.AddScoped<IUsageEventCommandService, UsageEventsCommandService>();
builder.Services.AddScoped<IUsageEventQueryService, UsageEventsQueryService>();

// Mediator Configuration

// Add Mediator Injection Configuration
builder.Services.AddScoped(typeof(ICommandPipelineBehavior<>), typeof(LoggingCommandBehavior<>));

// Add Cortex Mediator for Event Handling
builder.Services.AddCortexMediator(
    configuration: builder.Configuration,
    handlerAssemblyMarkerTypes: [typeof(Program)], configure: options =>
    {
        options.AddOpenCommandPipelineBehavior(typeof(LoggingCommandBehavior<>));
        //options.AddDefaultBehaviors();
    });

var app = builder.Build();

// Verify if the database exists and create it if it doesn't
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();

    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();