using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Domain.Interfaces.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
//        private ILoginService _service;
//
//        public LoginController(ILoginService service)
//        {
//            _service = service;
//        }
        [HttpPost]
        public async Task<object> Login([FromBody] UserEntity userEntity, [FromServices] ILoginService service)
//        public async Task<object> Login([FromBody] UserEntity userEntity)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            
            if (userEntity == null)
                return BadRequest();

            try
            {
                var result = await service.FindByLogin(userEntity);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
    }
}