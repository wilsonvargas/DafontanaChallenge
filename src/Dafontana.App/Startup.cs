using Dafontana.App.Utils;
using Dafontana.Domain;
using Dafontana.Domain.Entities;
using Dafontana.Infrastructure;
using Dafontana.Infrastructure.Repositories;
using Dafontana.Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Text;

namespace Dafontana.App
{
    public static class Startup
    {
        public static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<QueryExecutor>();
            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
            IConfigurationSection configurationSection = configuration.GetSection(nameof(ConnectionString));
            services.AddDbContext<DafontanaDbContext>(options => options.UseSqlServer(configurationSection["Dafontana"]));
            services.AddTransient<IGenericRepository<Sale>, SalesRepository>();
            services.AddTransient<IGenericRepository<DetailSale>, SaleDetailsRepository>();
            services.AddTransient<IGenericRepository<Product>, ProductsRepository>();
            services.AddTransient<IGenericRepository<Store>, StoresRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
