using Framebook.Business.DTO.DTO;
using Framebook.Domain.Models;

namespace Framebook.Domain.Interfaces.Services
{
    public interface IServiceRefreshToken : IServiceBase<RefreshToken>
    {
        ProfessionalDTO GetToken(string email, string senha);
    }
}
