using Api.Core.Common.Interfaces.Services;
using Api.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Infrastructure;

public static class ServiceExtensions
{
    public static void AddInfrastructureLayer(this IServiceCollection services)//, IConfiguration configuration)
    {
        //No existe en NET 8, solo en NET 6
        //services.AddHttpClient();
        //Ficticio
        services.AddHttpContextAccessor();

        services.AddTransient<ICurrentUserService, CurrentUserService>();
    }
}
