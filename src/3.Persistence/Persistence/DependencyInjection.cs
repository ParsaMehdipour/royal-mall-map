using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Data;

namespace Persistence;

/// <summary>
/// Persistence setup
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Set's persistence's dependency injections
    /// </summary>
    /// <param name="services">IServiceCollection</param>
    /// <param name="sQLConnectionString">SQL connection string</param>
    public static void AddPersistence(this IServiceCollection services,
        string sQLConnectionString) => services.Setup(sQLConnectionString);

    /// <summary>
    /// Set's persistence's service dependency injections
    /// </summary>
    /// <param name="services">IServiceCollection</param>
    /// <param name="sQLConnectionString">SQL connection string</param>
    private static void Setup(this IServiceCollection services,
        string sQLConnectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(sQLConnectionString));
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();

    }
}
