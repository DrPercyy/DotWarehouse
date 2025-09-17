//file: backend/Warehouse.Infra/DependencyInjection/ServiceCollectionExtensions.cs

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Warehouse.Infra.Data;
using Warehouse.Infra.Inventory.DependencyInjection;
using Warehouse.Infra.Inventory.Repositories;

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
            //Registra os serviços dos módulos.
            services.AddInventoryServices();

            return services;
        }
    }
}
