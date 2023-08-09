using ContactsApp.Domain.Interfaces;
using ContactsApp.Infrastructure.Persistence;
using ContactsApp.Infrastructure.Repositories;
using ContactsApp.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        { 
            services.AddDbContext<ContactDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("Contacts")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<ContactDbContext>();

            services.AddScoped<ContactSeeder>();

            services.AddScoped<IContactRepository, ContactRepository>();
        }
    }
}
