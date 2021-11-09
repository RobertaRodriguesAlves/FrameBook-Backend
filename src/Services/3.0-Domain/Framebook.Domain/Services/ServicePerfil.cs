using AutoMapper;
using Framebook.Business.DTO.DTO;
using Framebook.Domain.Interfaces.Repositories;
using Framebook.Domain.Interfaces.Services;
using Framebook.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Framebook.Domain.Services
{
//    public class ServicePerfil : ServiceBase<Perfil>, IServicePerfil
//    {
//        public readonly IRepositoryProfessional _repositoryProfessional;
//        IMapper _mapper;

//        public ServiceProfessional(IRepositoryProfessional repositoryProfessional, IMapper mapper)
//            : base(repositoryProfessional)
//        {
//            _repositoryProfessional = repositoryProfessional;
//            _mapper = mapper;
//        }

//        public ProfessionalDTO GetByEmail(string email)
//        {
//            var Professional = _repositoryProfessional.GetByEmail(email);

//            ProfessionalDTO retornoDTO = new ProfessionalDTO();

//            if (Professional != null)
//            {
//                retornoDTO.ProfessionalId = Professional.ProfessionalId;
//                retornoDTO.Nome = Professional.Nome;
//                retornoDTO.Email = Professional.Email;
//                retornoDTO.Telefone = Professional.Telefone;
//                retornoDTO.Cidade = Professional.Cidade;
//                retornoDTO.Uf = Professional.Uf;
//                retornoDTO.DataCadastro = Professional.DataCadastro;
//                retornoDTO.Role = Professional.Role;
//            }

//            return retornoDTO;
//        }

//        public List<ProfessionalDTO> GetAll()
//        {
//            var profissionais = _repositoryProfessional.GetAll();

//            List<ProfessionalDTO> retornoDTO = profissionais.Select(x => new ProfessionalDTO()
//            {
//                ProfessionalId = x.ProfessionalId,
//                Nome = x.Nome,
//                Email = x.Email,
//                Telefone = x.Telefone,
//                Cidade = x.Cidade,
//                Uf = x.Uf,
//                DataCadastro = x.DataCadastro,
//                Role = x.Role
//            }).ToList();

//            return retornoDTO;
//        }
//    }
}
