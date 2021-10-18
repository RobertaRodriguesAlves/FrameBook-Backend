using Framebook.Business.DTO.DTO;
using Framebook.Domain.Models;

namespace Framebook.Domain.Interfaces.Services
{
    public interface IServiceStack : IServiceBase<Stack>
    {
        StackDTO GetById(int id);
    }
}
