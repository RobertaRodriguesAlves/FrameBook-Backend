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

        public AuthController(IBusinessServiceGestaoProfissional businessServiceGestaoProfissional,
                              IBusinessServiceGestaoAuth businessServiceGestaoAuth, IConfiguration configuration)
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
                var professional = _businessServiceGestaoProfissional.GetByEmail(autenticacao.Email);

                if (professional.Email == null)
                    return NotFound(new { message = "Usuário não cadastrado." });
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
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private string GetRemoteIp()
        {
            _remoteIpAddress = Dns.GetHostEntry(Dns.GetHostName()).AddressList.FirstOrDefault(x => x.AddressFamily == AddressFamily.InterNetwork);
            return _remoteIpAddress.ToString();
        }
    }
}
