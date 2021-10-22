using Framebook.Business.DTO.DTO;
using Framebook.Business.Interfaces;
using Framebook.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framebook.Business.Services
{
    public class BusinessServiceGestaoStack : IBusinessServiceGestaoStack
    {
        private readonly IServiceStack _serviceStack;
        public BusinessServiceGestaoStack(IServiceStack serviceStack)
        {
            _serviceStack = serviceStack;
        }

        public async Task<StackDTO> GetById(string id)
        {
            return await _serviceStack.GetById(id);
        }

        public async Task<bool> PostStack(StackDTO stack)
        {
            return await _serviceStack.PostStack(stack);
        }

        public async Task<bool> DeleteById(string id)
        {
            return await _serviceStack.DeleteById(id);
        }

        public async Task<IEnumerable<StackDTO>> GetAllStacks()
        {
            return await _serviceStack.GetAllStacks();
        }

        public async Task<bool> UpdateStack(StackDTO stack)
        {
            return await _serviceStack.UpdateStack(stack);
        }
    }
}