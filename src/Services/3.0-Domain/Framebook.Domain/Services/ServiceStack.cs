using AutoMapper;
using Framebook.Business.DTO.DTO;
using Framebook.Domain.Interfaces.Repositories;
using Framebook.Domain.Interfaces.Services;
using Framebook.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Framebook.Domain.Services
{
    public class ServiceStack : IServiceStack
    {
        private readonly IRepositoryStack _repositoryStack;
        private readonly IMapper _mapper;

        public ServiceStack(IRepositoryStack repositoryStack, IMapper mapper)
        {
            _repositoryStack = repositoryStack;
            _mapper = mapper;
        }

        public async Task<StackDTO> GetById(string id)
        {
            var stack = await _repositoryStack.GetById(id);
            return _mapper.Map<StackDTO>(stack);
        }

        public async Task<bool> PostStack(StackDTO stack)
        {
            var convertedStack = _mapper.Map<Stack>(stack);
            return await _repositoryStack.PostStack(convertedStack);
        }

        public async Task<bool> DeleteById(string id)
        {
            return await _repositoryStack.DeleteById(id);
        }

        public async Task<IEnumerable<StackDTO>> GetAllStacks()
        {
            var stacks = await _repositoryStack.GetAllStacks();
            return _mapper.Map<IEnumerable<StackDTO>>(stacks);
        }

        public async Task<bool> UpdateStack(StackDTO stack)
        {
            var convertedStack = _mapper.Map<Stack>(stack);
            return await _repositoryStack.UpdateStack(convertedStack);
        }
    }
}
