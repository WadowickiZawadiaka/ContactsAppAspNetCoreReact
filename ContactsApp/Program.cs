using ContactsApp.Infrastructure.Persistence;
using ContactsApp.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using ContactsApp.Infrastructure.Seeders;
using ContactsApp.Application.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); //options => options.SuppresImplicitRequiredAttributeForNonNullableReferenceTypes = true

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

var scope = app.Services.CreateScope();

var seeder = scope.ServiceProvider.GetRequiredService<ContactSeeder>();

await seeder.Seed();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
