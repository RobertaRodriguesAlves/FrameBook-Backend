using AutoMapper;
using Framebook.Business.Interfaces;
using Framebook.Business.DTO.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Sentry;
using System;
using Serilog;

namespace Framebook.StackAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StackController : ControllerBase
    {
        private readonly IHub _sentryHub;

        private readonly IBusinessServiceGestaoStack _businessServiceGestaoStack;
        IMapper _mapper;

        public StackController(IBusinessServiceGestaoStack businessServiceGestaoStack,
            IHub sentryHub, IMapper mapper)
        {
            _businessServiceGestaoStack = businessServiceGestaoStack;
            _mapper = mapper;
            _sentryHub = sentryHub;         
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            //For sentry performance test
            var childSpan = _sentryHub.GetSpan()?.StartChild("additional-work");

            try
            {
                Log.Information("GetAll requested");

                var test = _businessServiceGestaoStack.GetAll();

                //Ok for sentry request performance test
                childSpan?.Finish(SpanStatus.Ok);

                return Ok(test);
            }
            catch (Exception e)
            {
                //Finish for sentry request performance test
                childSpan?.Finish(e);

                //Send request exception for sentry log server
                SentrySdk.CaptureException(e);
                throw;
            }
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
