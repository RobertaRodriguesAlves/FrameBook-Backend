using Framebook.Business.DTO.DTO;
using System.Collections.Generic;

namespace Framebook.Business.Interfaces
{
    public interface IBusinessServiceGestaoProfissional
    {
        void Add(ProfissionalDTO obj);

        ProfissionalDTO? GetByEmail(string email);

        IEnumerable<ProfissionalDTO> GetAll();

        void Update(ProfissionalDTO obj);

        void Remove(ProfissionalDTO obj);

        void Dispose();
    }
}
