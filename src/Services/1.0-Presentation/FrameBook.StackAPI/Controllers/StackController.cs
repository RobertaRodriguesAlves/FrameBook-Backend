using AutoMapper;
using Framebook.Business.Interfaces;
using Framebook.Business.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Framebook.StackAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StackController : ControllerBase
    {
        private readonly IBusinessServiceGestaoStack _businessServiceGestaoStack;
        IMapper _mapper;

        public StackController(IBusinessServiceGestaoStack businessServiceGestaoStack,
            IMapper mapper)
        {
            _businessServiceGestaoStack = businessServiceGestaoStack;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var test = _businessServiceGestaoStack.GetAll();
            return Ok(test);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var Stack = _businessServiceGestaoStack.GetById(id);
            var StackDTO = _mapper.Map<StackDTO>(Stack);
            return Ok(StackDTO);
        }

        [HttpPost]
        public ActionResult Post([FromBody] StackDTO StackDTO)
        {
            if (StackDTO == null)
                return NotFound();

            _businessServiceGestaoStack.Add(StackDTO);
            return Ok("Stack cadastrada com sucesso!");
        }

        [HttpPut]
        public ActionResult Put([FromBody] StackDTO StackDTO)
        {
            if (StackDTO == null)
                return NotFound();

            _businessServiceGestaoStack.Update(StackDTO);
            return Ok("Stack atualizada com sucesso!");
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] StackDTO StackDTO)
        {
            if (StackDTO == null)
                return NotFound();

            _businessServiceGestaoStack.Remove(StackDTO);
            return Ok("Stack removida com sucesso!");
        }
    }
}
