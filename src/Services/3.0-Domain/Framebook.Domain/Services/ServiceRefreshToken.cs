using Framebook.Domain.Interfaces.Repositories;
using Framebook.Domain.Interfaces.Services;
using Framebook.Domain.Models;

namespace Framebook.Domain.Services
{
    public class ServiceRefreshToken : ServiceBase<RefreshToken>, IServiceRefreshToken
    {
        public readonly IRepositoryAuth _repositoryAuth;

        public ServiceRefreshToken(IRepositoryAuth repositoryAuth) : base(repositoryAuth)
        {
            _repositoryAuth = repositoryAuth;
        }
    }
}
