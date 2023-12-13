using RealStateApp.WebApi.Middlewares;

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
            });
        }

        public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandleMiddleware>();
        }
    }
}
