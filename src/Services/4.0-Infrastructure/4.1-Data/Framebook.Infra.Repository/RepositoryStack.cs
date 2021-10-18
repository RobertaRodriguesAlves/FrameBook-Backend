using Framebook.Infra.Data;
using Framebook.Domain.Models;
using Framebook.Domain.Interfaces.Repositories;

namespace Framebook.Infra.Repository
{
    public class RepositoryStack : RepositoryBase<Stack>, IRepositoryStack
    {
        private readonly DatabaseContext _context;
        public RepositoryStack(DatabaseContext Context)
            : base(Context)
        {
            _context = Context;
        }
    }
}
