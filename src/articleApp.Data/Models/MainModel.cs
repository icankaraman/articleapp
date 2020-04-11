using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace articleApp.Data.Models
{
    public abstract class MainModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public byte Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}