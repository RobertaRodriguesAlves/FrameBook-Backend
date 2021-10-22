using Framebook.Domain.Interfaces.Repositories;
using Framebook.Domain.Models;
using Framebook.Infra.Data;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framebook.Infra.Repository
{
    public class RepositoryStack : IRepositoryStack
    {
        private readonly StackContext _context;
        public RepositoryStack(IOptions<MongoDbSettings> settings)
        {
            _context = new StackContext(settings);
        }

        public async Task<Stack> GetById(string id)
        {
            return await _context.Stacks.Find(stack => stack.Id.Equals(id)).SingleOrDefaultAsync();
        }

        public async Task<bool> PostStack(Stack stack)
        {
            try
            {
                await _context.Stacks.InsertOneAsync(stack);
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
                await _context.Stacks.DeleteManyAsync(stack => stack.Id.Equals(id));
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
                return await _context.Stacks.Find(_ => true).ToListAsync();
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
                var response = await _context.Stacks.ReplaceOneAsync(find => find.Id == stack.Id, stack);
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
