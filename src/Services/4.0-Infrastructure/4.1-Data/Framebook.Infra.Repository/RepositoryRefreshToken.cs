using Framebook.Domain.Interfaces.Repositories;
using Framebook.Domain.Models;
using Framebook.Infra.Data;
using System.Linq;

namespace Framebook.Infra.Repository
{
    public class RepositoryRefreshToken : RepositoryBase<RefreshToken>, IRepositoryAuth
    {
        private readonly DatabaseContext _context;

        public RepositoryRefreshToken(DatabaseContext Context)
            : base(Context)
        {
            _context = Context;
        }

        public Professional GetToken(string email, string senha)
        {
            var Professional = _context.Profissionais.Where(p => p.Email == email.ToLower() && p.Senha == senha).FirstOrDefault();
            return Professional;
        }
    }
}
