using Microsoft.OpenApi.Models;

namespace Shopper.Api.Extensions
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                // adding swagger documentation
                c.SwaggerDoc("v1", new() { Title = "Shopper.Api", Version = "v1" });
                // enabling JWT authentication in swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: Bearer {token}",
                    Scheme = "Bearer",
                    Type = SecuritySchemeType.Http,
                });

                // to add token to header in swagger

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
            // adds the necessary service to generate OpenAPI documentation for your API endpoints, which can be accessed through Swagger UI.
            builder.Services.AddEndpointsApiExplorer();
        }
    }
}
