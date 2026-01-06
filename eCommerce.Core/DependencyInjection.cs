using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using eCommerce.InfraStructure.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
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
        services.AddTransient<IUserService, UserService>();

        //add fluent validation dependency here
        services.AddValidatorsFromAssemblyContaining<LoginRequest>();
        //Add services here like cahcing etc
        return services;
    }
}