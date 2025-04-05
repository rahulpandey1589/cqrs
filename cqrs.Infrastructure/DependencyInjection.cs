using Cqrs.Domain.Interfaces.Dispatchers;
using Cqrs.Domain.Interfaces.Repositories;
using Cqrs.Infrastructure.Persistence;
using Cqrs.Infrastructure.Repositories;
using Cqrs.Infrastructure.Services;
using Cqrs.Shared.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cqrs.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services, IConfiguration configuration)
        {
            // MongoDb
            services.AddSingleton<MongoDbContext>();
            services.AddTransient(typeof(IDbRepository<>), typeof(MongoDbRepository<>));

            // EventStore
            var eventStoreConnectionString = "esdb://localhost:2113?tls=false";
            services.AddEventStoreClient(eventStoreConnectionString);

            services.AddSingleton<IDomainEventDispatcher, DomainEventDispatcher>();
            services.AddScoped<IEventStoreRepository, EventStoreRepository>();

            return services;
        }
    }
}
