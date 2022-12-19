using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TodoListMvc.Models
{
    public class Todo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string TodoWork { get; set; }
        public DateTime TodoDateTime { get; set; }
        public bool IsCompleted { get; set; }
    }
}