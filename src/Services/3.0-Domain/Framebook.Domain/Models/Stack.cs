using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Framebook.Domain.Models
{
    public class Stack 
    {
        [BsonId]
        public string Id { get; set; }

        [BsonElement("Nome")]
        public string Nome { get; set; }
    }
}
