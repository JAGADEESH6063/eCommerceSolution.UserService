using eCommerce.Core.ServiceContracts;
using eCommerce.InfraStructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;
public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add services
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        services.AddSingleton<IUserService, UserService>();
        //Add services here like cahcing etc
        return services;
    }
}