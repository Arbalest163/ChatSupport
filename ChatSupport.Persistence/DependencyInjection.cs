using ChatSupport.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatSupport.Persistence;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistence
        (this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];
        services.AddDbContext<ChatSupportDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
        services.AddScoped<IChatSupportDbContext>(provider =>
            provider.GetService<ChatSupportDbContext>());
        return services;
    }
}

