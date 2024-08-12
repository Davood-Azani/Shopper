using Shopper.Api.Middlewares;
using Shopper.Application.Extensions;
using Shopper.Infrastructure.Extensions;

namespace Shopper.Api.Extensions
{
    public static class WebApplicationServiceExtension
    {
        public static void AddPresentation(this WebApplicationBuilder builder)
        {
            // Add services to the container.

            // activating authentication on the application
            builder.Services.AddAuthentication();

            #region Services
            builder.Services.AddControllers();

            #region Swagger

            builder.AddSwaggerConfiguration();

            #endregion


            var configuration = builder.Configuration;
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(configuration);
            builder.Host.ConfigureSerilog();
            builder.Services.AddScoped<ErrorHandlingMiddleWare>();
            builder.Services.AddScoped<RequestTimeLoggingMiddleware>();
            #endregion
        }
    }
}
