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
        IMapper _mapper;

        IConfiguration _configuration;
#nullable enable
        IPAddress? _remoteIpAddress;
#nullable disable

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

        public AuthController(IBusinessServiceGestaoProfissional businessServiceGestaoProfissional, IBusinessServiceGestaoAuth businessServiceGestaoAuth, IMapper mapper, IConfiguration configuration)
        {
            _businessServiceGestaoProfissional = businessServiceGestaoProfissional;
            _businessServiceGestaoAuth = businessServiceGestaoAuth;
            _mapper = mapper;
            _configuration = configuration;
        }

        [HttpPost]
        public ActionResult<dynamic> Auth([FromBody] ProfissionalDTO profissionalDTO)
        {
            try
            {
                if (profissionalDTO == null)
                    return NotFound(new { message = "Usuário não existe." });

                var professional = _businessServiceGestaoProfissional.GetByEmail(profissionalDTO.Email, profissionalDTO.Senha);

                if (professional == null)
                    return NotFound(new { message = "Usuário não existe." });
                else
                {
                    ServiceToken serviceToken = new ServiceToken();

                    var token = serviceToken.GenerateToken(profissionalDTO, _configuration.GetSection("JwtSettings")["SecretKey"]);
                    var refreshToken = serviceToken.GenerateRefreshtoken(profissionalDTO.Email, profissionalDTO.Nome, GetRemoteIp());

                    _businessServiceGestaoAuth.Add(refreshToken);

                    return new
                    {
                        user = new { name = profissionalDTO.Nome, email = profissionalDTO.Email, cidade = profissionalDTO.Cidade, estado = profissionalDTO.Uf, telefone = profissionalDTO.Telefone, token = token, refreshToken = refreshToken.Token }
                    };
                }
            }
            catch (Exception ex)
            {
                return NotFound(new { message = "Erro ao Autenticar o usuário: " + ex.Message });
            }
        }
    }
}
