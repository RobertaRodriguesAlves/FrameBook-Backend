using Framebook.Business.DTO.DTO;
using Framebook.Domain.Models;
using Framebook.Infra.CrossCutting.Adapter.Inferfaces;
using System.Collections.Generic;

namespace Framebook.Infra.CrossCutting.Adapter.Map
{
    public class MapperProfissional : IMapperProfissional
    {
        List<ProfissionalDTO> ProfissionalDTOs = new List<ProfissionalDTO>();

        public Profissional MapperToEntity(ProfissionalDTO profissionalDTO)
        {
            Profissional profissional = new Profissional
            {
                Id_Profissional = profissionalDTO.Id_Profissional,
                Nome = profissionalDTO.Nome,
                Email = profissionalDTO.Email,
                Telefone = profissionalDTO.Telefone,
                Cidade = profissionalDTO.Cidade,
                Uf = profissionalDTO.Uf,
                Senha = profissionalDTO.Senha
            };

            return profissional;
        }

        public IEnumerable<ProfissionalDTO> MapperListProfissionals(IEnumerable<Profissional> profissionais)
        {
            foreach (var item in profissionais)
            {
                ProfissionalDTO profissionalDTO = new ProfissionalDTO
                {
                    Id_Profissional = item.Id_Profissional,
                    Nome = item.Nome,
                    Email = item.Email,
                    Telefone = item.Telefone,
                    Cidade = item.Cidade,
                    Uf = item.Uf,
                    Senha = item.Senha
                };

                ProfissionalDTOs.Add(profissionalDTO);
            }

            return ProfissionalDTOs;
        }

        public ProfissionalDTO MapperToDTO(Profissional profissional)
        {

            ProfissionalDTO profissionalDTO = new ProfissionalDTO
            {
                Id_Profissional = profissional.Id_Profissional,
                Nome = profissional.Nome,
                Email = profissional.Email,
                Telefone = profissional.Telefone,
                Cidade = profissional.Cidade,
                Uf = profissional.Uf,
                Senha = profissional.Senha
            };

            return profissionalDTO;
        }
    }
}
