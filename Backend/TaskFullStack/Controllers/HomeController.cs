using System.Security.Claims;
using App.Domain.DTOs;
using App.Domain.Entities;
using App.Service.ServUnitOfWork;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        IServUnitOfWork _servUnitOfWork;
        IMapper _mapper;
        public HomeController(IServUnitOfWork servUnitOfWork,IMapper mapper) {
            _servUnitOfWork = servUnitOfWork;
            _mapper = mapper;
        }
        [HttpGet,Authorize]
        public async Task<IActionResult> HomePage()
        {
            user user = await _servUnitOfWork.UserService.GetUserByEmailAsync(User.FindFirst(ClaimTypes.Email)?.Value);
            registrationDTO registrationDTO=_mapper.Map<registrationDTO>(user);
            string? name = User?.Identity?.Name;
            return Ok(registrationDTO);
        }
    }
}
