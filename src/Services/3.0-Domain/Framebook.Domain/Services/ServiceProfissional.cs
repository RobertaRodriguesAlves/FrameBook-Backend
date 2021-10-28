using AutoMapper;
using Framebook.Business.DTO.DTO;
using Framebook.Domain.Interfaces.Repositories;
using Framebook.Domain.Interfaces.Services;
using Framebook.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

            ProfissionalDTO retornoDTO = new ProfissionalDTO();

            if (profissional != null)
            {
                retornoDTO.Id_Profissional = profissional.Id_Profissional;
                retornoDTO.Nome = profissional.Nome;
                retornoDTO.Email = profissional.Email;
                retornoDTO.Telefone = profissional.Telefone;
                retornoDTO.Cidade = profissional.Cidade;
                retornoDTO.Uf = profissional.Uf;
                retornoDTO.DataCadastro = profissional.DataCadastro;
            }
           
            return retornoDTO;
        }

        public List<ProfissionalDTO> GetAll()
        {
            var profissionais = _repositoryProfissional.GetAll();

            List<ProfissionalDTO> retornoDTO = profissionais.Select(x => new ProfissionalDTO()
            {
                Id_Profissional = x.Id_Profissional,
                Nome = x.Nome,
                Email = x.Email,
                Telefone = x.Telefone,
                Cidade = x.Cidade,
                Uf = x.Uf,
                DataCadastro = x.DataCadastro
            }).ToList();

            return retornoDTO;
        }
    }
}
