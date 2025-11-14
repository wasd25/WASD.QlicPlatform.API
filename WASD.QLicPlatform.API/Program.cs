using WASD.QLicPlatform.API.Shared.Domain.Repositories;
using WASD.QLicPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using WASD.QLicPlatform.API.Shared.Infrastructure.Mediator.Cortex.Configuration;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using WASD.QLicPlatform.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Cortex.Mediator.Commands;
using Cortex.Mediator.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

// Importaciones para Anomalies
using WASD.QLicPlatform.API.Anomalies.Domain.Repositories;
using WASD.QLicPlatform.API.Anomalies.Infrastructure.Persistence.EFC.Repositories;
using WASD.QLicPlatform.API.Anomalies.Domain.Services;
using WASD.QLicPlatform.API.Anomalies.Application.Internal.CommandServices;
using WASD.QLicPlatform.API.Anomalies.Application.Internal.QueryServices;

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

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (connectionString == null) throw new InvalidOperationException("Connection string not found.");


builder.Services.AddDbContext<AppDbContext>(options =>
{
    var serverVersion = new MySqlServerVersion(new Version(9, 0, 0)); // Ajusta según tu versión real de MySQL

    if (builder.Environment.IsDevelopment())
        options.UseMySql(connectionString, serverVersion)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    else if (builder.Environment.IsProduction())
        options.UseMySql(connectionString, serverVersion)
            .LogTo(Console.WriteLine, LogLevel.Error);
});

// Swagger/OpenAPI
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
builder.Services.AddScoped<IAnomalyRepository, AnomalyRepository>();
builder.Services.AddScoped<IAnomalyCommandService, AnomalyCommandService>();
builder.Services.AddScoped<IAnomalyQueryService, AnomalyQueryService>();

// Alert Bounded Context
builder.Services.AddScoped<IAlertRepository, AlertRepository>();
builder.Services.AddScoped<IAlertCommandService, AlertCommandService>();
builder.Services.AddScoped<IAlertQueryService, AlertQueryService>();

// Mediator Configuration
builder.Services.AddScoped(typeof(ICommandPipelineBehavior<>), typeof(LoggingCommandBehavior<>));
builder.Services.AddCortexMediator(
    configuration: builder.Configuration,
    handlerAssemblyMarkerTypes: [typeof(Program)], configure: options =>
    {
        options.AddOpenCommandPipelineBehavior(typeof(LoggingCommandBehavior<>));
    });

var app = builder.Build();


// Solo aplica migraciones con `dotnet ef database update`

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
