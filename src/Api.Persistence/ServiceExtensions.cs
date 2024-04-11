using Api.Core.Common.Interfaces.Persistence;
using Api.Persistence.Context;
using Api.Persistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Persistence;

public static class ServiceExtensions
{
    public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("AppConnection")!,
                x => x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName).EnableRetryOnFailure()));

        services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
    }
}
