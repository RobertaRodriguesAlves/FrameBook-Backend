using Framebook.Domain.Models;
using System.Collections.Generic;

namespace Framebook.Domain.Interfaces.Repositories
{
    public interface IRepositoryProfissional : IRepositoryBase<Profissional>
    {
        Profissional GetByEmail(string email);
        List<Profissional> GetAll();
    }
}
