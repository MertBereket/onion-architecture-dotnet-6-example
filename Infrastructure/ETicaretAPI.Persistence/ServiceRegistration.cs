using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.Extensions.Configuration;
using ETicaretAPI.Persistence.Repostories.Customers;
using ETicaretAPI.Application.Repostories.Customers;
using ETicaretAPI.Application.Repostories.Orders;
using ETicaretAPI.Persistence.Repostories.Orders;
using ETicaretAPI.Application.Repostories.Products;
using ETicaretAPI.Persistence.Repostories.Products;

namespace ETicaretAPI.Persistence
{
	public static class ServiceRegistration
	{
		public static void AddPersistenceServices(this IServiceCollection services)
		{
			//services.AddSingleton<IProductService, ProductService>();
			services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString)) ;
			services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
			services.AddScoped<ICustomerWriteRepository, CustomerWriteRepsitory>();
			services.AddScoped<IOrderReadRepository, OrderReadRepository>();
			services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
			services.AddScoped<IProductReadRepository, ProductReadRepository>();
			services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
		}
	}
}

