using Microsoft.EntityFrameworkCore;
using StockCafeterias.Datos;
using StockCafeterias.Datos.Contexto;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? Conexion.Cadena;

Conexion.Cadena = connectionString;

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StockCafeteriasContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
