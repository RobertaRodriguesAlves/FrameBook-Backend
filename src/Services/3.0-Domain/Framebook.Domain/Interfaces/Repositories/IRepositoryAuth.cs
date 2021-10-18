using Framebook.Domain.Models;

namespace Framebook.Domain.Interfaces.Repositories
{
    public interface IRepositoryAuth : IRepositoryBase<RefreshToken>
    {
        Profissional GetByEmail(string email);
    }
}