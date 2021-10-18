using Framebook.Business.DTO.DTO;
using Framebook.Domain.Interfaces.Repositories;
using Framebook.Domain.Interfaces.Services;
using Framebook.Domain.Models;

namespace Framebook.Domain.Services
{
    public class ServiceStack : ServiceBase<Stack>, IServiceStack
    {
        public readonly IRepositoryStack _repositoryStack;

        public ServiceStack(IRepositoryStack repositoryStack)
            : base(repositoryStack)
        {
            _repositoryStack = repositoryStack;
        }

        public StackDTO GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
