using Framebook.Domain.Models;
using System;
using System.Collections.Generic;

namespace Framebook.Domain.Interfaces.Repositories
{
    public interface IRepositoryStackAprender : IRepositoryBase<StackAprender>
    {
        IEnumerable<StackAprender> GetByProfissionalId(Guid professionalId);
        List<StackAprender> GetAll();    
    }
}
