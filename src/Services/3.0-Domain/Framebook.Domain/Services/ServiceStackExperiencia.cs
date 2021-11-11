using AutoMapper;
using Framebook.Domain.Interfaces.Repositories;
using Framebook.Domain.Interfaces.Services;
using Framebook.Domain.Models;
using System;
using System.Collections.Generic;

namespace Framebook.Domain.Services
{
    public class ServiceStackExperiencia : ServiceBase<StackExperiencia>, IServiceStackExperiencia
    {
        public readonly IRepositoryStackExperiencia _repositoryStackExperiencia;
        IMapper _mapper;

        public ServiceStackExperiencia(IRepositoryStackExperiencia repositoryStackExperiencia, IMapper mapper)
            : base(repositoryStackExperiencia)
        {
            _repositoryStackExperiencia = repositoryStackExperiencia;
            _mapper = mapper;
        }

        List<StackExperiencia> IServiceStackExperiencia.GetAll()
        {
            return _repositoryStackExperiencia.GetAll();
        }

        IEnumerable<StackExperiencia> IServiceStackExperiencia.GetByProfissionalId(Guid professionalId)
        {
            return _repositoryStackExperiencia.GetByProfissionalId(professionalId);
        }
    }
}
