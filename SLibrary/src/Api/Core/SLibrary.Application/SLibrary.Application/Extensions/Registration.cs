using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace SLibrary.Application.Extensions;
public static class Registration
{

    public static IServiceCollection AddApplicationRegistration(this IServiceCollection services)
    {
        var assm = Assembly.GetExecutingAssembly();

        services.AddAutoMapper(assm);

        return services;
    }
}

