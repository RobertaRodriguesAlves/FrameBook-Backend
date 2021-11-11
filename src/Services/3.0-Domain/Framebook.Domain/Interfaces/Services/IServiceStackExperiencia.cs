using Framebook.Domain.Models;
using System;
using System.Collections.Generic;

namespace Framebook.Domain.Interfaces.Services
{
    public interface IServiceStackExperiencia : IServiceBase<StackExperiencia>
    {
        IEnumerable<StackExperiencia> GetByProfissionalId(Guid professionalId);
        List<StackExperiencia> GetAll();
    }
}