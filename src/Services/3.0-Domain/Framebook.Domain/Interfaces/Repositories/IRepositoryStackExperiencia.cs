﻿using Framebook.Domain.Models;
using System;
using System.Collections.Generic;

namespace Framebook.Domain.Interfaces.Repositories
{
    public interface IRepositoryStackExperiencia : IRepositoryBase<StackExperiencia>
    {
        IEnumerable<StackExperiencia> GetByProfissionalId(Guid professionalId);
        List<StackExperiencia> GetAll();
    }
}
