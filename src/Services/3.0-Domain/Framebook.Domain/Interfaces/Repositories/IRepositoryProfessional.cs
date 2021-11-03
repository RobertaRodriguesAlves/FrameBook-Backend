using Framebook.Domain.Models;
using System.Collections.Generic;

namespace Framebook.Domain.Interfaces.Repositories
{
    public interface IRepositoryProfessional : IRepositoryBase<Professional>
    {
        Professional GetByEmail(string email);
        List<Professional> GetAll();
    }
}
