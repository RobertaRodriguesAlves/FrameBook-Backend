using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrameBook.PerfilAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok("teste ok");            
        }
    }
}
