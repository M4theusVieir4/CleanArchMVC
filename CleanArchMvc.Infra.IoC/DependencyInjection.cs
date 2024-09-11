
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using CleanArchMvc.Application.Mappings;
using CleanArchMvc.Application.Services;

using CleanArchMvc.Infra.Data.Repositories;
using CleanArchMvc.Infra.Data.Context;
using CleanArchMvc.Domain.Interface;
using CleanArchMvc.Application.Interfaces;


namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static Microsoft.Extensions.DependencyInjection.IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
                ), b=> b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository,  ProductRepository>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
