using AutoMapper;
using Framebook.Business.DTO.DTO;
using Framebook.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FrameBook.ProfissionalAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        private readonly IBusinessServiceGestaoProfissional _businessServiceGestaoProfissional;
        IMapper _mapper;

        public ProfissionalController(IBusinessServiceGestaoProfissional businessServiceGestaoProfissional,
            IMapper mapper)
        {
            _businessServiceGestaoProfissional = businessServiceGestaoProfissional;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_businessServiceGestaoProfissional.GetAll());
        }

        [HttpGet("{email}")]
        public ActionResult<string> Get(string email)
        {
            var profissional = _businessServiceGestaoProfissional.GetByEmail(email);
            var profissionalDTO = _mapper.Map<ProfissionalDTO>(profissional);
            return Ok(profissionalDTO);
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProfissionalDTO profissionalDTO)
        {
            if (profissionalDTO == null)
                return NotFound();

            _businessServiceGestaoProfissional.Add(profissionalDTO);
            return Ok("Profissional cadastrado com sucesso!");
        }

        [HttpPut]
        public ActionResult Put([FromBody] ProfissionalDTO profissionalDTO)
        {
            if (profissionalDTO == null)
                return NotFound();

            _businessServiceGestaoProfissional.Update(profissionalDTO);
            return Ok("Profissional atualizado com sucesso!");
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] ProfissionalDTO profissionalDTO)
        {
            if (profissionalDTO == null)
                return NotFound();

            _businessServiceGestaoProfissional.Remove(profissionalDTO);
            return Ok("Profissional removido com sucesso!");
        }
    }
}
