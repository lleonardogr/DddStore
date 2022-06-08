using DddStore.Catalogo.Application.Mappings;
using DddStore.Catalogo.Data;
using DddStore.Catalogo.Domain.Events;
using DddStore.Vendas.Data;
using DddStore.WebApp.Mvc.Setup;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), 
    typeof(ViewModelToDomainMappingProfile));
builder.Services.AddMediatR(typeof(Program));

var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

builder.Services.AddDbContext<CatalogoContext>(options => 
    options.UseSqlServer(configuration.GetConnectionString("AppDb")));
builder.Services.AddDbContext<VendasContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("AppDb")));

builder.Services.RegisterServices();

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
    pattern: "{controller=Vitrine}/{action=Index}/{id?}");

app.Run();
