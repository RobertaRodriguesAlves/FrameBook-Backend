using Framebook.Domain.Models;

namespace Framebook.Domain.Interfaces.Repositories
{
    public interface IRepositoryProfissional : IRepositoryBase<Profissional>
    {
        Profissional GetByEmail(string email, string senha);
    }
}
