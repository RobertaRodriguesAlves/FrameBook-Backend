using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framebook.Infra.Repository
{
    class RepositoryStackAprender
    {
    }
}


using Framebook.Domain.Interfaces.Repositories;
using Framebook.Domain.Models;
using Framebook.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace Framebook.Infra.Repository
{
    public class RepositoryProfessional : RepositoryBase<Professional>, IRepositoryProfessional
    {
        private readonly DatabaseContext _context;
        public RepositoryProfessional(DatabaseContext Context)
            : base(Context)
        {
            _context = Context;
        }

        public Professional GetByEmail(string email)
        {
            return _context.Profissionais.Where(p => p.Email == email.ToLower()).FirstOrDefault();
        }

        public List<Professional> GetAll()
        {
            return _context.Profissionais.ToList();
        }
    }
}
