using Framebook.Domain.Interfaces.Repositories;
using Framebook.Domain.Models;
using Framebook.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Framebook.Infra.Repository
{
    public class RepositoryStackExperiencia : RepositoryBase<StackExperiencia>, IRepositoryStackExperiencia
    {

        private readonly DatabaseContext _context;
        public RepositoryStackExperiencia(DatabaseContext Context)
            : base(Context)
        {
            _context = Context;
        }
        public IEnumerable<StackExperiencia> GetByProfissionalId(Guid professionalId)
        {
            return _context.StackExperiencia.Where(p => p.ProfissionalId == professionalId);
        }

        public List<StackExperiencia> GetAll()
        {
            return _context.StackExperiencia.ToList();
        }





    }
}
