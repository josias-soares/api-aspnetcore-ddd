using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Domain.Interfaces.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets all users", Description = "Gets all users of database")]
        [SwaggerResponse(200, "OK")]
        [SwaggerResponse(400, "Bad Request - Verify your request")]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
        [HttpGet]
        [Route("{id}", Name = "GetWithId")]
        public async Task<ActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Get(id));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Post(entity);

                if (result == null)
                {
                    return BadRequest();
                }
                
                return Created(
                    new Uri(Url.Link("GetWithId", new {id = result.Id})), 
                    result);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UserEntity entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

           
            try
            {
                var result = await _service.Put(entity);

                if (result == null)
                {
                    return BadRequest(); 
                }
                
                return Ok(result);

            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

    }
}