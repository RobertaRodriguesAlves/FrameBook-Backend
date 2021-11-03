using Framebook.Authentication.Interfaces;
using Framebook.Business.DTO.DTO;
using Framebook.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Framebook.Authentication.Services
{
    public class ServiceToken : IServiceToken
    {
        public ServiceToken()
        {
        }

        public RefreshToken GenerateRefreshtoken(string email, string nome, string ipAddress)
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);

                var refreshToken = new RefreshToken
                {
                    Token = Convert.ToBase64String(randomBytes),
                    Nome = nome,
                    Email = email,
                    Expires = DateTime.UtcNow.AddDays(7),
                    Created = DateTime.UtcNow,
                    CreatedByIp = ipAddress
                };

                return refreshToken;
            }
        }

        public string GenerateToken(ProfessionalDTO Professional, string secretKey = "")
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Role, Professional.Nome),
                    new Claim(ClaimTypes.Email, Professional.Email),
                    new Claim(ClaimTypes.Country, Professional.Cidade),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),

                Expires = DateTime.UtcNow.AddHours(2),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static string HasPass(string senha)
        {
            try
            {
                return BCrypt.Net.BCrypt.HashPassword(senha);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JwtSecurityToken Verify(string token, string secretKey = "")
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(secretKey);

                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    RequireExpirationTime = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return (JwtSecurityToken)validatedToken;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
