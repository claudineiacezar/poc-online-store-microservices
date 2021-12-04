using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.SyncDataServices.Http;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// I add that********************************
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("ProductInMem"));
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
PrepDB.Prepopulation(app);

Console.WriteLine($"--> Inventory Service Endpoint{builder.Configuration["InventoryService"]}");

app.Run();

