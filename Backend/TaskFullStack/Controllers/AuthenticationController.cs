using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFullStack.DTOs;
using TaskFullStack.IServices;
using TaskFullStack.Models;
using TaskFullStack.ServUnitOfWork;

namespace TaskFullStack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        IServUnitOfWork _servUnitOfWork;
        public AuthenticationController(IServUnitOfWork servUnitOfWork)
        {
            _servUnitOfWork = servUnitOfWork;
        }

        [HttpGet,Authorize]
        public IActionResult IsAuthenticated()
        {
            return Ok(true);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO login)
        {
            if (!ModelState.IsValid) { 
                return BadRequest("Invalid Email Or Password");
            }
            user? user = await _servUnitOfWork.UserService.GetuserTryLoginAsync(login);
            if (user == null)
            {
                return NotFound("Invalid Email or Password");
            }
            string token=_servUnitOfWork.AuthenticationService.GenerateAccessToken(user);
            return Ok(token);            
        }

    }
}
