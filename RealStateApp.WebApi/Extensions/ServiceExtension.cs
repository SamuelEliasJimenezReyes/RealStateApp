﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace RealStateApp.WebApi.Extensions
{
    public static class ServiceExtension
    {
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", searchOption: SearchOption.TopDirectoryOnly).ToList();
                xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "RealStateApp",
                    Description = "This Api will be responsible for overall data distribution",
                    Contact = new OpenApiContact
                    {
                        Name = "Eliott Reyes\nSamuel Jimenez\nDomingo Ruiz",
                        Email = "eliottreyes22@gmail.com\nsamuelelias13@hotmail.com\ndomingojruiz21@gmail.com",
                        Url = new Uri("https://www.instagram.com/ey_reyes17/"),


                    }
                }) ;



                   options.DescribeAllParametersInCamelCase();
                     options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                     {
                         Name = "Authorization",
                         In = ParameterLocation.Header,
                         Type = SecuritySchemeType.ApiKey,
                         Scheme = "Bearer",
                         BearerFormat = "JWT",
                         Description = "Input your Bearer token in this format - Bearer {your token here}"
                     });
                     options.AddSecurityRequirement(new OpenApiSecurityRequirement
                     {
                         {
                             new OpenApiSecurityScheme
                             {
                                 Reference = new OpenApiReference
                                 {
                                     Type = ReferenceType.SecurityScheme,
                                     Id="Bearer"
                                 },
                                 Scheme = "Bearer",
                                 Name = "Bearer",
                                 In = ParameterLocation.Header,
                             }, new List<string>()
                         },
                     });
              
            });
        }

        public static void AddApiVersioningExtension(this IServiceCollection services)
        {
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }
    }

}

