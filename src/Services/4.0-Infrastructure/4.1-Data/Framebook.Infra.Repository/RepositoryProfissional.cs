using Framebook.Domain.Interfaces.Repositories;
using Framebook.Domain.Models;
using Framebook.Infra.Data;
using System.Linq;

namespace Framebook.Infra.Repository
{
    public class RepositoryProfissional : RepositoryBase<Profissional>, IRepositoryProfissional
    {
        private readonly DatabaseContext _context;
        public RepositoryProfissional(DatabaseContext Context)
            : base(Context)
        {
            _context = Context;
        }

        public Profissional GetByEmail(string email, string senha)
        {
            return _context.Profissionais.Where(p => p.Email == email.ToLower() && p.Senha == senha).FirstOrDefault();
        }
    }
}
