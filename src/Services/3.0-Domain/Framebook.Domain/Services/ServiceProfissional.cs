using AutoMapper;
using Framebook.Business.DTO.DTO;
using Framebook.Domain.Interfaces.Repositories;
using Framebook.Domain.Interfaces.Services;
using Framebook.Domain.Models;

namespace Framebook.Domain.Services
{
    public class ServiceProfissional : ServiceBase<Profissional>, IServiceProfissional
    {
        public readonly IRepositoryProfissional _repositoryProfissional;
        IMapper _mapper;

        public ServiceProfissional(IRepositoryProfissional repositoryProfissional, IMapper mapper)
            : base(repositoryProfissional)
        {
            _repositoryProfissional = repositoryProfissional;
            _mapper = mapper;
        }

        public ProfissionalDTO GetByEmail(string email)
        {
            var profissional = _repositoryProfissional.GetByEmail(email);
            return _mapper.Map<ProfissionalDTO>(profissional);
        }
    }
}
