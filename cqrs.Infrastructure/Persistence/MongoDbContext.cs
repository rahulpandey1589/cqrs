using Cqrs.Shared.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Cqrs.Infrastructure.Persistence
{
    public class MongoDbContext
    {
        public IMongoDatabase MongoDatabase { get; }

        public MongoDbContext(IOptions<DbSettingModel> databaseSettings)
        {
            var client = new MongoClient(databaseSettings.Value.MongoDbConnectionString);
            MongoDatabase = client.GetDatabase(databaseSettings.Value.MongoDbDatabaseName);
        }
    }
}
