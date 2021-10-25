using Framebook.Domain.Interfaces.DataSettings;

namespace Framebook.Infra.Data
{
    public class MongoDbSettings : IMongoDbSettings
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}
