using Framebook.Domain.Models;

namespace Framebook.Domain.Interfaces.Repositories
{
    public interface IRepositoryAuth : IRepositoryBase<RefreshToken>
    {
        Professional GetToken(string email, string senha);
    }
}