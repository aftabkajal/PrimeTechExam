using Microsoft.Extensions.DependencyInjection;
using PrimeTech.Interview.Business.Domain.AggregatesModel.Companies;
using PrimeTech.Interview.Business.Domain.Dispatchers;
using PrimeTech.Interview.Business.Domain.Interfaces.Repositories;
using PrimeTech.Interview.Business.Infrastructure.Common;
using PrimeTech.Interview.Business.Infrastructure.Dispatcher;
using PrimeTech.Interview.Business.Infrastructure.Repositories;
using PrimeTech.Interview.Business.Infrastructure.Repositories.Companies;

namespace PrimeTech.Interview.Business.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
    {
        services.AddScoped<CommandHandler>();
        services.AddScoped<QueryHandler>();

        services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        services.AddScoped<IQueryDispatcher, QueryDispatcher>();

        services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
        services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));

        services.AddScoped<ICompanyReadRepository, CompanyReadRepository>();
        services.AddScoped<ICompanyWriteRepository, CompanyWriteRepository>();

        return services;
    }
}

