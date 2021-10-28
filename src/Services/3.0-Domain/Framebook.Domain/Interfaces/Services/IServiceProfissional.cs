using Framebook.Business.DTO.DTO;
using Framebook.Domain.Models;
using System.Collections.Generic;

namespace Framebook.Domain.Interfaces.Services
{
    public interface IServiceProfissional : IServiceBase<Profissional>
    {
        ProfissionalDTO GetByEmail(string email);
        List<ProfissionalDTO> GetAll();
    }
}
