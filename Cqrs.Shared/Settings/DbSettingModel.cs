namespace Cqrs.Shared.Settings
{
    public class DbSettingModel
    {
        public required string MongoDbConnectionString { get; init; }
        public required string MongoDbDatabaseName { get; init; }
    }
}
