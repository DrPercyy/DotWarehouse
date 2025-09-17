using Microsoft.Extensions.DependencyInjection;
using Warehouse.Core.Inventory.Interfaces.Repositories;
using Warehouse.Core.Inventory.Interfaces.Services; 
using Warehouse.Infra.Inventory.Services;  
using Warehouse.Infra.Inventory.Repositories;
using Warehouse.Infra.Inventory.Services.Interfaces;

namespace Warehouse.Infra.Inventory.DependencyInjection {
    public static class InventoryServiceCollectionExtensions {
        public static IServiceCollection AddInventoryServices(this IServiceCollection services) {

            // Serviços
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IUnitRepository, UnitRepository>();

            services.AddScoped<IMovementRepository, MovementRepository>();
            services.AddScoped<IMovementService, MovementService>();

            return services;
        }
    }

}