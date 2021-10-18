using Framebook.Business.DTO.DTO;
using System.Collections.Generic;

namespace Framebook.Business.Interfaces
{
    public interface IBusinessServiceGestaoStack
    {
        void Add(StackDTO obj);

        StackDTO GetById(int id);

        IEnumerable<StackDTO> GetAll();

        void Update(StackDTO obj);

        void Remove(StackDTO obj);

        void Dispose();
    }
}