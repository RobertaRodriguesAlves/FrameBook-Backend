using Framebook.Business.DTO.DTO;
using Framebook.Domain.Models;
using System.IdentityModel.Tokens.Jwt;

namespace Framebook.Authentication.Interfaces
{
    public interface IServiceToken
    {
        string GenerateToken(ProfissionalDTO obj, string secretKey = "");

        JwtSecurityToken Verify(string token, string secretKey = "");

        RefreshToken GenerateRefreshtoken(string email, string nome, string ipAddress);
    }
}
