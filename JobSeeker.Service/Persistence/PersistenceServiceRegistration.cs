using Application.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<JobSeekerDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSQL")));
        services.AddScoped<IJobSeekerRepository, JobSeekerRepository>();
        return services;
    }
}