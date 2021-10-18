using AutoMapper;
using Framebook.Business.Interfaces;
using Framebook.Domain.Interfaces.Services;
using Framebook.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Framebook.Business.Services
{
    public class BusinessServiceGestaoAuth : IBusinessServiceGestaoAuth
    {
        private readonly IServiceRefreshToken _serviceRefreshToken;
        private readonly IMapper _mapper;

        public BusinessServiceGestaoAuth(IServiceRefreshToken serviceRefreshToken, IMapper mapper)
        {
            _serviceRefreshToken = serviceRefreshToken;
            _mapper = mapper;
        }

        public ActionResult<dynamic> Add(RefreshToken obj)
        {
            var objRefreshToken = _mapper.Map<RefreshToken>(obj);
            _serviceRefreshToken.Add(objRefreshToken);

            return new { };
        }
    }
}
