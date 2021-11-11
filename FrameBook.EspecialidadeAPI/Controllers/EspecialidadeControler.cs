using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameBook.EspecialidadeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EspecialidadeControler : ControllerBase
    {        
        private readonly ILogger<EspecialidadeControler> _logger;

        public EspecialidadeControler(ILogger<EspecialidadeControler> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok("teste ok");
        }
    }
}
