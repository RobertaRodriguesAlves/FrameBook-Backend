using Framebook.Business.DTO.DTO;
using System.Collections.Generic;

namespace Framebook.Business.Interfaces
{
    public interface IBusinessServiceGestaoProfissional
    {
        void Add(ProfissionalDTO obj);
#nullable enable
        ProfissionalDTO? GetByEmail(string email);
#nullable disable

        IEnumerable<ProfissionalDTO> GetAll();

        void Update(ProfissionalDTO obj);

        void Remove(ProfissionalDTO obj);

        void Dispose();
    }
}
