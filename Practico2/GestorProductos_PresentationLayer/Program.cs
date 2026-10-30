using GestorProductos_BusinessLayer.Services;
using GestorProductos_DataAccessLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Agregar servicios de Controladores y Swagger
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// 2. Inyección de Dependencias (Inscribir las implementaciones)
builder.Services.AddScoped<IProductoRepository, ProductoRepositoryInMemory>();
builder.Services.AddScoped<IProductoService, ProductoService>();

var app = builder.Build();

// 3. Pipeline HTTP (Entorno de desarrollo)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();