using AutoMapper;
using Framebook.Business.DTO.DTO;
using Framebook.Business.Interfaces;
using Framebook.Domain.Interfaces.Services;
using Framebook.Domain.Models;
using System.Collections.Generic;

namespace Framebook.Business.Services
{
    public class BusinessServiceGestaoStack : IBusinessServiceGestaoStack
    {
        private readonly IServiceStack _serviceStack;
        private readonly IMapper _mapper;

        public BusinessServiceGestaoStack(IServiceStack serviceStack, IMapper mapper)
        {
            _serviceStack = serviceStack;
            _mapper = mapper;
        }

        public void Add(StackDTO obj)
        {
            var objStack = _mapper.Map<Stack>(obj);
            _serviceStack.Add(objStack);
        }

        public IEnumerable<StackDTO> GetAll()
        {
            var objStack = _serviceStack.GetAll();
            return _mapper.Map<IEnumerable<StackDTO>>(objStack);
        }

        public StackDTO GetById(int id)
        {
            var objStack = _serviceStack.GetById(id);
            if (objStack == null)
                return null;
            return _mapper.Map<StackDTO>(objStack);
        }

        public void Remove(StackDTO obj)
        {
            var objStack = _mapper.Map<Stack>(obj);
            _serviceStack.Remove(objStack);
        }

        public void Update(StackDTO obj)
        {
            var objStack = _mapper.Map<Stack>(obj);
            _serviceStack.Update(objStack);
        }

        public void Dispose()
        {
            _serviceStack.Dispose();
        }
    }
}