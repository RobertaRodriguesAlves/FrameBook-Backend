using Framebook.Business.DTO.DTO;
using Framebook.Domain.Models;

namespace Framebook.Domain.Interfaces.Services
{
    public interface IServiceProfissional : IServiceBase<Profissional>
    {
        ProfissionalDTO GetByEmail(string email, string senha);
    }
}
