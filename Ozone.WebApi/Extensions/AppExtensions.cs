using Microsoft.AspNetCore.Builder;
//using Ozone.WebApi.Middlewares;

namespace Ozone.WebApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CleanArchitecture.Ozone.WebApi");
            });
        }
        //public static void UseErrorHandlingMiddleware(this IApplicationBuilder app)
        //{
        //    app.UseMiddleware<ErrorHandlerMiddleware>();
        //}
    }
}
