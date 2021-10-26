using AutoMapper;
using Framebook.Business.DTO.DTO;
using Framebook.Business.Interfaces;
using Framebook.Domain.Interfaces.Services;
using Framebook.Domain.Models;
using System.Collections.Generic;

namespace Framebook.Business.Services
{
    public class BusinessServiceGestaoProfissional : IBusinessServiceGestaoProfissional
    {
        private readonly IServiceProfissional _serviceProfissional;
        private readonly IMapper _mapper;

        public BusinessServiceGestaoProfissional(IServiceProfissional serviceProfissional, IMapper mapper)
        {
            _serviceProfissional = serviceProfissional;
            _mapper = mapper;
        }

        public void Add(ProfissionalDTO obj)
        {
            var objProfissional = _mapper.Map<Profissional>(obj);
            _serviceProfissional.Add(objProfissional);
        }

        public IEnumerable<ProfissionalDTO> GetAll()
        {
            var objProfissionais = _serviceProfissional.GetAll();
            return _mapper.Map<IEnumerable<ProfissionalDTO>>(objProfissionais);
        }

        public ProfissionalDTO GetByEmail(string email, string senha)
        {
            var profissional = _serviceProfissional.GetByEmail(email, senha);
            return _mapper.Map<ProfissionalDTO>(profissional);
        }

        public void Remove(ProfissionalDTO obj)
        {
            var objProfissional = _mapper.Map<Profissional>(obj);
            _serviceProfissional.Remove(objProfissional);
        }

        public void Update(ProfissionalDTO obj)
        {
            var objProfissional = _mapper.Map<Profissional>(obj);
            _serviceProfissional.Update(objProfissional);
        }

        public void Dispose()
        {
            _serviceProfissional.Dispose();
        }
    }
}
