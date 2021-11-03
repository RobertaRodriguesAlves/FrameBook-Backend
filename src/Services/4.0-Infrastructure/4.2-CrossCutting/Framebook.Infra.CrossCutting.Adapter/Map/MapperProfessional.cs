using Framebook.Business.DTO.DTO;
using Framebook.Domain.Models;
using Framebook.Infra.CrossCutting.Adapter.Inferfaces;
using System.Collections.Generic;

namespace Framebook.Infra.CrossCutting.Adapter.Map
{
    public class MapperProfessional : IMapperProfessional
    {
        List<ProfessionalDTO> ProfessionalDTOs = new List<ProfessionalDTO>();

        public Professional MapperToEntity(ProfessionalDTO ProfessionalDTO)
        {
            Professional Professional = new Professional
            {
                ProfessionalId = ProfessionalDTO.ProfessionalId,
                Nome = ProfessionalDTO.Nome,
                Email = ProfessionalDTO.Email,
                Telefone = ProfessionalDTO.Telefone,
                Cidade = ProfessionalDTO.Cidade,
                Uf = ProfessionalDTO.Uf,
                Senha = ProfessionalDTO.Senha
            };

            return Professional;
        }

        public IEnumerable<ProfessionalDTO> MapperListProfessionals(IEnumerable<Professional> profissionais)
        {
            foreach (var item in profissionais)
            {
                ProfessionalDTO ProfessionalDTO = new ProfessionalDTO
                {
                    ProfessionalId = item.ProfessionalId,
                    Nome = item.Nome,
                    Email = item.Email,
                    Telefone = item.Telefone,
                    Cidade = item.Cidade,
                    Uf = item.Uf,
                    Senha = item.Senha
                };

                ProfessionalDTOs.Add(ProfessionalDTO);
            }

            return ProfessionalDTOs;
        }

        public ProfessionalDTO MapperToDTO(Professional Professional)
        {

            ProfessionalDTO ProfessionalDTO = new ProfessionalDTO
            {
                ProfessionalId = Professional.ProfessionalId,
                Nome = Professional.Nome,
                Email = Professional.Email,
                Telefone = Professional.Telefone,
                Cidade = Professional.Cidade,
                Uf = Professional.Uf,
                Senha = Professional.Senha
            };

            return ProfessionalDTO;
        }
    }
}
