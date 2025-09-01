using Microsoft.EntityFrameworkCore;
using Warehouse.Infra;
using Warehouse.Infra.Data;
using Warehouse.API.Filters;
using Warehouse.Infra.Inventory.Repositories;
using Warehouse.Infra.Inventory.Services;
using Warehouse.Infra.Inventory.Services.Interfaces;
using Warehouse.API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Conexão com MySQL usando Pomelo
builder.Services.AddDbContext<WarehouseDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("WarehouseConnection"),
        new MySqlServerVersion(new Version(8, 0, 36))
    )
);

// Feature flag
bool inventoryEnabled = builder.Configuration.GetValue<bool>("Features:Inventory");


// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar o filtro com o nome da feature
builder.Services.AddControllers();

// Aqui você poderia registrar serviços do módulo Inventory

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

// Pipeline HTTP
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DotWarehouse API V1");
    c.RoutePrefix = string.Empty;
});

// Mapear controllers normalmente
app.MapControllers();


// Opcional: impedir que controllers do Inventory respondam se feature desativada
if (!inventoryEnabled)
{
    app.MapWhen(context => context.Request.Path.StartsWithSegments("/inventory"), appBuilder =>
    {
        appBuilder.Run(async context =>
        {
            context.Response.StatusCode = 404;
            await context.Response.CompleteAsync();
        });
    });
}

app.Run();
