using Framebook.Business.DTO.DTO;
using Framebook.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Framebook.StackAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class StackController : ControllerBase
    {
        private readonly IBusinessServiceGestaoStack _businessServiceGestaoStack;

        public StackController(IBusinessServiceGestaoStack businessServiceGestaoStack)
        {
            _businessServiceGestaoStack = businessServiceGestaoStack;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllStacks()
        {
            try
            {
                var result = await _businessServiceGestaoStack.GetAllStacks();
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            try
            {
                var result = await _businessServiceGestaoStack.GetById(id);
                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] StackDTO stack)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _businessServiceGestaoStack.PostStack(stack);
                    if (result == false)
                        return BadRequest();

                    return StatusCode((int)HttpStatusCode.Created, result);
                }
                else
                    return StatusCode((int)HttpStatusCode.BadRequest, ModelState);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _businessServiceGestaoStack.DeleteById(id);
                if (result == false)
                    return BadRequest();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] StackDTO stack)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var result = await _businessServiceGestaoStack.UpdateStack(stack);
                if (result == false)
                    return BadRequest();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
