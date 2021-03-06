using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SLibrary.Application.Interfaces.Repositories;
using SLibrary.Infrastructure.Persistence.Context;
using SLibrary.Infrastructure.Persistence.Repositories;

namespace SLibrary.Infrastructure.Persistence.Extensions;
public static class Registration
{
    public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SLibraryContext>(
            conf =>
            {
                var connStr = configuration["SLibraryDbConnectionString"].ToString();
                conf.UseSqlServer(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            });

        var seedData = new SeedData();
        seedData.SeedAsync(configuration).GetAwaiter().GetResult();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBookRepository, BookRepository>();

        return services;
    }
}
