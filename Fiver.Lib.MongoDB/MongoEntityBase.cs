using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Fiver.Lib.MongoDB
{
    public abstract class MongoEntityBase
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
