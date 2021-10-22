using Framebook.Business.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framebook.Business.Interfaces
{
    public interface IBusinessServiceGestaoStack
    {
        Task<StackDTO> GetById(string id);
        Task<bool> PostStack(StackDTO stack);
        Task<bool> DeleteById(string id);
        Task<IEnumerable<StackDTO>> GetAllStacks();
        Task<bool> UpdateStack(StackDTO stack);
    }
}