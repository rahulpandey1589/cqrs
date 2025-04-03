using Cqrs.Domain.Interfaces.Repositories;
using Cqrs.Infrastructure.Persistence;
using Cqrs.Infrastructure.Repositories;
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

            //// EventStore
            //var eventStoreConnectionString = configuration.GetValue<string>($"{SettingConstants.DatabaseSettings}:{SettingConstants.EventStoreConnectionString}");
            //services.AddEventStoreClient(eventStoreConnectionString);

            //services.AddSingleton<IDomainEventDispatcher, DomainEventDispatcher>();
            //services.AddScoped<IEventStoreRepository, EventStoreRepository>();

            return services;
        }
    }
}
