using eCommerce.Core.RepositoryContracts;
using eCommerce.InfraStructure.DbContext;
using eCommerce.InfraStructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.InfraStructure;
public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add services
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfraStructure(this IServiceCollection services)
    {
        services.AddSingleton<IUserRepository, UserRepository>();

        services.AddTransient<DapperDbContext>();
        //Add services here like cahcing etc
        return services;
    }
}