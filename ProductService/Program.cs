using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProductService.Data;
using ProductService.SyncDataServices.Http;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// I add that********************************

if(builder.Environment.IsProduction())
{
    Console.WriteLine("--> Using SQL Db");
    builder.Services.AddDbContext<AppDbContext>(opt => 
        opt.UseSqlServer(builder.Configuration.GetConnectionString("ProductConn")));
}
else
{
    Console.WriteLine("--> Using InMem Db");
    builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("ProductInMem"));
}

builder.Services.AddScoped<IProductRepo, ProductRepo>();
builder.Services.AddHttpClient<IProductDataClient, HttpProductDataClient>();
//************************************************
builder.Services.AddControllers();

//I add that **********************************
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//******************************************
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//I add that
PrepDB.Prepopulation(app, builder.Environment.IsProduction());

Console.WriteLine($"--> Inventory Service Endpoint{builder.Configuration["InventoryService"]}");

app.Run();

