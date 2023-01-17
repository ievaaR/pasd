namespace ddapi.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

[BsonIgnoreExtraElements]
public class Delivery {
      [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("id")]
    public int _Id {get; set; }
}