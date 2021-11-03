using AutoMapper;
using Framebook.Business.DTO.DTO;
using Framebook.Business.Interfaces;
using Framebook.Domain.Interfaces.Services;
using Framebook.Domain.Models;
using System;
using System.Collections.Generic;

namespace Framebook.Business.Services
{
    public class BusinessServiceGestaoProfessional : IBusinessServiceGestaoProfessional
    {
        private readonly IServiceProfessional _serviceProfessional;
        private readonly IMapper _mapper;

        public BusinessServiceGestaoProfessional(IServiceProfessional serviceProfessional, IMapper mapper)
        {
            _serviceProfessional = serviceProfessional;
            _mapper = mapper;
        }

        public void Add(ProfessionalDTO obj)
        {
            var objProfessional = _mapper.Map<Professional>(obj);
            _serviceProfessional.Add(objProfessional);
        }

        public IEnumerable<ProfessionalDTO> GetAll()
        {
            var objProfissionais = _serviceProfessional.GetAll();
            return _mapper.Map<IEnumerable<ProfessionalDTO>>(objProfissionais);
        }

        public ProfessionalDTO GetByEmail(string email)
        {
            ProfessionalDTO Professional;
            Professional = _serviceProfessional.GetByEmail(email);
            return _mapper.Map<ProfessionalDTO>(Professional);
        }

        public void Remove(ProfessionalDTO obj)
        {
            var objProfessional = _mapper.Map<Professional>(obj);
            _serviceProfessional.Remove(objProfessional);
        }

        public void Update(ProfessionalDTO obj)
        {
            var objProfessional = _mapper.Map<Professional>(obj);
            _serviceProfessional.Update(objProfessional);
        }

        public void Dispose()
        {
            _serviceProfessional.Dispose();
        }
    }
}
