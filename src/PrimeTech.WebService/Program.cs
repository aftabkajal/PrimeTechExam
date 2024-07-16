using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PrimeTech.Interview.Business.Application.Interfaces;
using PrimeTech.Interview.Business.Application.Services;
using PrimeTech.Interview.Business.CommandHandlers.Handlers;
using PrimeTech.Interview.Business.Domain.Common;
using PrimeTech.Interview.Business.Infrastructure.Data;
using PrimeTech.Interview.Business.Infrastructure.Extensions;
using PrimeTech.Interview.Business.Infrastructure.Middleware;
using PrimeTech.Interview.Business.QueryHandlers.Handlers;
using PrimeTech.Interview.Business.WebService.Validators;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                     .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                     .AddEnvironmentVariables();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.RegisterInfrastructure();

builder.Services.RegisterCollection(
                typeof(ICommandHandler<,>),
                new[] { typeof(TestCommandHandler).Assembly });

builder.Services.RegisterCollection(
        typeof(IQueryHandler<,>),
        new[] { typeof(TestQueryHandler).Assembly });

builder.Services.RegisterCollection(
        typeof(IValidator<>),
        new[] { typeof(CreateCompanyCommandValidator).Assembly });

builder.Services.AddScoped<ICompanyCustomFieldService, CompanyCustomFieldService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();
