using System;
using System.Net;
using System.Threading.Tasks;
using Domain.DTOs;
using Domain.Interfaces.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private ILoginService _service;

        public LoginController(ILoginService service)
        {
            _service = service;
        }
        [HttpPost]
//        public async Task<object> Login([FromBody] LoginDto dto, [FromServices] ILoginService service)
        public async Task<object> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            
            if (dto == null)
                return BadRequest();

            try
            {
                var result = await _service.FindByLogin(dto);

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