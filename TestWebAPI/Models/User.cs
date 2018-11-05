using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebAPI.Models
{
    public class User
    {
        public ObjectId Id { get; set; }
        [BsonElement("UserId")]
        public string UserId { get; set; }
        [BsonElement("UserName")]
        public string UserName { get; set; }
        [BsonElement("Phone")]
        public string Phone { get; set; }
        [BsonElement("Birthday")]
        public string Birthday { get; set; }
    }
}
