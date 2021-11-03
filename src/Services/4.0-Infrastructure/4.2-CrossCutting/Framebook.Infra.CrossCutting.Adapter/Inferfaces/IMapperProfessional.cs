using Framebook.Business.DTO.DTO;
using Framebook.Domain.Models;
using System.Collections.Generic;

namespace Framebook.Infra.CrossCutting.Adapter.Inferfaces
{
    public interface IMapperProfessional
    {
        Professional MapperToEntity(ProfessionalDTO clienteDTO);

        IEnumerable<ProfessionalDTO> MapperListProfessionals(IEnumerable<Professional> profissionais);

        ProfessionalDTO MapperToDTO(Professional Professional);
    }
}
