using Serilog;
using Shopper.Api.Middlewares;
using Shopper.Domain.Entities.Identity;

namespace Shopper.Api.Extensions
{
    public static class WebApplicationMiddlewares
    {
        public static void AddMiddlewares(this WebApplication app)
        {
            app.UseMiddleware<ErrorHandlingMiddleWare>();
            app.UseMiddleware<RequestTimeLoggingMiddleware>();
            app.UseSerilogRequestLogging();


            if (app.Environment.IsDevelopment())
            {

                app.UseSwagger(); // Add this line to enable Swagger UI

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Shopper.Api v1");
                    c.RoutePrefix = string.Empty;
                });
            }


            app.UseHttpsRedirection();

            // to add and active related routes to identity
            app.MapGroup("api/identity").

                WithTags("Identity"). // to add tags to the identity routes | merge Identity routes (in Identity Controller) under the same group
                MapIdentityApi<User>();



            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
