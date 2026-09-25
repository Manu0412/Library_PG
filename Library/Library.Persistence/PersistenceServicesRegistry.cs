using Library.Application.Contracts.Repositories;
using Library.Persistence.Repositories;
using Library.Persistence.Seeds;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence
{
    public static class PersistenceServicesRegistry
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("MyConnection"));
            });

            services.AddScoped<IBookRepository, BookRepository>();

            // Seeders
            services.AddScoped<IDataSeeder, CategorySeeder>();
            services.AddScoped<IDataSeeder, AuthorSeeder>();
            services.AddScoped<IDataSeeder, BookSeeder>();

            return services;
        }
    }
}
