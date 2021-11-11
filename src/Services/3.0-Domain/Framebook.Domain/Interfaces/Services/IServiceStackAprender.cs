
using Framebook.Business.DTO.DTO;
using Framebook.Domain.Models;
using System.Collections.Generic;

namespace Framebook.Domain.Interfaces.Services
{
    public interface IServiceStackAprender : IServiceBase<StackAprender>
    {
        StackAprender GetById(int Id);
        List<StackAprender> GetAll();
    }
}