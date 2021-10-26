using AutoMapper;
using Framebook.Authentication.Services;
using Framebook.Business.DTO.DTO;
using Framebook.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace FrameBook.AuthAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IBusinessServiceGestaoProfissional _businessServiceGestaoProfissional;
        private readonly IBusinessServiceGestaoAuth _businessServiceGestaoAuth;

        IConfiguration _configuration;
        IPAddress? _remoteIpAddress;

        public AuthController(IBusinessServiceGestaoProfissional businessServiceGestaoProfissional, IBusinessServiceGestaoAuth businessServiceGestaoAuth, IMapper mapper, IConfiguration configuration)
        {
            _businessServiceGestaoProfissional = businessServiceGestaoProfissional;
            _businessServiceGestaoAuth = businessServiceGestaoAuth;
            _configuration = configuration;
        }

        [HttpPost]
        public ActionResult<dynamic> Authenticate([FromBody] AutenticacaoDTO autenticacao)
        {
            try
            {
                var professional = _businessServiceGestaoProfissional.GetByEmail(autenticacao.Email, autenticacao.Senha);

                if (professional == null)
                    return NotFound(new { message = "Usuário não existe." });
                else
                {
                    ServiceToken serviceToken = new ServiceToken();

                    var token = serviceToken.GenerateToken(professional, _configuration.GetSection("JwtSettings")["SecretKey"]);
                    var refreshToken = serviceToken.GenerateRefreshtoken(professional.Email, professional.Nome, GetRemoteIp());

                    _businessServiceGestaoAuth.Add(refreshToken);

                    return new
                    {
                        user = new { name = professional.Nome, email = professional.Email, cidade = professional.Cidade, estado = professional.Uf, telefone = professional.Telefone, token = token, refreshToken = refreshToken.Token }
                    };
                }
            }
            catch (Exception ex)
            {
                return NotFound(new { message = "Erro ao Autenticar o usuário: " + ex.Message });
            }
        }

        private string GetRemoteIp()
        {
            _remoteIpAddress = Request.HttpContext.Connection.RemoteIpAddress;
            if (_remoteIpAddress != null)
            {
                if (_remoteIpAddress.AddressFamily == AddressFamily.InterNetworkV6)
                {
                    _remoteIpAddress = Dns.GetHostEntry(_remoteIpAddress).AddressList.First(x => x.AddressFamily == AddressFamily.InterNetwork);
                }
            }

            return _remoteIpAddress.ToString();
        }
    }
}
