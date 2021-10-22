using Framebook.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framebook.Domain.Interfaces.Repositories
{
    public interface IRepositoryStack
    {
        Task<Stack> GetById(string id);
        Task<bool> PostStack(Stack stack);
        Task<bool> DeleteById(string id);
        Task<IEnumerable<Stack>> GetAllStacks();
        Task<bool> UpdateStack(Stack stack);
    }
}
