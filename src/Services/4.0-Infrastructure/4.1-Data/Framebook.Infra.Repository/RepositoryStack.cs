using Framebook.Domain.Interfaces.DataSettings;
using Framebook.Domain.Interfaces.Repositories;
using Framebook.Domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framebook.Infra.Repository
{
    public class RepositoryStack : IRepositoryStack
    {
        private readonly IMongoCollection<Stack> _stacksCollection;
        public RepositoryStack(IMongoDbSettings mongoDbSettings)
        {
            var client = new MongoClient(mongoDbSettings.ConnectionString);
            var database = client.GetDatabase(mongoDbSettings.DatabaseName);

            _stacksCollection = database.GetCollection<Stack>("Stacks");
        }

        public async Task<Stack> GetById(string id)
        {
            return await _stacksCollection.Find(stack => stack.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<bool> PostStack(Stack stack)
        {
            try
            {
                await _stacksCollection.InsertOneAsync(stack);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteById(string id)
        {
            try
            {
                await _stacksCollection.DeleteOneAsync(stack => stack.Id.Equals(id));
                return true;
            }
            catch (ArgumentException)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Stack>> GetAllStacks()
        {
            try
            {
                return await _stacksCollection.Find(stacks => true).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> UpdateStack(Stack stack)
        {
            try
            {
                var response = await _stacksCollection.ReplaceOneAsync(find => find.Id == stack.Id, stack);
                if (response.MatchedCount == 0)
                    return false;

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
