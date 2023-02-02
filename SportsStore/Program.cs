using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); // set up objects known as services that are accessed through dependency injection

builder.Services.AddDbContext<StoreDbContext>(opts =>
{
    opts.UseSqlServer(
        builder.Configuration["ConnectionString:SportsStoreConnection"]
    );
});

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

var app = builder.Build();

// app.MapGet("/", () => "Hello World!");

//Setting up middleware components
app.UseStaticFiles();
app.MapDefaultControllerRoute(); //registers MVC framework as source of endpoints using default conventions to map requests to classes and methods.... the whole 'Views' thing

SeedData.EnsurePopulated(app);

app.Run();
