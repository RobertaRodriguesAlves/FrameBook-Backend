using AutoMapper;
using Framebook.Domain.Interfaces.Repositories;
using Framebook.Domain.Interfaces.Services;
using Framebook.Domain.Models;
using System;
using System.Collections.Generic;

namespace Framebook.Domain.Services
{
    public class ServiceStackAprender : ServiceBase<StackAprender>, IServiceStackAprender
    {
        public readonly IRepositoryStackAprender _repositoryStackAprender;
        IMapper _mapper;

        public ServiceStackAprender(IRepositoryStackAprender repositoryStackAprender, IMapper mapper)
            : base(repositoryStackAprender)
        {
            _repositoryStackAprender = repositoryStackAprender;
            _mapper = mapper;
        }

        public List<StackAprender> GetAll()
        {
            return _repositoryStackAprender.GetAll();
        }

        public IEnumerable<StackAprender> GetByProfissionalId(Guid professionalId)
        {
            return _repositoryStackAprender.GetByProfissionalId(professionalId);
        }
    }
}
