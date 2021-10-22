using Framebook.Domain.Models;
using MongoDB.Driver;

namespace Framebook.Domain.Interfaces.Data
{
    public interface IStackContext
    {
        IMongoCollection<Stack> Stacks { get; }
    }
}
