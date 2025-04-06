using System.Reflection;
using Cqrs.Application.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Cqrs.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
       // services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}