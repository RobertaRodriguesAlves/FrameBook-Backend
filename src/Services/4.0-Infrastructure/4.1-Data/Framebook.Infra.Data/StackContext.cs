using Framebook.Domain.Interfaces.Data;
using Framebook.Domain.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Framebook.Infra.Data
{
    public class StackContext : IStackContext
    {
        private readonly IMongoDatabase _mongoDatabase;
        public StackContext(IOptions<MongoDbSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _mongoDatabase = client.GetDatabase(settings.Value.Database);
            Stacks = _mongoDatabase.GetCollection<Stack>(settings.Value.Collection);
        }
        public IMongoCollection<Stack> Stacks { get; }
    }
}
