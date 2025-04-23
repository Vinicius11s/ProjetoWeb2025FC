using Infraestrutura.Contexto;
using Interfaces.Models;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Projeto2025.Models;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registrar o DbContext no cont�iner de Inje��o de Depend�ncia
builder.Services.AddDbContext<EmpresaContexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IClienteModels, ClienteModel>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddScoped<IEventoModels, EventoModel>();
builder.Services.AddScoped<IEventoRepository, EventoRepositry>();

builder.Services.AddScoped<ITipoEventoModels, TipoEventoModel>();
builder.Services.AddScoped<ITipoEventoRepository, TipoEventoRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
