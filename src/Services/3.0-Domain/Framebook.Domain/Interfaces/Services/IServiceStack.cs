using Framebook.Business.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framebook.Domain.Interfaces.Services
{
    public interface IServiceStack
    {
        Task<StackDTO> GetById(string id);
        Task<bool> PostStack(StackDTO stack);
        Task<bool> DeleteById(string id);
        Task<IEnumerable<StackDTO>> GetAllStacks();
        Task<bool> UpdateStack(StackDTO stack);
    }
}
