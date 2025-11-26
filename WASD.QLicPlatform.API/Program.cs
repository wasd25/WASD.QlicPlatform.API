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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

// Otros módulos
using WASD.QLicPlatform.API.Anomalies.Domain.Repositories;
using WASD.QLicPlatform.API.Anomalies.Infrastructure.Persistence.EFC.Repositories;
using WASD.QLicPlatform.API.Anomalies.Domain.Services;
using WASD.QLicPlatform.API.Anomalies.Application.Internal.CommandServices;
using WASD.QLicPlatform.API.Anomalies.Application.Internal.QueryServices;
using WASD.QLicPlatform.API.Alerts.Application.Internal.CommandServices;
using WASD.QLicPlatform.API.Alerts.Application.Internal.QueryServices;
using WASD.QLicPlatform.API.Alerts.Domain.Repositories;
using WASD.QLicPlatform.API.Alerts.Domain.Services;
using WASD.QLicPlatform.API.Alerts.Infrastructure.Persistence.EFC.Repositories;
using WASD.QLicPlatform.API.IAM.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using WASD.QLicPlatform.API.Profiles.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using WASD.QLicPlatform.API.Usage_Management.Application.CommandServices;
using WASD.QLicPlatform.API.Usage_Management.Application.QueryServices;
using WASD.QLicPlatform.API.Usage_Management.Domain.Repositories;
using WASD.QLicPlatform.API.Usage_Management.Domain.Services;
using WASD.QLicPlatform.API.Usage_Management.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

//
// -----------------------------
// Controllers + Route Convention
// -----------------------------
builder.Services.AddControllers(options =>
    options.Conventions.Add(new KebabCaseRouteNamingConvention()));

//
// -----------------------------
// OpenAPI / Swagger
// -----------------------------
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
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

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingrese 'Bearer' [espacio] y luego su token JWT.\r\nEjemplo: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...\""
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

//
// -----------------------------
// Database Connection (MySQL)
// -----------------------------
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var serverVersion = new MySqlServerVersion(new Version(9, 0, 0)); // Ajusta según tu versión real

    if (builder.Environment.IsDevelopment())
    {
        options.UseMySql(connectionString, serverVersion)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }
    else
    {
        options.UseMySql(connectionString, serverVersion)
            .LogTo(Console.WriteLine, LogLevel.Error);
    }
});

//
// -----------------------------
// JWT Authentication Configuration
// -----------------------------
var jwtSecretKey = builder.Configuration["Jwt:SecretKey"] ?? throw new InvalidOperationException("JWT SecretKey not found.");
var jwtIssuer = builder.Configuration["Jwt:Issuer"] ?? "qlic-platform";
var jwtAudience = builder.Configuration["Jwt:Audience"] ?? "qlic-users";

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSecretKey)),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = jwtIssuer,
        ValidAudience = jwtAudience,
        ClockSkew = TimeSpan.Zero
    };
});

//
// -----------------------------
// Dependency Injection
// -----------------------------
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Profiles
builder.AddProfilesContextServices();

// IAM
builder.AddIamContextServices();

// Alerts
builder.Services.AddScoped<IAlertRepository, AlertRepository>();
builder.Services.AddScoped<IAlertCommandService, AlertCommandService>();
builder.Services.AddScoped<IAlertQueryService, AlertQueryService>();

// Usage Management
builder.Services.AddScoped<IUsageSummaryRepository, UsageSummaryRepository>();
builder.Services.AddScoped<IUsageSummaryCommandService, UsageSummaryCommandService>();
builder.Services.AddScoped<IUsageSummaryQueryService, UsageSummaryQueryService>();
builder.Services.AddScoped<IUsageEventsRepository, UsageEventsRepository>();
builder.Services.AddScoped<IUsageEventCommandService, UsageEventsCommandService>();
builder.Services.AddScoped<IUsageEventQueryService, UsageEventsQueryService>();

// Anomalies
builder.Services.AddScoped<IAnomalyRepository, AnomalyRepository>();
builder.Services.AddScoped<IAnomalyCommandService, AnomalyCommandService>();
builder.Services.AddScoped<IAnomalyQueryService, AnomalyQueryService>();

// Reports
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<ReportCommandService>();
builder.Services.AddScoped<ReportQueryService>();

//
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

//
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

//
// -----------------------------
// Middleware Pipeline
// -----------------------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
