using Framebook.Domain.Models;
using System;
using System.Collections.Generic;

namespace Framebook.Domain.Interfaces.Repositories
{
    public interface IRepositoryPerfil : IRepositoryBase<Perfil>
    {
        Perfil GetById(Int32 Id);
        List<Perfil> GetAll();
    }
}
