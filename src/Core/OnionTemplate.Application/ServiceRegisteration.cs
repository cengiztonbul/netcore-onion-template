using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace OnionTemplate.Application;

public static class ServiceRegisteration
{
    public static void AddApplicationRegistration(this IServiceCollection service)
    {
        var asm = Assembly.GetExecutingAssembly();
        service.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(asm));
        service.AddAutoMapper(asm);
    }
}