using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoCore.Domain.Model
{
    public class UserModel
    {
        [BsonId]  //id
        public Guid Id { get; set; }
        public string UserName { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserAddress Address { get; set; }

        [BsonElement("BirthDate")]
        public DateTime BirthDate { get; set; }
    }
}
