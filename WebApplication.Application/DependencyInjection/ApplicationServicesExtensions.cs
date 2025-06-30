using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication.Application.Common.Behavior;
using WebApplication.Application.Common.Validation;
using WebApplication.Application.Features.Common;
using WebApplication.Application.Interfaces;
using WebApplication.Application.Services;

namespace WebApplication.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(typeof(DependencyInjection).Assembly);

        services.AddAutoMapper(typeof(DependencyInjection).Assembly);

        services.AddScoped<IActions, Actions>();

        services.AddScoped<ITokenService, TokenService>();

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CacheBehavior<,>));

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CacheInvalidateBehavior<,>));

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

        services.AddValidatorsFromAssemblies([typeof(DependencyInjection).Assembly]);

        return services;
    }
}
