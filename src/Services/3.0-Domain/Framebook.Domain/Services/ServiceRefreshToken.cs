using Framebook.Business.DTO.DTO;
using Framebook.Domain.Interfaces.Repositories;
using Framebook.Domain.Interfaces.Services;
using Framebook.Domain.Models;

namespace Framebook.Domain.Services
{
    public class ServiceRefreshToken : ServiceBase<RefreshToken>, IServiceRefreshToken
    {
        public readonly IRepositoryAuth _repositoryAuth;

        public ServiceRefreshToken(IRepositoryAuth repositoryAuth) : base(repositoryAuth)
        {
            _repositoryAuth = repositoryAuth;
        }

        public ProfessionalDTO GetToken(string email, string senha)
        {
            var auth = _repositoryAuth.GetToken(email, senha);

            ProfessionalDTO retornoDTO = new ProfessionalDTO();

            if (auth != null)
            {
                retornoDTO.ProfessionalId = auth.ProfessionalId;
                retornoDTO.Nome = auth.Nome;
                retornoDTO.Email = auth.Email;
                retornoDTO.Telefone = auth.Telefone;
                retornoDTO.Cidade = auth.Cidade;
                retornoDTO.Uf = auth.Uf;
                retornoDTO.DataCadastro = auth.DataCadastro;
                retornoDTO.Role = auth.Role;
            }

            return retornoDTO;
        }
    }
}
