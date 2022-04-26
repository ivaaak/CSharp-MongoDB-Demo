using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace MongoCore.Domain.Model
{
    public class Blog
    {
        [BsonId]
        [JsonProperty("objectId")]
        public ObjectId ObjectId { get; set; }

        [Key]
        public int BlogId { get; set; }

        public string Title { get; set; }
    }
}
