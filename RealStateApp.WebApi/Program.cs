using RealStateApp.Core.Application;
using RealStateApp.Infraestructure.Shared;
using RealStateApp.WebApi.Extensions;
using Microsoft.AspNetCore.Identity;
using RealStateApp.Infrastructure.Identity.Entities;
using RealStateApp.Infrastructure.Identity.Seeds;
using RealStateApp.Infrastructure.Identity;
using RealState.Infraestructure.Persistence;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => { options.Filters.Add(new ProducesAttribute("application/json")); })
    .ConfigureApiBehaviorOptions(options => {
        options.SuppressInferBindingSourcesForParameters = true;
        
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentityInfrastructureForApi(builder.Configuration);
builder.Services.AddPersistenceInfrastructure(builder.Configuration);
builder.Services.AddSharedLayer(builder.Configuration);
builder.Services.AddApplicationLayer();
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddApiVersioningExtension();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddSwaggerExtension();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var userManager = services.GetRequiredService<UserManager<AppUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        await DefaultRoles.SeedAsync(userManager, roleManager);
        await DefaultAdminUser.SeedAsync(userManager, roleManager);
        await DefaultDeveloperUser.SeedAsync(userManager, roleManager);
        await DefaultClientUser.SeedAsync(userManager, roleManager);
        await DefaultAgentUser.SeedAsync(userManager, roleManager);
        


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


app.UseRouting();



app.UseHealthChecks("/health");

app.UseSession();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwaggerExtension();
app.UseErrorHandlingMiddleware();
app.MapControllers();

app.Run();
