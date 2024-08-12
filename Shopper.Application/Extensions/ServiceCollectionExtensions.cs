

using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Shopper.Application.Users;


namespace Shopper.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtensions).Assembly;

        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(applicationAssembly));
      
        services.AddAutoMapper(applicationAssembly);

        services.AddValidatorsFromAssembly(applicationAssembly)
            .AddFluentValidationAutoValidation();
            

        services.AddScoped<IUserContext, UserContext>();
        services.AddHttpContextAccessor();

    }
}
