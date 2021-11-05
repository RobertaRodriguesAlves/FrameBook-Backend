using AutoMapper;
using Framebook.Business.DTO.DTO;
using Framebook.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace FrameBook.ProfessionalAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]   
    public class ProfessionalController : ControllerBase
    {
        private readonly IBusinessServiceGestaoProfessional _businessServiceGestaoProfessional;
        private readonly IMapper _mapper;
        private readonly ILogger<ProfessionalController> _logger;

        public ProfessionalController(IBusinessServiceGestaoProfessional businessServiceGestaoProfessional,
            IMapper mapper, ILogger<ProfessionalController> logger)
        {
            _businessServiceGestaoProfessional = businessServiceGestaoProfessional;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_businessServiceGestaoProfessional.GetAll());
        }

        [HttpGet("{email}")]
        public ActionResult<string> Get(string email)
        {
            try
            {
                var Professional = _businessServiceGestaoProfessional.GetByEmail(email);
                var ProfessionalDTO = _mapper.Map<ProfessionalDTO>(Professional);

                if (ProfessionalDTO.Email != null)
                {
                    return Ok(ProfessionalDTO);
                }
                else
                {
                    return Ok("Professional não encontrado!");
                }
            }
            catch (Exception)
            {
                return Ok("Erro!");
            }
        }

        [HttpPost]
        public ActionResult Post(
            [FromBody] ProfessionalDTO professionalDTO)
        {
            if (professionalDTO == null)
                return NotFound(professionalDTO);

            professionalDTO.ProfessionalId = Guid.NewGuid();
            professionalDTO.DataCadastro = DateTime.Now;

            try
            {
                _businessServiceGestaoProfessional.Add(professionalDTO);
                return Ok("Professional cadastrado com sucesso!");
            }
            catch (Exception)
            {
                return Problem("Não foi possível cadastrar!");
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] ProfessionalDTO ProfessionalDTO)
        {
            if (ProfessionalDTO == null)
                return NotFound();

            try
            {
                _businessServiceGestaoProfessional.Update(ProfessionalDTO);
                return Ok("Professional atualizado com sucesso!");
            }
            catch (Exception)
            {
                return Problem("Não foi possível atualizar!");
            }
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] ProfessionalDTO ProfessionalDTO)
        {
            if (ProfessionalDTO == null)
                return NotFound();

            try
            {
                _businessServiceGestaoProfessional.Remove(ProfessionalDTO);
                return Ok("Professional removido com sucesso!");
            }
            catch (Exception)
            {
                return Problem("Não foi possível remover!");
            }
        }
    }
}
