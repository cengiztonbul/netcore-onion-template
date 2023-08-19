using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnionTemplate.Application.Interfaces.Repositories;
using OnionTemplate.Persistence.Context;

namespace OnionTemplate.Persistence;

public static class ServiceRegisteration
{
    public static void AddPersistenceRegistration(this IServiceCollection service, IConfiguration configuration)
    {
		string? connectionString = configuration.GetConnectionString("DefaultConnection");
		service.AddNpgsql<ApplicationDbContext>(connectionString);
        service.AddTransient<IExampleEntityRepository, ExampleEntityRepository>();
    }
}
