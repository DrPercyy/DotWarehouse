using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Warehouse.Infra.Data;

namespace Warehouse.Infra
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Configura o DbContext para usar MySQL
            services.AddDbContext<WarehouseDbContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(8, 0, 33)) // versão do MySQL
                )
            );

            // Aqui você pode registrar outros serviços de Infra
            // services.AddScoped<IUnitRepository, UnitRepository>();
            // services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
