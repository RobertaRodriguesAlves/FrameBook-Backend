using Framebook.Domain.Models;
using System;
using System.Collections.Generic;

namespace Framebook.Domain.Interfaces.Repositories
{
    public interface IRepositoryStackAprender : IRepositoryBase<StackAprender>
    {
        StackAprender GetById(Int32 Id);
        IEnumerable<StackAprender> GetAll();
    }
}
