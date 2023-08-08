using ContactsApp.Application.Contact.Commands.CreateContact;
using ContactsApp.Application.Contacts.Commands.CreateContact;
using ContactsApp.Application.Mappings;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Application.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreateContactCommand)));

            services.AddAutoMapper(typeof(ContactMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateContactCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }
}

