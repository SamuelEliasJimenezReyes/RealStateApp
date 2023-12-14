﻿using RealStateApp.WebApi.Middlewares;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace RealStateApp.WebApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "RealStateApp");
                options.DefaultModelRendering(ModelRendering.Model);
            });
        }

        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandleMiddleware>();
        }
    }
}
