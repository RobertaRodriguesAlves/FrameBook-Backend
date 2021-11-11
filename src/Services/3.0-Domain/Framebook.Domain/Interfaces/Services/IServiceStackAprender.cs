using Framebook.Domain.Models;
using System;
using System.Collections.Generic;

namespace Framebook.Domain.Interfaces.Services
{
    public interface IServiceStackAprender : IServiceBase<StackAprender>
    {
        IEnumerable<StackAprender> GetByProfissionalId(Guid professionalId);
        List<StackAprender> GetAll();
    }
}