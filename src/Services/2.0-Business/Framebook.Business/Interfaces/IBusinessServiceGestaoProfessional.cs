using Framebook.Business.DTO.DTO;
using System.Collections.Generic;

namespace Framebook.Business.Interfaces
{
    public interface IBusinessServiceGestaoProfessional
    {
        void Add(ProfessionalDTO obj);

        ProfessionalDTO? GetByEmail(string email);

        IEnumerable<ProfessionalDTO> GetAll();

        void Update(ProfessionalDTO obj);

        void Remove(ProfessionalDTO obj);

        void Dispose();
    }
}
