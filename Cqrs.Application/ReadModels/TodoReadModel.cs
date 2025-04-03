using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Cqrs.Application.ReadModels
{
    public class TodoReadModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        public string TodoName { get; set; } = default!;

        public bool IsCompleted {  get; set; }  
    }
}
