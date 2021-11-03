using Framebook.Domain.Models;

namespace Framebook.Domain.Interfaces.Repositories
{
    public interface IRepositoryAuth : IRepositoryBase<RefreshToken>
    {
        Professional GetByEmail(string email);
    }
}