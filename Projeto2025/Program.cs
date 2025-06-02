using Infraestrutura.Contexto;
using Interfaces.Models;
using Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Projeto2025.Models;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registrar o DbContext no contêiner de Injeção de Dependência
builder.Services.AddDbContext<EmpresaContexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IClienteModels, ClienteModel>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddScoped<IEventoModels, EventoModel>();
builder.Services.AddScoped<IEventoRepository, EventoRepositry>();

builder.Services.AddScoped<IFormaPagamentoModels, FormaPagamentoModel>();
builder.Services.AddScoped<IFormaPagamentoRepository, FormaPagamentoRepository>();

builder.Services.AddScoped<IServicoModels, ServicoModel>();
builder.Services.AddScoped<IServicoRepository, ServicoRepository>();

builder.Services.AddScoped<ITipoEventoModels, TipoEventoModel>();
builder.Services.AddScoped<ITipoEventoRepository, TipoEventoRepository>();

builder.Services.AddScoped<IUsuarioModels, UsuarioModel>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

builder.Services.AddScoped<IVendaModels, VendaModels>();
builder.Services.AddScoped<IVendaRepository, VendaRepository>();

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

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
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Login}/{id?}");

app.Run();
