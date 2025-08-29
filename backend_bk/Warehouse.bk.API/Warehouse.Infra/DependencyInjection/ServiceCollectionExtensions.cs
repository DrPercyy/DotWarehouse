public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInventoryWarehouseInfra(this IServiceCollection services, IConfiguration configuration)
    {
        // Register infrastructure services here
        // e.g., services.AddDbContext<WarehouseDbContext>(options => ...);
        // e.g., services.AddScoped<IWarehouseRepository, WarehouseRepository>();
        services.AddDbContext<WarehouseDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("WarehouseDatabase")));

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IUnitRepository, UnitRepository>();
        services.AddScoped<IMovementRepository, MovementRepository>();
        return services;
    }
}