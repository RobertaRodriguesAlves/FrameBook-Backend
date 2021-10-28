using AutoMapper;
using Framebook.Business.DTO.DTO;
using Framebook.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace FrameBook.ProfissionalAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        private readonly IBusinessServiceGestaoProfissional _businessServiceGestaoProfissional;
        private readonly IMapper _mapper;
        private readonly ILogger<ProfissionalController> _logger;

        public ProfissionalController(IBusinessServiceGestaoProfissional businessServiceGestaoProfissional,
            IMapper mapper, ILogger<ProfissionalController> logger)
        {
            _businessServiceGestaoProfissional = businessServiceGestaoProfissional;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_businessServiceGestaoProfissional.GetAll());
        }

        [HttpGet("{email}")]
        public ActionResult<string> Get(string email)
        {
            try
            {
                var profissional = _businessServiceGestaoProfissional.GetByEmail(email);
                var profissionalDTO = _mapper.Map<ProfissionalDTO>(profissional);

                if (profissionalDTO.Email != null)
                {
                    return Ok(profissionalDTO);
                }
                else
                {
                    return Ok("Profissional não encontrado!");
                }
            }
            catch (Exception)
            {
                return Ok("Erro!");
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] ProfissionalDTO profissionalDTO)
        {
            if (profissionalDTO == null)
                return NotFound();

            try
            {
                _businessServiceGestaoProfissional.Add(profissionalDTO);
                return Ok("Profissional cadastrado com sucesso!");
            }
            catch (Exception)
            {
                return Problem("Não foi possível cadastrar!");
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] ProfissionalDTO profissionalDTO)
        {
            if (profissionalDTO == null)
                return NotFound();

            try
            {
                _businessServiceGestaoProfissional.Update(profissionalDTO);
                return Ok("Profissional atualizado com sucesso!");
            }
            catch (Exception)
            {
                return Problem("Não foi possível atualizar!");
            }
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] ProfissionalDTO profissionalDTO)
        {
            if (profissionalDTO == null)
                return NotFound();

            try
            {
                _businessServiceGestaoProfissional.Remove(profissionalDTO);
                return Ok("Profissional removido com sucesso!");
            }
            catch (Exception)
            {
                return Problem("Não foi possível remover!");
            }
        }
    }
}
