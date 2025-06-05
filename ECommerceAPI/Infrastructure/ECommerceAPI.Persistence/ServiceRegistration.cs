using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities.Identity;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceAPI.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomerReadRepository,CustomerReadRepository>();
        services.AddScoped<ICustomerWriteRepository,CustomerWriteRepository>();

        services.AddScoped<IAddressReadRepository,AddressReadRepository>();
        services.AddScoped<IAddressWriteRepository,AddressWriteRepository>();

        services.AddScoped<IProductReadRepository,ProductReadRepository>();
        services.AddScoped<IProductWriteRepository,ProductWriteRepository>();

        services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();
        services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();

        services.AddScoped<IBasketItemReadRepository, BasketItemReadRepository>();
        services.AddScoped<IBasketItemWriteRepository, BasketItemWriteRepository>();

        services.AddScoped<IBasketReadRepository, BasketReadRepository>();
        services.AddScoped<IBasketWriteRepository, BasketWriteRepository>();

        services.AddScoped<IOrderReadRepository, OrderReadRepository>();
        services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();

        services.AddScoped<IOrderItemReadRepository, OrderItemReadRepository>();
        services.AddScoped<IOrderItemWriteRepository, OrderItemWriteRepository>();

        services.AddScoped<IFileReadRepository, FileReadRepository>();
        services.AddScoped<IFileWriteRepository, FileWriteRepository>();
        
        services.AddScoped<IProductImageFileReadRepository,ProductImageFileReadRepository>();
        services.AddScoped<IProductImageFileWriteRepository,ProductImageFileWriteRepository>();
        
        services.AddScoped<IInvoiceFileReadRepository, InvoiceFileReadRepository>();
        services.AddScoped<IInvoiceFileWriteRepository, InvoiceFileWriteRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();


        services.AddDbContext<ECommerceAPIDbContext>(options =>
            options.UseMySql(Configuration.ConnectionString,
                new MySqlServerVersion(new Version(8, 0)))
        );
        services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ECommerceAPIDbContext>();
    }
}