using Framebook.Domain.Models;
using System;
using System.Collections.Generic;

namespace Framebook.Domain.Interfaces.Repositories
{
    public interface IRepositoryStackAprender : IRepositoryBase<StackAprender>
    {
        StackAprender GetById(Guid Id);
        IEnumerable<StackAprender> GetAll();
    }
}
