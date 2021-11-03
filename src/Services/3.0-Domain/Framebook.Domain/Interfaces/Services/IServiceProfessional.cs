using Framebook.Business.DTO.DTO;
using Framebook.Domain.Models;
using System.Collections.Generic;

namespace Framebook.Domain.Interfaces.Services
{
    public interface IServiceProfessional : IServiceBase<Professional>
    {
        ProfessionalDTO GetByEmail(string email);
        List<ProfessionalDTO> GetAll();
    }
}
