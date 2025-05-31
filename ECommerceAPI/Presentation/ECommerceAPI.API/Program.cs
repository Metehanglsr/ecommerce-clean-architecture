using ECommerceAPI.Application;
using ECommerceAPI.Persistence;
using ECommerceAPI.Infrastructure;
using ECommerceAPI.Infrastructure.Services.Storage.Local;
using ECommerceAPI.Infrastructure.Enums;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddStorage(StorageType.Local);
builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

app.Run();