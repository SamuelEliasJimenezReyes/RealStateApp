using RealStateApp.Core.Application;
using RealStateApp.Infraestructure.Identity;
using RealStateApp.Infraestructure.Shared;
using System.Reflection;

using Microsoft.AspNetCore.Identity;
using RealStateApp.Infrastructure.Identity.Entities;
using RealStateApp.Infrastructure.Identity.Seeds;
using RealStateApp.Infrastructure.Identity;
using RealState.Infraestructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddSharedLayer(builder.Configuration);
builder.Services.AddApplicationLayer();





var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var userManager = services.GetRequiredService<UserManager<AppUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        await DefaultRoles.SeedAsync(userManager, roleManager);
        await DefaultDeveloperUser.SeedAsync(userManager, roleManager);
    }
    catch (Exception ex)
    {

    }
}

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
