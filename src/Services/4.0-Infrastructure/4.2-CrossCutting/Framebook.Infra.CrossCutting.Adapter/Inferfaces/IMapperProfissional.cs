using Framebook.Business.DTO.DTO;
using Framebook.Domain.Models;
using System.Collections.Generic;

namespace Framebook.Infra.CrossCutting.Adapter.Inferfaces
{
    public interface IMapperProfissional
    {
        Profissional MapperToEntity(ProfissionalDTO clienteDTO);

        IEnumerable<ProfissionalDTO> MapperListProfissionals(IEnumerable<Profissional> profissionais);

        ProfissionalDTO MapperToDTO(Profissional profissional);
    }
}
