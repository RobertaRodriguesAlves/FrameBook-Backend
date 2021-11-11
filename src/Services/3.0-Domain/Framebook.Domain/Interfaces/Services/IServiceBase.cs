using Framebook.Domain.Models;
using System.Collections.Generic;

namespace Framebook.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        void Update(TEntity obj);

        void Remove(TEntity obj);

        void Dispose();       
    }
}
