using Framebook.Domain.Interfaces.Repositories;
using Framebook.Domain.Models;
using Framebook.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Framebook.Infra.Repository
{
    public class RepositoryStackAprender : RepositoryBase<StackAprender>, IRepositoryStackAprender
    {
        private readonly DatabaseContext _context;
        public RepositoryStackAprender(DatabaseContext Context)
            : base(Context)
        {
            _context = Context;
        }  
        public IEnumerable<StackAprender> GetByProfissionalId(Guid professionalId)
        {
            return _context.StackAprender.Where(p => p.ProfissionalId == professionalId);
        }

        public List<StackAprender> GetAll()
        {
            return _context.StackAprender.ToList();
        }
    }
}
